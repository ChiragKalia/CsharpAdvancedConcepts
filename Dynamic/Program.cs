using System;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = "Kalia";
            //obj.GetHashCode(); 

            //Using Reflection
            //We can see this code is not beautiful as reflection is difficult and messy.

            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            //Using Dynamic
            //We can see that using dynamic, Our code is much cleaner.
            //Type resolving happens via DLR(Dynamic Language Runtime) which
            //Sits on top of CLR and gives Dynamic language capabilities to C#

            dynamic excelObject = "Kalia";
            excelObject.Optimize(); //Doesn't exist but doesn't throw a compile time error.

            //Using Dynamic, we can also change the type of an already assigned variable
            //For example

            dynamic d = "Kalia";
            d = 10;
            d++;
            Console.WriteLine(d);
        }
    }
}
