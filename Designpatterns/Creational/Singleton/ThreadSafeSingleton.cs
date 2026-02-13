namespace Designpatterns.Creational.Singleton
{
    public class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton _instance;
        private static readonly object _lock = new object();

        private ThreadSafeSingleton()
        {
        }

        public static ThreadSafeSingleton GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ThreadSafeSingleton();
                }
                return _instance;
            }
        }
    }
    public class ThreadSafeSingletonDemo
    {
        public static void Run()
        {
            ThreadSafeSingleton instance1 = ThreadSafeSingleton.GetInstance();
            ThreadSafeSingleton instance2 = ThreadSafeSingleton.GetInstance();

            Console.WriteLine(ReferenceEquals(instance1, instance2)); // Output: True
        }
    }
}