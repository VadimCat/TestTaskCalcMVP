using Models;
using UnityEngine;
using Views;

namespace Presenters
{
    public class CalculatorPresenter
    {
        private readonly CalculatorView _calculatorView;
        private readonly ICalculator _calculator;
    
        public CalculatorPresenter(CalculatorView calculatorView)
        {
            _calculatorView = calculatorView;
            _calculator = new Calculator();
        
            _calculator.Load();
            _calculatorView.SetInputText(_calculator.CurrentInput);
        
            _calculatorView.OnResultRequest += Calculate;
            _calculatorView.OnInputUpdate += UpdateInput;
        }

        private void UpdateInput(string input)
        {
            _calculator.CurrentInput = input;
            _calculator.Save();
        }

        private void Calculate(string input)
        {
            _calculator.Calculate(input);
            _calculatorView.SetInputText(_calculator.CurrentInput);
        }
    }
}
