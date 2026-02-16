namespace Designpatterns.Structural.Facade
{
// Subsystem Classes:

// Each of these classes represents a complex part of a computer.
// Normally, the client would have to call them in the correct order.
    
    public class PowerSupply
    {
        public void ProvidePower()
        {
            Console.WriteLine("Power supply: Providing power....");
        }
    }
    public class CoolingSystem
    {
        public void StartFans()
        {
            Console.WriteLine("Cooling system: Fans started...");
        }
    }
    public class CPU
    {
        public void Initialise()
        {
            Console.WriteLine("CPU: Initialization started");
        }
    }
    public class Memory
    {
        public void SelfTest()
        {
            Console.WriteLine("Memory: Self-test passed...");
        }
    }


    public class HardDrive
    {
        public void SpinUp()
        {
            Console.WriteLine("Hard Drive: Spinning up...");
        }
    }

    public class BIOS
    {
        // BIOS coordinates CPU and Memory checks
        public void Boot(CPU cpu, Memory memory)
        {
            Console.WriteLine("BIOS: Booting CPU and Memory checks...");
            cpu.Initialise();      // Initialize CPU
            memory.SelfTest();     // Run memory self-test
        }
    }

    public class OperatingSystem
    {
        public void Load()
        {
            Console.WriteLine("Operating System: Loading into memory...");
        }
    }

    //- - - - FACADE CLASS - - - - //
    public class ComputerFacade
    {
        // The facade contains references to all subsystem components
        private PowerSupply _powerSupply;
        private CoolingSystem _coolingSystem;
        private CPU _cpu;
        private Memory _memory;
        private HardDrive _hardDrive;
        private BIOS _bios;
        private OperatingSystem _os;

        //Constructor initializes all subsystem objects
        public ComputerFacade()
        {
            _powerSupply = new PowerSupply();
            _coolingSystem = new CoolingSystem();
            _cpu = new CPU();
            _memory = new Memory();
            _hardDrive = new HardDrive();
            _bios = new BIOS();
            _os = new OperatingSystem();
        }
        // This is the simplified method exposed to the client.
        // Instead of calling 6–7 different classes,
        // the client only calls StartComputer().
        public void StartComputer()
        {
            Console.WriteLine("----- Starting Computer -----");

            // Step 1: Power on
            _powerSupply.ProvidePower();

            // Step 2: Start cooling system
            _coolingSystem.StartFans();

            // Step 3: BIOS boot process (CPU + Memory)
            _bios.Boot(_cpu, _memory);

            // Step 4: Spin up hard drive
            _hardDrive.SpinUp();

            // Step 5: Load operating system
            _os.Load();

            Console.WriteLine("Computer Booted Successfully!");
        }
    }
    // - - - - - - - - Client Code - - - - - - 
    public class FacadeDemo()
    {
        public static void Run()
        {
            // Client does NOT deal with CPU, BIOS, Memory, etc.
            // It only interacts with the Facade.

            ComputerFacade computer = new ComputerFacade();
            computer.StartComputer();

        }
    }

}