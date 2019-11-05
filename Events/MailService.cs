using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class MailService
    {
        public void OnVideoEncoded(Object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine("MailService: Sending an email..."+ eventArgs.Video.Title);
        }
    }
}
