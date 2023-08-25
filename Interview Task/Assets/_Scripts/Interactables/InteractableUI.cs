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
            interactable.onInteract.AddListener((character) => ShowCanvas());
            interactable.onInteractionStopped.AddListener((character) => HideCanvas());
        }

        protected virtual void StopInteraction() => interactable.StopInteraction();

        public void ShowCanvas() => canvas.SetActive(true);
        public void HideCanvas() => canvas.SetActive(false);
    }
}
