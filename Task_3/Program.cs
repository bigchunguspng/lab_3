using System;
using System.Threading;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Recursion(64);
            Recursion(-6);
            Recursion(1);
            Console.ReadKey();
        }

        private static void Recursion(object x)
        {
            if ((int)x == 0) return;
            Console.WriteLine(x);
            Thread thread = new Thread(Recursion);
            thread.Start((int)x / 2);
        }
    }
}