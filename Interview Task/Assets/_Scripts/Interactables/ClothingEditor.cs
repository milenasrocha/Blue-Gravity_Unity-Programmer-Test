using UnityEngine;

namespace LittleSimWorld
{
    public class ClothingEditor : Interactable
    {
        [SerializeField] ClothingEditorUI UI;

        void Awake()
        {
            onInteract.AddListener((character) =>
            {
                UI.ShowCanvas();
                UI.onStopInteraction += Close;
            });
            onInteractionStopped.AddListener((character) =>
            {
                UI.onStopInteraction -= Close;
                UI.HideCanvas();
            });
        }

        public void Open() => Interact();
        public void Close() => StopInteraction();
    }
}
