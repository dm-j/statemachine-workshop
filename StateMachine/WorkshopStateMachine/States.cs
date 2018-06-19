using Dots.Standard.StateMachine.State;
using System;

namespace StateMachine.WorkshopSM
{
    #region Base state

    /// <summary>
    /// This class is the base class for all the states we'll be creating for all the state machines
    /// in this Workshop. It hardcodes its generic parameter to
    /// an integer, because we'll be using integers to represent state IDs.
    /// 
    /// The State represents an aspect of the state some part of the system is in. For example, 
    /// in Tax Relief we have a Workflow State that reflects where the application is in the process, 
    /// from its inital state of In Progress all the way up to when it is finally Process Complete
    /// </summary>
    public abstract class WorkshopState : BaseState<int>
    {
        public WorkshopState(SM<int> stateMachine)
            : base(stateMachine) { }
    }

    #endregion Base state

    #region Door State

    // Abstract base states group together states of a certain type

    public abstract class DoorState : WorkshopState
    {
        public DoorState(Door door)
            : base(door) { }

        internal abstract void WalkThrough();
    }

    // This is where you put the new door states!

    public class Open : DoorState
    {
        public Open(Door door) 
            : base(door)
        {
            AddTransition<Closed>(Event.Close);
        }

        public override int ID => 1;

        internal override void WalkThrough() =>
            Console.WriteLine("I walked through.");
    }

    public class Closed : DoorState
    {
        public Closed(Door door)
            : base(door)
        {
            AddTransition<Open>(Event.Open);
        }

        public override int ID => 2;

        internal override void WalkThrough() =>
            Console.WriteLine("Ouch, I banged my nose!");
    }

    #endregion Door State
}
