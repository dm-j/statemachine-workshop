using Dots.Standard.StateMachine.State;
using StateMachine.WorkshopSM;

namespace StateMachine.WorkshopStateMachine
{
    /// <summary>
    /// This is a set of states with no state machine.
    /// The state machine will be added in the workshop.
    /// </summary>
    public abstract class PadlockState : BaseState<int>
    {
        public PadlockState(Door door)
            : base(door)
        {
            // Transitions and OnEntry/Exit/Awake go in the 
            // state constructors

            // You can put them here too, but they will
            // be inherited by _every_ state which inherits
            // from this type
        }
    }

    public class Locked : PadlockState
    {
        public override int ID => 5462151;

        public Locked(Door door)
            : base(door)
        {
            // Transitions
            AddTransition<Unlocked>(Event.Unlock);

            // OnEntry

            // OnExit

            //OnAwake
        }
    }

    public class Unlocked : PadlockState
    {
        public override int ID => 1116131;

        public Unlocked(Door door)
            : base(door)
        {
            // Transitions
            AddTransition<Locked>(Event.Lock);

            // OnEntry

            // OnExit

            // OnAwake
        }
    }
}
