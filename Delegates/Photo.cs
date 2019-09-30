using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class Photo
    {
        public Photo(string path)
        {
            Console.WriteLine("Path: " + path);
        }

        public void Save()
        {
            Console.WriteLine("Saving The Photo");
        }
    }
}
