using Dots.Standard.StateMachine.State;

namespace SM.WorkshopSM
{
    public abstract class DeadboltLockState : BaseState<int>
    {
        public DeadboltLockState(Deadbolt deadbolt)
            : base(deadbolt)
        { }
    }

    public class Locked : DeadboltLockState
    {
        public override int ID => 5462151;

        public Locked(Deadbolt deadbolt)
            : base(deadbolt)
        {
            AddTransition<Unlocked>(Event.Unlock);
        }
    }

    public class Unlocked : DeadboltLockState
    {
        public override int ID => 1116131;

        public Unlocked(Deadbolt deadbolt)
            : base(deadbolt)
        {
            AddTransition<Locked>(Event.Lock);
        }
    }
}
