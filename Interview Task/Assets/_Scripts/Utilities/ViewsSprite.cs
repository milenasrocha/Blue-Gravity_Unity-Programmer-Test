using UnityEngine;
using UnityEngine.UI;

namespace LittleSimWorld
{
    public class ViewsSprite : Views<Sprite>
    {
        //although SpriteRenderer and Image inherit from the Renderer component they don't share the same 'sprite' field :(

        public void ApplyTo(Views<SpriteRenderer> targetViews)
        {
            //TODO: Maybe log a warning here in case theres a view missing?
            
            if (targetViews.front != null)
                targetViews.front.sprite = front;
            if (targetViews.back != null)
                targetViews.back.sprite = back;
            if (targetViews.left != null)
                targetViews.left.sprite = left;
            if (targetViews.right != null)
                targetViews.right.sprite = right;
        }
        public void ApplyTo(Views<Image> targetViews)
        {
            if (targetViews.front != null)
                targetViews.front.sprite = front;
            if (targetViews.back != null)
                targetViews.back.sprite = back;
            if (targetViews.left != null)
                targetViews.left.sprite = left;
            if (targetViews.right != null)
                targetViews.right.sprite = right;
        }
    }
}