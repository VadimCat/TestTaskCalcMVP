using Presenters;
using UnityEngine;
using Views;

namespace Client
{
    public class Entry : MonoBehaviour
    {
        [SerializeField] private CalculatorView calculatorView;
        
        private void Awake()
        {
            var calculatorPresenter = new CalculatorPresenter(calculatorView);
        }
    }
}