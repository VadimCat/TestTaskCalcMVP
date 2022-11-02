using System;
using System.Linq;
using UnityEngine;

namespace Models
{
    public class Calculator : ICalculator
    {
        private const string SaveKey = "CalcState";
        
        public string CurrentInput { get; set; }

        public void Calculate(string input)
        {
            if (input.Any(c => !char.IsDigit(c) && c != '+'))
            {
                CurrentInput = "Error";
            }
            else
            {
                var nums = input.Split('+');
                
                var sum = (from numStr in nums 
                        select Convert.ToUInt64(numStr))
                    .Aggregate((a, b) => Convert.ToUInt64(a) + Convert.ToUInt64(b));
                
                CurrentInput = sum.ToString();
            }

            Save();
        }

        public void Save()
        {
            PlayerPrefs.SetString(SaveKey, CurrentInput);
        }

        public void Load()
        {
            if (PlayerPrefs.HasKey(SaveKey))
                CurrentInput = PlayerPrefs.GetString(SaveKey);
        }
    }
}