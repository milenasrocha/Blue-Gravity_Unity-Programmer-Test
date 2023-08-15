using UnityEngine;

namespace LittleSimWorld
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning($"Destroying an instance of Singleton because another instance was found. " +
                                                $"The instances are {gameObject.name} and {Instance.gameObject.name}. " +
                                                $"Destroying {gameObject.name}.");

                Destroy(gameObject);
            }

            Instance = this as T;
        }

        protected virtual void OnApplicationQuit()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
}