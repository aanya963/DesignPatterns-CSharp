//Fluent Builder (without Director)
//Instead of void methods, return this.
// Structure:
// ~ Product
// ~ Builder
// ~ No Director
// ~ Method chaining: new PizzaBuilder()
//                      .SetSize("Large")
//                      .AddCheese()
//                      .Build();

// Each method returns this
// Client controls construction
// Very readable
// Most common in C#.

//- - - - - - - DEFINITION - - - - - - - - - 
// “This is the Builder Design Pattern using the Fluent Builder variant.
// It allows step-by-step object construction using method chaining, without a Director.
// The client controls the construction process, and Build() returns the final immutable object.”

namespace DesignPatterns.Creational.FluentBuilder
{
    public class Computer
    {
        // Properties are read-only from outside
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }
        public bool HasGraphicsCard { get; private set; }
        public bool HasBluetooth { get; private set; }


        // Private constructor prevents direct object creation
        private Computer() { }

        // Nested Builder class
        public class Builder
        {
            private Computer _computer = new Computer();

            // Required field
            public Builder SetCPU(string cpu)
            {
                _computer.CPU = cpu;
                return this;  // Enables method chaining
            }

            public Builder SetRAM(string ram)
            {
                _computer.RAM = ram;
                return this;
            }
            public Builder SetStorage(string storage)
            {
                _computer.Storage = storage;
                return this;
            }

            // Optional fields
            public Builder AddGraphicsCard()
            {
                _computer.HasGraphicsCard = true;
                return this;
            }

            public Builder AddBluetooth()
            {
                _computer.HasBluetooth = true;
                return this;
            }

            // Final step
            public Computer Build()
            {
                // Validation for required fields
                if (string.IsNullOrEmpty(_computer.CPU))
                    throw new Exception("CPU is required!");

                if (string.IsNullOrEmpty(_computer.RAM))
                    throw new Exception("RAM is required!");

                if (string.IsNullOrEmpty(_computer.Storage))
                    throw new Exception("Storage is required!");

                return _computer;
            }
        }

    }

    public class FluentBuilderDemo
    {
        static public void Run()
        {
            var computer = new Computer.Builder()
                            .SetCPU("Intel i9")
                            .SetRAM("32GB")
                            .SetStorage("1TB SSD")
                            .AddGraphicsCard()
                            .Build();
            //new Computer.Builder() creates builder
            // Each method sets part of object
            // return this allows chaining
            // Build() validates and returns final object
        }
    }

}