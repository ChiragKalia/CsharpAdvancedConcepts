using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //var numbers = new GenericList<int>();
            //numbers.Add(10);

            //var genericDictionary = new GenericDictionary<string, int>();
            //genericDictionary.Add("1234", 3);
            //Console.WriteLine("Hello World!");

            var number = new Nullable<int>();
            Console.WriteLine("Has Value: "+ number.HasValue);
            Console.WriteLine("Value "+ number.GetValueOrDefault());
        }
    }
}
