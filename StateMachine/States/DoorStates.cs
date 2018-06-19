using Dots.Standard.StateMachine.State;
using System;

namespace StateMachine.WorkshopSM
{
    // Abstract base states group together states of a certain type

    public abstract class DoorState : BaseState<int>
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
}
