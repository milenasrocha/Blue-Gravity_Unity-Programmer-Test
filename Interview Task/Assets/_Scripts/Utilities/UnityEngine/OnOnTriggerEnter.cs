using UnityEngine;
using UnityEngine.Events;

namespace LittleSimWorld.Utilities
{
    public class OnOnTriggerEnter : MonoBehaviour
    {
        public UnityEvent<Collider> unityEvent;

        void OnTriggerEnter(Collider other) => unityEvent.Invoke(other);
    }
}