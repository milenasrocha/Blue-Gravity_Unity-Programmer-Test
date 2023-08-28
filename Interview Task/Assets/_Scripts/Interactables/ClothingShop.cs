using System.Collections.Generic;
using UnityEngine;

namespace LittleSimWorld
{
    public class ClothingShop : Interactable
    {
        [SerializeField] ClothingShopUI UI;

        Dictionary<string, int> items;
        //can open the shop UI by calling it in script (on Interact()) OR you can fill in the UnityEvent on inspector

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
