
using System;

namespace Designpatterns.Creational.Singleton
{
    /*
     ===============================================================
     THREAD-SAFE SINGLETON (Using lock)
     ===============================================================

     This implementation ensures that:

     ✔ Only one instance is created
     ✔ Multiple threads cannot create multiple instances
     ✔ Lazy initialization is preserved

     However:
     ✘ Every call to GetInstance() uses lock
     ✘ Slight performance overhead

     This was the traditional way before Lazy<T>.
     ===============================================================
    */

    public sealed class ThreadSafeSingleton
    {
        /*
         Static field to hold the Singleton instance.

         Not readonly because we assign it lazily.
        */
        private static ThreadSafeSingleton _instance;

        /*
         Lock object used to synchronize threads.

         Why separate object?
         Best practice:
         Never lock on "this" or on type itself.
         Always use private readonly object.
        */
        private static readonly object _lock = new object();

        /*
         Private constructor prevents external instantiation.
        */
        private ThreadSafeSingleton()
        {
            // Initialization logic here
        }

        /*
         Public global access method.

         lock ensures:
         Only one thread enters this block at a time.
        */
        public static ThreadSafeSingleton GetInstance()
        {
            /*
             If multiple threads reach here:

             Only one thread acquires lock.
             Others wait until lock is released.
            */
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

    /*
     ===============================================================
     DEMO CLASS
     ===============================================================
    */
    public class ThreadSafeSingletonDemo
    {
        public static void Run()
        {
            ThreadSafeSingleton instance1 = ThreadSafeSingleton.GetInstance();
            ThreadSafeSingleton instance2 = ThreadSafeSingleton.GetInstance();

            /*
             ReferenceEquals confirms both references
             point to the same object.
            */
            Console.WriteLine(ReferenceEquals(instance1, instance2));
        }
    }
}
