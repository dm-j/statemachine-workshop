using Dots.Standard.StateMachine.State;
using System;

namespace SM.WorkshopSM
{
    public abstract class Position : BaseState<int>
    {
        public Door Door => StateMachine<Door>();

        public Position(Door door)
            : base(door)
        { }

        internal abstract void WalkThrough();
    }

    public class Open : Position
    {
        public override int ID => 651035310;

        public Open(Door door) 
            : base(door)
        {
            AddTransition<Closed>(Event.Close);
        }

        internal override void WalkThrough() =>
            Console.WriteLine("I walked through.");
    }

    public class Closed : Position
    {
        public override int ID => 65651321;

        public Closed(Door door)
            : base(door)
        {
            AddTransition<Open>(Event.Open, () => !Door.Lock.IsLocked);
        }
        
        internal override void WalkThrough() =>
            Console.WriteLine("Ouch, I banged my nose!");
    }
}
