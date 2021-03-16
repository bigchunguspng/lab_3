namespace Task_2
{
    public class Presenter
    {
        private string _operation;
        private readonly Model _model;
        
        public double Result;

        public event Model.Notify ProccessCompleted;
        
        public Presenter()
        {
            _model = new Model();
            _model.OperationCompleted += UpdateView;
        }

        public void Process(string expression)
        {
            expression = expression.Replace('.', ',').Replace(" ", "");
            foreach (string operation in _model.Calculator.Operations.Keys)
                expression = expression.Replace(operation, " " + operation + " ");

            string[] parts = expression.Split(' ');

            _model.Number1 = double.Parse(parts[0]);
            _operation = parts[1];
            _model.Number2 = double.Parse(parts[2]);
            
            _model.Calculate(_operation);
        }
        
        private void UpdateView()
        {
            Result = _model.Number1;
            ProccessCompleted?.Invoke();
        }
    }
}