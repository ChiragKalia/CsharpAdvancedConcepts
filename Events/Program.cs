using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video("New Video");
            VideoEncoder encoder = new VideoEncoder(); //Publisher
            var mailService = new MailService();    //Subscriber 1
            var textService = new TextService();    //Subscriber 2
            //Adding Subscribers to Notify
            encoder.VideoEncoded += mailService.OnVideoEncoded;
            encoder.VideoEncoded += textService.OnVideoEncoded;
            encoder.Encode(video);
        }
    }
}
