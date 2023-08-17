using UnityEngine;
using UnityEngine.Events;

namespace LittleSimWorld.Utilities
{
    public class OnOnTriggerExit : MonoBehaviour
    {
        public UnityEvent<Collider> unityEvent;

        void OnTriggerExit(Collider other) => unityEvent.Invoke(other);
    }
}