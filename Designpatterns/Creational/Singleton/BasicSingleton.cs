namespace Designpatterns.Creational.Singleton
{
    public class BasicSingleton
    {
        private static BasicSingleton? _instance;

        // Private constructor prevents external instantiation
        private BasicSingleton()
        {
        }

        public static BasicSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BasicSingleton();
            }
            return _instance;
        }
    }
    public class BasicSingletonDemo
    {
        public static void Run()
        {
            BasicSingleton instance1 = BasicSingleton.GetInstance();
            BasicSingleton instance2 = BasicSingleton.GetInstance();

            Console.WriteLine(ReferenceEquals(instance1, instance2)); // Output: True
        }
    }
}