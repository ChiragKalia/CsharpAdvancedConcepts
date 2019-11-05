using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Events
{
    public class VideoEncoder
    {
        //How to use events
        //1. Define A Delegate based on a method with the expected signature.
        //2. Define an event based on that delegate.
        //3. Raise the event.
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
        
        //Instead of Creating a custom Delegate and using it, We can also use the C#'s inbuilt ->
        //Delegate EventHandler<> like follows
        //public event EventHandler<VideoEventArgs> VideoEncoded;
        //If we do not want to use any custom event arguments then simply use ->
        //public event EventHandler VideoEncoded;

        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            //Encode Video Logic
            Console.WriteLine("Encoding The Video");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
            Console.WriteLine("Video Encoded");
        }
        //According to .NET Convention, Publisher methods should be protected, virtual and return nothing. 
        //In Terms of naming, They should start with the word ON and then the name of the event.
        protected virtual void OnVideoEncoded(Video video)  
        {
            if(VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs(){ Video = video });
            }
        }

    }


}
