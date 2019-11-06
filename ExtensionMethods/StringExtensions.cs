using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System //ExtensionMethods //In order to make this extension method available everywhere
// We should use the System namespace instead
{
    //According to C# convention, Extension class should be public and static
    //And it should begin with the name of the class which we are extending.
    //Microsoft says that Extension methods should be used only when required ->
    //Because if microsoft decides to create Shorten method in the String Class
    //with the same syntax then it will cause errors.
    public static class StringExtensions
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            if (numberOfWords <= 0)
                throw new InvalidOperationException();
            var words = str.Split(' ');
            if (words.Length <= numberOfWords)
                return str; //Return the original string if there's only one word.
            return String.Join(" ", words.Take(numberOfWords)) + "...";
        }
    }
}
