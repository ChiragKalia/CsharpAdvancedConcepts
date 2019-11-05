using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class TextService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("TextService: Sending a Text..."+ e.Video.Title);
        }
    }
}
