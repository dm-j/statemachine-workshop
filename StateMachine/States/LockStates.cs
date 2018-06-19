using Dots.Standard.StateMachine.State;
using StateMachine.WorkshopSM;

namespace StateMachine.WorkshopStateMachine
{
    public abstract class LockState : BaseState<int>
    {
        public LockState(Door door)
            : base(door) { }
    }

    public class Locked : LockState
    {
        public override int ID => 11;

        public Locked(Door door)
            : base(door)
        {
            AddTransition<Unlocked>(Event.Unlock);
        }
    }

    public class Unlocked : LockState
    {
        public override int ID => 22;

        public Unlocked(Door door)
            : base(door)
        {
            AddTransition<Locked>(Event.Lock);
        }
    }
}
