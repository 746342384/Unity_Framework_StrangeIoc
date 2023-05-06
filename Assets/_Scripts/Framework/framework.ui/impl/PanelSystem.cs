﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Extensions;
using Framework.framework.attribute;
using Framework.framework.resources.api;
using Framework.framework.system.impl;
using framework.framework.ui.api;
using strange.extensions.context.impl;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace framework.framework.ui.impl
{
    public class PanelSystem : SystemBase, IPanelSystem
    {
        private readonly IResourceSystemService _resourceSystemService;
        private readonly IUIRoot _uiRoot;
        private readonly Dictionary<string, IUIPanel> _panels = new();
        private readonly Dictionary<string, GameObject> _panelCache = new();
        private readonly Dictionary<string, GameObject> _panelLoadCache = new();

        public PanelSystem(IResourceSystemService resourceSystemService,
            IUIRoot uiRoot)
        {
            _resourceSystemService = resourceSystemService;
            _uiRoot = uiRoot;
        }

        public bool IsInitialized { get; set; }

        public override void OnInit()
        {
            if (IsInitialized)
            {
                return;
            }

            _uiRoot.Init();
            LoadPanels();
            IsInitialized = true;
        }

        private void LoadPanels()
        {
            _panels.Clear();
            _panelCache.Clear();
            var types = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetCustomAttributes(typeof(ActAttribute), true).Length > 0)
                .ToArray();

            foreach (var type in types)
            {
                var customAttributes = type.GetCustomAttribute<ActAttribute>();
                if (customAttributes == null) continue;
                var actAttributeKey = customAttributes.Key.ToString();
                var iuipanel = Activator.CreateInstance(type) as IUIPanel;
                _panels[actAttributeKey] = iuipanel;
            }
        }

        public async Task PreLoadPanel()
        {
            foreach (var (panelName, value) in _panels)
            {
                var valuePath = value.Path;
                var gameObject = await _resourceSystemService.LoadAsync<GameObject>(valuePath);
                if (gameObject != null) _panelLoadCache[panelName] = gameObject;
                Debug.Log($"PreLoadPanel:{panelName} : {valuePath}");
            }
        }

        public async void OpenPanel(string panelName, object data = null)
        {
            if (!_panels.TryGetValue(panelName, out var uiPanel)) return;

            var uiRootNormalRoot = uiPanel.Layer switch
            {
                UILayer.Top => _uiRoot.TopRoot,
                UILayer.Normal => _uiRoot.NormalRoot,
                UILayer.PopUp => _uiRoot.PopUpRoot,
                _ => throw new ArgumentOutOfRangeException()
            };


            if (!_panelCache.TryGetValue(panelName, out var panel))
            {
                if (!_panelLoadCache.TryGetValue(panelName, out var prefab))
                {
                    prefab = await _resourceSystemService.LoadAsync<GameObject>(uiPanel.Path);
                }

                var panenlTransform = new GameObject(panelName);
                var addComponent = panenlTransform.AddComponent<ContextView>();
                addComponent.context = GameContext.Instance;
                addComponent.autoRegisterWithContext = true;
                panenlTransform.transform.SetParent(uiRootNormalRoot);
                var component = panenlTransform.AddComponent<Canvas>();
                panenlTransform.AddComponent<GraphicRaycaster>();
                component.overrideSorting = true;
                var transform = panenlTransform.transform as RectTransform;
                transform.FitParent();
                panenlTransform.transform.localScale = Vector3.one;


                panel = Object.Instantiate(prefab, panenlTransform.transform, true);
                panel.transform.localScale = Vector3.one;
                _panelCache.Add(panelName, panenlTransform);
            }


            var context = uiPanel.ContextNmae;
            var rectTransform = panel.transform as RectTransform;
            rectTransform.FitParent();
            panel.transform.localScale = Vector3.one;
            panel.SetActive(true);
            uiPanel.Show();
            Debug.Log($"OpenPanel:{panelName}");
        }

        private void CreateContextView()
        {
        }

        public Task OpenPanelAsync(string panelName, object data = null)
        {
            OpenPanel(panelName);
            return Task.CompletedTask;
        }

        public void ClosePanel(string panelName)
        {
            if (!_panels.TryGetValue(panelName, out var uiPanel)) return;
            if (!_panelCache.TryGetValue(panelName, out var panel)) return;
            uiPanel.Hide();
            panel.SetActive(false);
        }

        public Task ClosePanelAsync(string panelName)
        {
            ClosePanel(panelName);
            return Task.CompletedTask;
        }

        public void UnLoadAllPanel()
        {
            foreach (var keyValuePair in _panelLoadCache)
            {
                _resourceSystemService.Realease(keyValuePair.Value);
            }

            _panelLoadCache.Clear();

            foreach (var keyValuePair in _panels)
            {
                keyValuePair.Value.UnLoad();
            }

            _panels.Clear();

            foreach (var keyValuePair in _panelCache)
            {
                Object.DestroyImmediate(keyValuePair.Value);
            }

            _panelCache.Clear();
        }

        public void UnLoadPanel(string panelName)
        {
            if (_panels.TryGetValue(panelName, out var panel))
            {
                panel.UnLoad();
                _panels.Remove(panelName);
            }

            if (_panelCache.TryGetValue(panelName, out var gameObject))
            {
                Object.DestroyImmediate(gameObject);
                _panelCache.Remove(panelName);
            }
        }
    }
}