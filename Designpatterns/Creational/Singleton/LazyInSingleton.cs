using System;

namespace Designpatterns.Creational.Singleton
{
    /*
     ===============================================================
     LAZY<T> SINGLETON (Recommended in Modern C#)
     ===============================================================
    Lazy<T> is a .NET built-in class that:
        ~ Delays object creation until first use
        ~ Is thread-safe by default
        ~ Guarantees only one instance

     Definition:
     This implementation uses the built-in Lazy<T> class
     provided by .NET.

     It gives us:
     ✔ Lazy Initialization
     ✔ Thread Safety
     ✔ Clean Code
     ✔ No manual locking required

     This is the most elegant and recommended way
     to implement Singleton in C#.
     ===============================================================
    */

    public sealed class LazySingleton
    {
        /*
         Lazy<T> is a .NET class that:
            - Delays object creation until first use
            - Ensures thread safety
            - Guarantees object is created only once

         Here:
            LazySingleton = type being created
            () => new LazySingleton() = factory function
        */
        private static readonly Lazy<LazySingleton> _instance =
            new Lazy<LazySingleton>(() => new LazySingleton());

        /*
         Private constructor prevents external instantiation.

         Nobody outside this class can call:
             new LazySingleton(); ❌
        */
        private LazySingleton()
        {
            // Initialization logic can go here
        }

        /*
         Public global access point.

         IMPORTANT:
         _instance.Value triggers object creation
         ONLY the first time it is accessed.

         After first creation,
         same instance is returned every time.
        */
        public static LazySingleton Instance => _instance.Value;
    }

    /*
     ===============================================================
     DEMO CLASS
     ===============================================================
    */
    public class LazySingletonDemo
    {
        public static void Run()
        {
            LazySingleton instance1 = LazySingleton.Instance;
            LazySingleton instance2 = LazySingleton.Instance;

            /*
             ReferenceEquals verifies that both variables
             point to the same memory location.

             Output: True
            */
            Console.WriteLine(ReferenceEquals(instance1, instance2));
        }
    }
}
