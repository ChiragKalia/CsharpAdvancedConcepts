using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "This is supposed to be a very long post blah blah blah...";
            var shorterPost = post.Shorten(5);
            Console.WriteLine(shorterPost);

            //IEnumerable<int> numbers = new List<int>() {1,3,5,8,14,4,25 };
            //Console.WriteLine(numbers.Max());  //Max() is an inbuilt LINQ Extension method.
        }
    }
}
