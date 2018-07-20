using Dots.Standard.StateMachine.State;

namespace SM.WorkshopSM
{
    public abstract class LockedState : BaseState<int>
    {
        public Deadbolt Lock => StateMachine<Deadbolt>();

        public LockedState(Deadbolt doorLock)
            : base(doorLock)
        { }
    }

    public class Locked : LockedState
    {
        public override int ID => 5462151;

        public Locked(Deadbolt doorLock)
            : base(doorLock)
        {
            AddTransition<Unlocked>(Event.Unlock);
        }
    }

    public class Unlocked : LockedState
    {
        public override int ID => 1116131;

        public Unlocked(Deadbolt doorLock)
            : base(doorLock)
        {
            AddTransition<Locked>(Event.Lock);
        }
    }
}
