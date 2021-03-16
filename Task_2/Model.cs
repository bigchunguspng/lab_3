namespace Task_2
{
    public class Model
    {
        public readonly Calculator Calculator;
        
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        public delegate void Notify();

        public event Notify OperationCompleted;

        public Model()
        {
            Calculator = new Calculator();
        }

        public void Calculate(string operation)
        {
            Number1 = Calculator.Operate(Number1, Number2, operation);
            OperationCompleted?.Invoke();
        }
    }
}