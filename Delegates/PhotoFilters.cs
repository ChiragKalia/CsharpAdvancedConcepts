using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo) => Console.WriteLine("Brightness Applied");
        public void ApplyContrast(Photo photo) => Console.WriteLine("Contrast Applied");
        public void Resize(Photo photo) => Console.WriteLine("Resize Applied");

    }
}
