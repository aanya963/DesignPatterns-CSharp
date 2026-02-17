// Classic Builder has 4 parts:
// 1. Product
// 2. Builder Interface
// 3. Concrete Builder
// 4. Director (Optional)
// ❓ Why is Director Optional?
// Modern C# often skips Director.

namespace DesignPatterns.Creational.Builder
{
    // 🔹 Step 1: Product
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string Storage { get; set; }
        public bool HasGraphicsCard { get; set; }
        public bool HasBluetooth { get; set; }

        public void ShowSpecifications()
        {
            Console.WriteLine("Computer Specifications:");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"RAM: {RAM}");
            Console.WriteLine($"Storage: {Storage}");
            Console.WriteLine($"Graphics Card: {HasGraphicsCard}");
            Console.WriteLine($"Bluetooth: {HasBluetooth}");
        }
    }
    // 🔹 Step 2: Builder Interface
    // Class that builds product step by step
    public interface IComputerBuilder
    {
        void SetCPU(string cpu);
        void SetRAM(string ram);
        void SetStorage(string storage);
        void AddGraphicsCard();
        void AddBluetooth();
        Computer GetComputer();
    }
    //🔹 Step 3: Concrete Builder
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU(string cpu)
        {
            _computer.CPU = cpu;
        }

        public void SetRAM(string ram)
        {
            _computer.RAM = ram;
        }

        public void SetStorage(string storage)
        {
            _computer.Storage = storage;
        }

        public void AddGraphicsCard()
        {
            _computer.HasGraphicsCard = true;
        }

        public void AddBluetooth()
        {
            _computer.HasBluetooth = true;
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
    // 🔹 Step 4: Director (Optional but Interview Important)
    public class ComputerDirector
    {
        public void BuildGamingComputer(IComputerBuilder builder)
        {
            builder.SetCPU("Intel i9");
            builder.SetRAM("32GB");
            builder.SetStorage("1TB SSD");
            builder.AddGraphicsCard();
            builder.AddBluetooth();
        }

        public void BuildOfficeComputer(IComputerBuilder builder)
        {
            builder.SetCPU("Intel i5");
            builder.SetRAM("16GB");
            builder.SetStorage("512GB SSD");
            builder.AddBluetooth();
        }
    }
    public class ClassicBuilderDemo
    {
        public static void Run()
        {
            IComputerBuilder builder = new GamingComputerBuilder();
            ComputerDirector director = new ComputerDirector();

            director.BuildGamingComputer(builder);

            Computer computer = builder.GetComputer();
            computer.ShowSpecifications();
        }
    }
}