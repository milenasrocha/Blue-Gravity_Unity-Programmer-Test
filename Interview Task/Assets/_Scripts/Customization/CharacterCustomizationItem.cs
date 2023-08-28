using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public abstract class CharacterCustomizationItem : ScriptableObject
    {
        public string id; //I'll be using this as dictionary keys
        public new string name;

        [SerializeField] Sprite _icon; //optional. uses front view if == null
        public Sprite icon
        {
            get
            {
                if (_icon == null)
                    return views.front;

                return _icon;
            }
            set => _icon = value;
        }

        public ViewsSprite views;

        public void ApplyTo(CharacterView characterView)
        {
            ApplyViewsTo(characterView);
        }
        protected abstract void ApplyViewsTo(CharacterView characterView);
    }
}