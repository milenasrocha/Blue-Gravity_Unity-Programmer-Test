using UnityEngine;

namespace LittleSimWorld
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] Shop shop;
        [Space]
        [SerializeField] GameObject whole;

        void Start()
        {
            shop.onEnableStateChanged += whole.SetActive;
        }
    }
}
