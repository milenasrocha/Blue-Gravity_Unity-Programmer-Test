using UnityEngine;

namespace LittleSimWorld
{
    public class Shop : Interactable
    {
        [SerializeField] GameObject UI;


        //can open the shop UI by calling it in script (on Interact()) OR you can fill in the UnityEvent on inspector
        void Awake()
        {
            onInteract.AddListener((character) => Open());
            onInteractionStopped.AddListener((character) => Close());
        }

        void Open() => SwitchState(true);
        void Close() => SwitchState(false);
        void SwitchState(bool open)
        {
            UI.SetActive(open);
        }
    }
}
