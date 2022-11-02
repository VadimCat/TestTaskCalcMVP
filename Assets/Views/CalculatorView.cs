using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private Button resultButton;
        [SerializeField] private TMP_InputField inputField;

        public event Action<string> OnInputUpdate; 
        public event Action<string> OnResultRequest;

        private void Awake()
        {
            resultButton.onClick.AddListener(RequestResult);
            inputField.onValueChanged.AddListener(UpdateInput);
        }

        private void UpdateInput(string input)
        {
            OnInputUpdate?.Invoke(input);
        }

        private void RequestResult()
        {
            OnResultRequest?.Invoke(inputField.text);
        }

        public void SetInputText(string text)
        {
            inputField.text = text;
        }

        private void OnDestroy()
        {
            resultButton.onClick.RemoveListener(RequestResult);
            OnResultRequest = null;

            inputField.onValueChanged.RemoveListener(UpdateInput);
            OnInputUpdate = null;
        }
    }
}
