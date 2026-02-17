using System;

namespace Designpatterns.Creational.Singleton
{
    /*
     ===============================================================
     EAGER INITIALIZATION SINGLETON
     ===============================================================

     Definition:
     The instance is created at the time of class loading,
     not when it is first requested.

     Important Characteristics:
     ✔ Thread-safe by default (because CLR handles static initialization)
     ✔ Simple implementation
     ✔ No locking required
     ✘ Instance is created even if never used

     This is one of the safest and cleanest Singleton
     implementations in C#.
     ===============================================================
    */

    /*
     sealed keyword:
     Prevents inheritance.

     Why important in Singleton?

     If another class inherits this class,
     it could potentially create another instance,
     breaking Singleton rule.

     So best practice in C#:
     Always mark Singleton class as sealed.
    */
    public sealed class Singleton
    {
        /*
         static readonly field:

         static:
             Belongs to class, not object.

         readonly:
             Can only be assigned once.
             Prevents accidental reassignment.

         Instance is created immediately
         when the class is loaded by CLR.

         This is called:
         Eager Initialization
        */
        private static readonly Singleton _instance = new Singleton();

        /*
         Private constructor prevents external instantiation.

         Nobody can call:
             new Singleton(); ❌

         Only this class itself can create instance.
        */
        private Singleton()
        {
            // Initialization logic can go here
        }

        /*
         Public static property to provide global access.

         Why property instead of method?
         In C#, property syntax is more idiomatic.

         Accessed like:
             Singleton.Instance
        */
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }

    /*
     ===============================================================
     DEMO CLASS
     ===============================================================
    */
    public class EagerSingletonDemo
    {
        public static void Run()
        {
            Singleton instance1 = Singleton.Instance;
            Singleton instance2 = Singleton.Instance;

            /*
             ReferenceEquals checks whether both references
             point to the same memory location.

             Output: True
             Because only one instance exists.
            */
            Console.WriteLine(ReferenceEquals(instance1, instance2));
        }
    }
}
