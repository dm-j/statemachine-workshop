using Dots.Standard.StateMachine.State;
using StateMachine.WorkshopSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateMachineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door(1, "Console User").AddState<Closed>() as Door;

            SM<int> location = door;

            Console.WriteLine("Welcome to the State Machine Workshop.\n");

            while (true)
            {
                Console.WriteLine(door.Describe());
                Console.WriteLine("Please select an option");
                Console.WriteLine(((IEnumerable<int>)Enum.GetValues(typeof(Event))).Aggregate(new StringBuilder(), (curr, next) => curr.AppendLine($"{next}: {(Event)next}")));
                Console.Write("> ");
                string result = Console.ReadLine();
                Console.WriteLine();
                if (int.TryParse(result, out int choice))
                {
                    Console.WriteLine($"You selected {choice}\n");
                }
                else
                {
                    Console.WriteLine($"Invalid entry: {result}\n");
                }
            }
        }
    }
}
