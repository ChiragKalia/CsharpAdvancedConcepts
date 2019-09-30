using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class PhotoProcessor
    {
        //public delegate void PhotoFilterHandler(Photo photo); //Using the inbuilt Generic Delegate instead of creating one.
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = new Photo(path);
            filterHandler(photo);
            //var filters = new PhotoFilters();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);
            photo.Save();
        }
    }
}
