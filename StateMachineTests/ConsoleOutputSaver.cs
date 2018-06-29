using Dots.Standard.StateMachine;
using Dots.Standard.StateMachine.State;
using System;

namespace StateMachineTests
{
    /// <summary>
    /// This class is the thing that is responsible for persisting state changes to the database. In this case, it's just a dummy because
    /// we're not actually saving anything to the database. Ordinarily this would be a specialized DAL or similar object.
    /// Instead, it outputs a text snippet to Standard Output. 
    /// </summary>
    public class ConsoleOutputSaver : ISaveState<int>
    {
        public void Save(SM<int> record, BaseState<int> oldState, BaseState<int> newState, string user) =>
            Console.WriteLine($"{record.GetType().Name} {record.ID} {oldState.GetType().BaseType.Name} has transitioned from {oldState.GetType().Name} to {newState.GetType().Name}, initiated by user \"{user}\"");
    }
}
