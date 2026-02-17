using System;

namespace Designpatterns.Creational.Singleton
{
    /*
     ===============================================================
     BASIC SINGLETON (Lazy Initialization - NOT Thread Safe)
     ===============================================================

     Definition:
     Singleton ensures that a class has only ONE instance
     and provides a global access point to that instance.

     This is the most basic implementation.

     IMPORTANT:
     - Instance is created only when first requested (Lazy)
     - NOT thread-safe
     - Suitable only for single-threaded applications

     ===============================================================
    */

    public class BasicSingleton
    {
        /*
         Static field to hold the single instance.
         Why static?
         Because Singleton instance must belong to the class itself,
         not to any object.

         Initially null → instance not yet created.
        */
        private static BasicSingleton? _instance;

        /*
         Private constructor prevents external instantiation.

         If constructor were public:
             new BasicSingleton()  ❌
         That would break Singleton rule.

         So we make it private.
        */
        private BasicSingleton()
        {
            // You can put initialization logic here
        }

        /*
         Public method to access the single instance.

         This is called "Global Access Point".

         Lazy Initialization:
         Object is created only when GetInstance() is called.
        */
        public static BasicSingleton GetInstance()
        {
            /*
             If instance is null → create new object.
             Otherwise → return existing object.
            */
            if (_instance == null)
            {
                _instance = new BasicSingleton();
            }

            return _instance;
        }
    }

    /*
     ===============================================================
     DEMO CLASS
     ===============================================================
    */

    public class BasicSingletonDemo
    {
        public static void Run()
        {
            // Get first instance
            BasicSingleton instance1 = BasicSingleton.GetInstance();

            // Get second instance
            BasicSingleton instance2 = BasicSingleton.GetInstance();

            /*
             ReferenceEquals checks whether both variables
             point to the SAME object in memory.

             Output: True
             Because Singleton ensures only one instance exists.
            */
            Console.WriteLine(ReferenceEquals(instance1, instance2));
        }
    }
}
