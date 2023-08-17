using System;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimWorld
{
    [Serializable]
    public class Views<T> where T : UnityEngine.Object //had to restrict it to Object. Without the restriction the null checks always return false
    {
        [SerializeField] T _front;
        public T front
        {
            get => _front;
            set => Set(Views.Front, value);
        }
        [SerializeField] T _back;
        public T back
        {
            get => _back;
            set => Set(Views.Back, value);
        }
        [SerializeField] T _left;
        public T left
        {
            get => _left;
            set => Set(Views.Left, value);
        }
        [SerializeField] T _right;
        public T right
        {
            get => _right;
            set => Set(Views.Right, value);
        }


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
        public IEnumerable<T> GetAll(Views view)
        {
            return new List<T>() { front, back, left, right };
        }


        public void Set(Directions direction, T newValue) => Set((Views)direction, newValue);
        public void Set(Views view, T newValue)
        {
            switch (view)
            {
                case Views.Right:
                    _right = newValue;
                        return;
                case Views.Left:
                    _left = newValue;
                    return;

                case Views.Front:
                    _front = newValue;
                    return;

                case Views.Back:
                    _back = newValue;
                    return;
            }
        }
    }
}