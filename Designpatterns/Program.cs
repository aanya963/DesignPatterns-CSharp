using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Creational.Factory;
using Designpatterns.Creational.Singleton;
using System.Runtime.InteropServices;
using DesignPatterns.Behavioral.Observer;
using DesignPatterns.Structural;
class Program
{
    public static object SingletonDemo { get; private set; }

    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide pattern name.");
            return;
        }

        switch (args[0].ToLower())
        {
            case "basicsingleton":
                BasicSingletonDemo.Run();
                break;
            case "eagersingleton":
                EagerSingletonDemo.Run();
                break;
            case "lazysingleton":
                LazySingletonDemo.Run();
                break;  
            case "threadsafesingleton":
                ThreadSafeSingletonDemo.Run();
                break;
            case "strategy":
                StrategyDemo.Run();
                break;
            case "factory":
                FactoryDemo.Run();
                break;
            case "observer":
                ObserverDemo.Run();
                break;
            case "decorator":
                DecoratorDemo.Run();
                break;
            default:
                Console.WriteLine("Pattern not found.");
                break;
        }
    }
}

