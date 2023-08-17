using UnityEngine;
using UnityEngine.Events;
using LittleSimWorld.Characters;

namespace LittleSimWorld
{
    //default implementation class
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] bool isInteractable = true;
        [SerializeField] bool listenForCancel;

        [Space]
        
        public UnityEvent<Character> onInteract;
        public UnityEvent<Character> onInteractionStopped;


        public void Interact() => Interact(PlayerController.Instance.character);
        public virtual void Interact(Character character)
        {
            if (!isInteractable)
                return;

            onInteract.Invoke(character);

            if (listenForCancel)
            {
                InputReader.Cancel.performed += (callback) => StopInteraction(character);
                InputReader.Cancel.performed -= (callback) => StopInteraction(character);
            }
        }

        public void StopInteraction() => StopInteraction(PlayerController.Instance.character);
        public void StopInteraction(Character character)
        {
            onInteractionStopped.Invoke(character);
        }
    }
}
