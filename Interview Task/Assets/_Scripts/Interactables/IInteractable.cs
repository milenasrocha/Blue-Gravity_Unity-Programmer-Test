using LittleSimWorld.Characters;

namespace LittleSimWorld
{
    public interface IInteractable
    {
        //this dont need to have Character as a parameter,
        //but if the game could be local multiplayer it would be useful
        void Interact(Character character);
        void StopInteraction(Character character);
        //TODO: callback OnStartInteraction|OnEndInteraction (delegate or methods)
    }
}