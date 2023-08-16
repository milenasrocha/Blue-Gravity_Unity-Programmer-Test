using System;
using UnityEngine;

namespace LittleSimWorld
{
    [Serializable]
    public class Directions<T> where T : UnityEngine.Object //had to restrict it to Object. Without the restriction the null checks always return false
    {
        public T up;
        public T down;
        public T left;
        public T right;

        public T Get(Directions direction) => Get(direction, out bool _);
        public T Get(Directions direction, out bool isOpposite)
        {
            isOpposite = false;

            switch (direction)
            {
                case Directions.Right:
                    if (right == null)
                    {
                        isOpposite = true;
                        return left;
                    }
                    else
                        return right;
                case Directions.Left:
                    if (left == null)
                    {
                        isOpposite = true;
                        return right;
                    }
                    else
                    {
                        return left;
                    }

                case Directions.Up:
                    return up;

                case Directions.Down:
                    return down;
            }

            return up;
        }
    }
}