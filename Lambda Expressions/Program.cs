using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // args => expression;
            // number => number*number;
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));
        }
    }
}
