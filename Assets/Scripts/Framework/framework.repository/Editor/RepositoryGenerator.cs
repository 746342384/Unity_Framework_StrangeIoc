using System.IO;
using UnityEditor;
using UnityEngine;

public class RepositoryGenerator : EditorWindow
{
    private string _entityName = "EntityName";
    private string _keyType = "int";
    private string _outputFolder = "Assets/Scripts/RepositoryGenerator";
    private string _entityOutputFolder = "Assets/Scripts/RepositoryGenerator";

    [MenuItem("Tools/Generate Repository")]
    public static void ShowWindow()
    {
        GetWindow<RepositoryGenerator>("Repository Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Repository Generator", EditorStyles.boldLabel);

        _entityName = EditorGUILayout.TextField("Entity Name", _entityName);
        _keyType = EditorGUILayout.TextField("Key Type", _keyType);

        EditorGUILayout.Space();

        GUILayout.Label("Repository Output Folder", EditorStyles.boldLabel);
        _outputFolder = EditorGUILayout.TextField(_outputFolder);
        if (GUILayout.Button("Select Repository Folder"))
        {
            _outputFolder = EditorUtility.OpenFolderPanel("Select Repository Output Folder", "Assets/Scripts", "");
        }

        EditorGUILayout.Space();

        GUILayout.Label("Entity Output Folder", EditorStyles.boldLabel);
        _entityOutputFolder = EditorGUILayout.TextField(_entityOutputFolder);
        if (GUILayout.Button("Select Entity Folder"))
        {
            _entityOutputFolder = EditorUtility.OpenFolderPanel("Select Entity Output Folder", "Assets/Scripts", "");
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Generate Repository"))
        {
            GenerateRepository(_entityName, _keyType, _outputFolder);
        }

        if (GUILayout.Button("Generate Entity"))
        {
            GenerateEntity(_entityName, _keyType, _entityOutputFolder);
        }
    }

    private void GenerateRepository(string entityName, string keyType, string outputFolder)
    {
        var template = $@"using System;
using System.Collections.Generic;
using Framework.framework.log;
using Framework.framework.repository;
using Framework.framework.attribute;

namespace Repository.{_entityName}
{{

    public interface I{entityName}Repository : IReadOnlyRepository<{keyType}, {entityName}>
    {{
    }}

    [Repository(typeof(I{entityName}Repository))]
    public class {entityName}Repository : BaseConfigRepository<{keyType}, {entityName}>
    {{
        public {entityName}Repository(IConfigLoader configLoader, ILog log) : base(configLoader, log) {{ }}
        protected override string ConfigName => nameof({entityName});

        protected override {keyType} GetId({entityName} item)
        {{
            // Replace the property name 'Id' with the actual key property name of your entity class.
            return item.Id;
        }}
    }}
}}";
        var outputPath = $"{outputFolder}/{entityName}Repository.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        File.WriteAllText(outputPath, template);
        AssetDatabase.Refresh();
        Debug.Log($"{entityName}Repository has been generated!");
    }

    private void GenerateEntity(string entityName, string keyType, string outputFolder)
    {
        var template = $@"using System;

namespace Repository.{_entityName}
{{
    [Serializable]
    public class {entityName}
    {{
        // Replace 'Id' and its type with the actual key property name and type of your entity class.
        public {keyType} Id {{ get; set; }}

        // Add other properties for your entity class here.
    }}
}}";
        var outputPath = $"{outputFolder}/{entityName}.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);
        File.WriteAllText(outputPath, template);
        AssetDatabase.Refresh();
        Debug.Log($"{entityName} entity has been generated!");
    }
}