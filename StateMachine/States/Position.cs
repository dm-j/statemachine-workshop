using Dots.Standard.StateMachine.State;
using System;

namespace StateMachine.WorkshopSM
{
    // Abstract base states group together states of a certain type

    public abstract class Position : BaseState<int>
    {
        // Each state needs a reference to the state machine
        // that owns it, so it can communicate with the rest
        // of the tree.
        public Position(Door door)
            : base(door)
        {
            // Transitions and OnEntry/Exit/Awake go in the 
            // state constructors

            // You can put them here too, but they will
            // be inherited by _every_ state which inherits
            // from this type
        }

        // This is an action the state machine can perform on
        // behalf of its owning state machine. This can be
        // abstract, if you want each state to implement it
        // itself, or you can make it virtual to provide a
        // default action that individual states could choose
        // to override
        internal abstract void WalkThrough();
    }

    // This is where you put the new door states!

    public class Open : Position
    {
        public override int ID => 651035310;

        public Open(Door door) 
            : base(door)
        {
            // Transitions
            AddTransition<Closed>(Event.Close);

            // OnEntry
            OnEntry(Broadcast(Event.DoorHasOpened));

            // OnExit

            // OnAwake
        }

        // Actions
        internal override void WalkThrough() =>
            Console.WriteLine("I walked through.");
    }

    public class Closed : Position
    {
        public override int ID => 65651321;

        public Closed(Door door)
            : base(door)
        {
            // Transitions
            AddTransition<Open>(Event.Open);

            // OnEntry

            // OnExit

            // OnAwake
        }

        // Actions
        internal override void WalkThrough() =>
            Console.WriteLine("Ouch, I banged my nose!");
    }
}
