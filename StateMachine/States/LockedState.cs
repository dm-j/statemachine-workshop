using Dots.Standard.StateMachine.State;

namespace SM.WorkshopSM
{
    public abstract class LockedState : BaseState<int>
    {
        public DoorLock Lock => StateMachine<DoorLock>();

        public LockedState(DoorLock doorLock)
            : base(doorLock)
        { }
    }

    public class Locked : LockedState
    {
        public override int ID => 5462151;

        public Locked(DoorLock doorLock)
            : base(doorLock)
        {
            AddTransition<Unlocked>(Event.Unlock);
        }
    }

    public class Unlocked : LockedState
    {
        public override int ID => 1116131;

        public Unlocked(DoorLock doorLock)
            : base(doorLock)
        {
            AddTransition<Locked>(Event.Lock);
        }
    }
}
