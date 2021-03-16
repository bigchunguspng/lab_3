using System;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double result = 0;
            
            Presenter presenter = new Presenter();
            presenter.ProccessCompleted += () => result = presenter.Result;
            
            string expression;
            while (true)
            {
                Say("Введіть вираз у форматі \"число1 операція число2\": ");
                expression = Console.ReadLine();
                presenter.Process(expression);
                Say(result, ConsoleColor.Yellow);
            }
        }

        private static void Say(object message, ConsoleColor color = ConsoleColor.DarkGray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message.ToString().Replace('і','i'));
            Console.ResetColor();
        }
    }
}