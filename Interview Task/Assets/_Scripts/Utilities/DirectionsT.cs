using System;
using UnityEngine;

namespace LittleSimWorld
{
    [Serializable]
    public class Views<T> where T : UnityEngine.Object //had to restrict it to Object. Without the restriction the null checks always return false
    {
        public T front;
        public T back;
        public T left;
        public T right;

        public T Get(Directions direction) => Get(direction, out bool _);
        public T Get(Directions direction, out bool isOpposite) => Get(view: (Views)direction, out isOpposite);
        public T Get(Views view) => Get(view, out bool _);
        public T Get(Views view, out bool isOpposite)
        {
            isOpposite = false;

            switch (view)
            {
                case Views.Right:
                    if (right == null)
                    {
                        isOpposite = true;
                        return left;
                    }
                    else
                        return right;
                case Views.Left:
                    if (left == null)
                    {
                        isOpposite = true;
                        return right;
                    }
                    else
                    {
                        return left;
                    }

                case Views.Front:
                    return front;

                case Views.Back:
                    return back;
            }

            return front;
        }
    }
}