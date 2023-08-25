using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimWorld
{
    public class Wardrobe : Interactable
    {
        public void Open() => Interact();
        public void Close() => StopInteraction();
    }
}
