using UnityEngine;
using UnityEngine.Events;
using LittleSimWorld.Characters;

namespace LittleSimWorld
{
    //default implementation class
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] new string name;
        [SerializeField] bool isInteractable = true;

        [Space]
        
        public UnityEvent<Character> onInteract;
        public UnityEvent<Character> onInteractionStopped;


        public void Interact() => Interact(PlayerController.Instance.character);
        public virtual void Interact(Character character)
        {
            if (!isInteractable)
                return;

           if (onInteract != null)
                onInteract.Invoke(character);
        }

        public void StopInteraction() => StopInteraction(PlayerController.Instance.character);
        public virtual void StopInteraction(Character character)
        {
            if (onInteractionStopped != null)
                onInteractionStopped.Invoke(character);
        }
    }
}
