using Dots.Standard.StateMachine;
using Dots.Standard.StateMachine.State;
using System;

namespace StateMachine
{
    /// <summary>
    /// This class is the thing that is responsible for persisting state changes to the database. In this case, it's just a dummy because
    /// we're not actually saving anything to the database. Ordinarily this would be a specialized DAL or similar object.
    /// Instead, it outputs a text snippet to Standard Output. 
    /// </summary>
    public class DummySaver : ISaveState<int>
    {
        public void Save(int recordID, BaseState<int> oldState, BaseState<int> newState, string user) =>
            Console.WriteLine($"State Transition. Record {recordID} has transitioned from {oldState.GetType()} to {newState.GetType()} initiated by {user}");
    }
}
