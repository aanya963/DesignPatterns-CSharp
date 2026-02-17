// Step Builder (Advanced)
// Used when:
// Order of steps is mandatory
// Certain steps MUST happen

// Example:
// Pizza pizza = PizzaBuilder
//                 .Create()
//                 .WithSize("Large")
//                 .WithBase()
//                 .Build();
// Implemented using multiple interfaces.
// Each step returns next interface.
// User cannot skip steps.

namespace DesignPatterns.Creational.StepBuilder
{
    public class Computer
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public bool HasGraphicsCard { get; private set; }
        public bool HasBluetooth { get; private set; }

        private Computer() { }

        // STEP 1 Interface
        public interface ICPUStage
        {
            IRAMStage SetCPU(string cpu);
        }

        // STEP 2 Interface
        public interface IRAMStage
        {
            IStorageStage SetRAM(string ram);
        }

        // STEP 3 Interface
        public interface IStorageStage
        {
            IOptionalStage SetStorage(string storage);
        }

        // Optional stage
        public interface IOptionalStage
        {
            IOptionalStage AddGraphicsCard();
            IOptionalStage AddBluetooth();
            Computer Build();
        }

        // Concrete Builder implementing all steps
        private class Builder : ICPUStage, IRAMStage, IStorageStage, IOptionalStage
        {
            private Computer _computer = new Computer();

            public IRAMStage SetCPU(string cpu)
            {
                _computer.CPU = cpu;
                return this;
            }

            public IStorageStage SetRAM(string ram)
            {
                _computer.RAM = ram;
                return this;
            }

            public IOptionalStage SetStorage(string storage)
            {
                _computer.Storage = storage;
                return this;
            }

            public IOptionalStage AddGraphicsCard()
            {
                _computer.HasGraphicsCard = true;
                return this;
            }

            public IOptionalStage AddBluetooth()
            {
                _computer.HasBluetooth = true;
                return this;
            }

            public Computer Build()
            {
                return _computer;
            }
        }
        // Entry point
        public static ICPUStage CreateBuilder()
        {
            return new Builder();
        }
    }

    public class StepBuilderDemo
    {
        static public void Run(){
            var computer = Computer.CreateBuilder()
                        .SetCPU("Intel i7")
                        .SetRAM("16GB")
                        .SetStorage("512GB SSD")
                        .AddGraphicsCard()
                        .Build();
        }
    }
}