using System.Collections.Generic;

namespace LittleSimWorld
{
    public class Shop : Interactable
    {
        Dictionary<string, int> items;
        //can open the shop UI by calling it in script (on Interact()) OR you can fill in the UnityEvent on inspector

        public void Open() => Interact();
        public void Close() => StopInteraction();
    }
}
