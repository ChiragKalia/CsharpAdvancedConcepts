using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    //Where T: Icomparable
    //Where T: Product
    //Where T: Struct - Value Types
    //Where T: Class
    //Where T: new()

    //Using Generic Constraints 
    public class Utilities<T> where T : IComparable, new()   //Should implement IComparable interface and new() 
    { //We can create Generic Methods inside non generic class.
        public void DoSomething()
        {
            var obj = new T();
        }
        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}
