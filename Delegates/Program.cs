using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            PhotoProcessor processor = new PhotoProcessor();
            var filter = new PhotoFilters();
            Action<Photo> filterHandler = filter.ApplyBrightness;
            filterHandler += filter.ApplyContrast;
            filterHandler += RemoveRedEye;
            processor.Process("photo.jpg", filterHandler);
        }

        static void RemoveRedEye(Photo photo) => Console.WriteLine("Removed RedEye");
    }
}
