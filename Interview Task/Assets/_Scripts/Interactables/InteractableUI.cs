using UnityEngine;

namespace LittleSimWorld
{
    public class InteractableUI<T> : MonoBehaviour where T : Interactable
    {
        [SerializeField] Interactable interactable;
        [Space]
        [SerializeField] GameObject canvas;


        protected virtual void Start()
        {
            interactable.onInteract.AddListener((character) => canvas.SetActive(true));
            interactable.onInteractionStopped.AddListener((character) => canvas.SetActive(false));
        }

        protected virtual void StopInteraction() => interactable.StopInteraction();
    }
}
