using System;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public abstract class CharacterCustomizationItem : ScriptableObject
    {
        public string id; //I'll be using this as dictionary keys
        [SerializeField] Sprite _icon; //optional. if not filled it'll get the front view
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
        public Views<Sprite> views;

        public abstract void ApplyTo(CharacterView characterView);

        public void ApplyTo(Views<SpriteRenderer> targetViews)
        {
            if(targetViews.front != null)
            targetViews.front.sprite = views.front;
            if(targetViews.back != null)
                targetViews.back.sprite = views.back;
            if(targetViews.left != null)
                targetViews.left.sprite = views.left;
            if(targetViews.right != null)
                targetViews.right.sprite = views.right;

            //TODO: Maybe log a warning here in case theres no component?
        }
        public void ApplyTo(Views<Image> targetViews)
        {
            if(targetViews.front != null)
                targetViews.front.sprite = views.front;
            if(targetViews.back != null)
                targetViews.back.sprite = views.back;
            if(targetViews.left != null)
                targetViews.left.sprite = views.left;
            if(targetViews.right != null)
                targetViews.right.sprite = views.right;
        }
        //although SpriteRenderer and Image inherit from the Renderer component they don't share the same 'sprite' field :(
    }
}