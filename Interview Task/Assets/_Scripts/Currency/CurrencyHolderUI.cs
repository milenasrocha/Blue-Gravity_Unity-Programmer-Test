using TMPro;
using UnityEngine;

namespace LittleSimWorld
{
    public class CurrencyHolderUI : MonoBehaviour
    {
        [SerializeField] CurrencyHolder currencyHolder;
        [Space]
        [SerializeField] GameObject canvas;
        [SerializeField] TextMeshProUGUI amount;

        void Start()
        {
            amount.text = currencyHolder.amount.ToString();
            currencyHolder.onValueChanged += (newValue) => amount.text = newValue.ToString();
        }
    }
}