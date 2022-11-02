namespace Models
{
    public interface ICalculator : ISavable
    {
        public string CurrentInput { get; set; }
        public void Calculate(string input);
    }
}