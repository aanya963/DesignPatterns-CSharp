namespace DesignPatterns.Behavioral.Observer
{
    //Observer Interface
    public interface ISubscriber
    {
        void Update();
    }
    //Subject interface -> jisko observe kr rhe h
    public interface IChannel
    {
        void Subscriber(ISubscriber subscriber);
        void Unsubscriber(ISubscriber subscriber);
        void NotifySubscribers();
    }
    // Concrete Subject: YouTube Channel
    public class Channel : IChannel
    {
        private List<ISubscriber>subscribers = new List<ISubscriber>();
        private string name;
        private string latestVideo;
        public Channel(string name)
        {
            this.name=name;
        }
        // Add subscriber (avoid duplicates)
        public void Subscriber(ISubscriber subscriber)
        {
            if (!subscribers.Contains(subscriber))
            {
                subscribers.Add(subscriber);
            }
        }
        // Remove subscriber
        public void Unsubscriber(ISubscriber subscriber)
        {
            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
            }
        }
        //Notify all subscribers
        public void NotifySubscribers()
        {
            foreach(var sub in subscribers)
            {
                sub.Update();
            }
        }

        public void UploadVideo(string title)
        {
            latestVideo=title;
            Console.WriteLine($"\n[{name} uploaded \"{title}\"]");
            NotifySubscribers();
        }
        public string GetVideoData()
        {
            return $"\nCheckout our new Video: {latestVideo}\n";
        }
    }
    public class Subscriber : ISubscriber
    {
        private string name;
        private Channel channel;
        public Subscriber(string name, Channel channel)
        {
            this.name=name;
            this.channel=channel;
        }
        public void Update()
        {
            Console.WriteLine($"Hey {name}, {channel.GetVideoData()}");
        }
    }
    public class ObserverDemo
    {
        public static void Run()
        {
            //Create channel
            Channel channel=new Channel("CoderArmy");
            //Create subscribers
            Subscriber subs1=new Subscriber("nikku", channel);
            Subscriber subs2=new Subscriber("aanya", channel);

            //subscribe
            channel.Subscriber(subs1);
            channel.Subscriber(subs2);

            //upload video
            channel.UploadVideo("observer pattern tutorial");

            //unsubscribe varun
            channel.Unsubscriber(subs1);

            //upload another video
            channel.UploadVideo("Decorator pattern tutorial");
        }
    }
}