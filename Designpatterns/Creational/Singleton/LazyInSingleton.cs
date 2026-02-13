namespace Designpatterns.Creational.Singleton
{
    public sealed class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance =
            new Lazy<LazySingleton>(() => new LazySingleton());

        private LazySingleton()
        {
        }

        public static LazySingleton Instance => _instance.Value;
    }
    public class LazySingletonDemo
    {
        public static void Run()
        {
            LazySingleton instance1 = LazySingleton.Instance;
            LazySingleton instance2 = LazySingleton.Instance;

            Console.WriteLine(ReferenceEquals(instance1, instance2)); // Output: True
        }
    }
}