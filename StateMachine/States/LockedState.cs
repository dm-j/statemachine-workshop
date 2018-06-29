using Dots.Standard.StateMachine.State;

namespace StateMachine.WorkshopSM
{
    /// <summary>
    /// This is a set of states with no state machine.
    /// The state machine will be added in the workshop.
    /// </summary>
    public abstract class LockedState : BaseState<int>
    {
        public LockedState(Door door)
            : base(door)
        {
            // Transitions and OnEntry/Exit/Awake go in the 
            // state constructors

            // You can put them here too, but they will
            // be inherited by _every_ state which inherits
            // from this type
        }

        // Actions
    }

    public class Locked : LockedState
    {
        public override int ID => 5462151;

        public Locked(Door door)
            : base(door)
        {
            // Transitions

            // OnEntry

            // OnExit

            //OnAwake
        }
    }

    public class Unlocked : LockedState
    {
        public override int ID => 1116131;

        public Unlocked(Door door)
            : base(door)
        {
            // Transitions

            // OnEntry

            // OnExit

            // OnAwake
        }
    }
}
