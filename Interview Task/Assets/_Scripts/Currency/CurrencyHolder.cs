using UnityEngine;

namespace LittleSimWorld
{
    //this aint one of the CharacterComponent scripts because I understand maybe currency ain't necessaily stored with a character
    public class CurrencyHolder : MonoBehaviour
    {
        [SerializeField] int _amount;
        public int amount
        {
            get => _amount;
            private set=> _amount = value;
        }

        public void AddAmount(int amount)
        {
            amount += amount;
        }
        public void RemoveAmount(int amount)
        {
            amount -= amount;
        }
    }
}