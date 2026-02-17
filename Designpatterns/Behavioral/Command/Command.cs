using System;

namespace DesignPatterns.Behavioral.CommandPattern
{
    /*
     Command pattern encapsulates a request as an object, allowing parameterization of clients, 
     undo functionality, and decoupling between invoker and receiver."

     ===============================================================
     COMMAND INTERFACE
     ===============================================================

     This defines the contract for all commands.
     Every command must implement:
        - Execute()
        - Undo()
    */
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    /*
     ===============================================================
     RECEIVERS
     ===============================================================

     These classes contain the actual business logic.
     They DO NOT know anything about commands.
    */

    public class Light
    {
        public void On()
        {
            Console.WriteLine("Light is ON");
        }

        public void Off()
        {
            Console.WriteLine("Light is OFF");
        }
    }

    public class Fan
    {
        public void On()
        {
            Console.WriteLine("Fan is ON");
        }

        public void Off()
        {
            Console.WriteLine("Fan is OFF");
        }
    }

    /*
     ===============================================================
     CONCRETE COMMAND FOR LIGHT
     ===============================================================

     This class wraps Light operations into a command.
     It stores reference to receiver (Light).
    */

    public class LightCommand : ICommand
    {
        private readonly Light _light;

        // Constructor injection of receiver
        public LightCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.On();
        }

        public void Undo()
        {
            _light.Off();
        }
    }

    /*
     ===============================================================
     CONCRETE COMMAND FOR FAN
     ===============================================================
    */

    public class FanCommand : ICommand
    {
        private readonly Fan _fan;

        public FanCommand(Fan fan)
        {
            _fan = fan;
        }

        public void Execute()
        {
            _fan.On();
        }

        public void Undo()
        {
            _fan.Off();
        }
    }

    /*
     ===============================================================
     INVOKER (Remote Controller)
     ===============================================================

     The Invoker does NOT know about Light or Fan.
     It only works with ICommand interface.

     It stores commands and triggers them.
    */

    public class RemoteController
    {
        private const int NumButtons = 4;

        private readonly ICommand[] _buttons = new ICommand[NumButtons];
        private readonly bool[] _buttonPressed = new bool[NumButtons];

        /*
         Assign command to button index.
        */
        public void SetCommand(int index, ICommand command)
        {
            if (index >= 0 && index < NumButtons)
            {
                _buttons[index] = command;
                _buttonPressed[index] = false;
            }
        }

        /*
         Toggle behavior:
         If button not pressed → Execute
         If already pressed → Undo
        */
        public void PressButton(int index)
        {
            if (index >= 0 && index < NumButtons && _buttons[index] != null)
            {
                if (!_buttonPressed[index])
                {
                    _buttons[index].Execute();
                }
                else
                {
                    _buttons[index].Undo();
                }

                _buttonPressed[index] = !_buttonPressed[index];
            }
            else
            {
                Console.WriteLine($"No command assigned at button {index}");
            }
        }
    }

    /*
     ===============================================================
     CLIENT (Entry Point)
     ===============================================================
    */

    public class CommandDemo
    {
        public static void Run()
        {
            // Create Receivers
            Light livingRoomLight = new Light();
            Fan ceilingFan = new Fan();

            // Create Invoker
            RemoteController remote = new RemoteController();

            // Assign commands
            remote.SetCommand(0, new LightCommand(livingRoomLight));
            remote.SetCommand(1, new FanCommand(ceilingFan));

            Console.WriteLine("--- Toggling Light Button 0 ---");
            remote.PressButton(0);  // ON
            remote.PressButton(0);  // OFF

            Console.WriteLine("--- Toggling Fan Button 1 ---");
            remote.PressButton(1);  // ON
            remote.PressButton(1);  // OFF

            Console.WriteLine("--- Pressing Unassigned Button 2 ---");
            remote.PressButton(2);
        }
    }
}
