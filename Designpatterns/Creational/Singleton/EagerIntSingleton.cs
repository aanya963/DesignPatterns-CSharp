namespace Designpatterns.Creational.Singleton
{
    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        private Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
    public class EagerSingletonDemo
    {
        public static void Run()
        {
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;

            Console.WriteLine(ReferenceEquals(instance1, instance2)); // Output: True
        }
    }
}