using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    public class Calculator
    {
        public delegate double Operation(double a, double b);

        public readonly Dictionary<string, Operation> Operations;
        
        public Calculator()
        {
            Operations = new Dictionary<string, Operation>
            {
                {"+", (a, b) => a + b},
                {"-", (a, b) => a - b},
                {"*", (a, b) => a * b},
                {"/", (a, b) => a / b}
            };
        }

        public double Operate(double a, double b, string operation)
        {
            if (!Operations.Keys.Contains(operation))
                throw new ArgumentException();

            return Operations[operation](a, b);
        }
    }
}