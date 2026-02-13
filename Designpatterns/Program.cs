using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Singleton;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide pattern name.");
            return;
        }

        switch (args[0].ToLower())
        {
            case "singleton":
                SingletonDemo.Run();
                break;
            case "strategy":
                StrategyDemo.Run();
                break;
            case "factory":
                FactoryDemo.Run();
                break;
            
            default:
                Console.WriteLine("Pattern not found.");
                break;
        }
    }
}

