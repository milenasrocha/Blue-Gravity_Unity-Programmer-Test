using UnityEngine;

namespace LittleSimWorld
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] Shop shop;
        [Space]
        [SerializeField] GameObject canvas;

        void Start()
        {
            shop.onInteract.AddListener((character) => canvas.SetActive(true));
            shop.onInteractionStopped.AddListener((character) => canvas.SetActive(false));
        }
        public void Close() => shop.Close();
    }
}
