using strange.extensions.context.impl;
using UnityEngine;

namespace Root
{
    public class GameRoot : ContextView
    {
        private void Awake()
        {
            Debug.Log($"GameRoot.Awake");
            context = new GameContext(this);
        }
    }
}
