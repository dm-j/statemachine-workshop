using Dots.Standard.StateMachine;
using Dots.Standard.StateMachine.State;
using System.Linq;

namespace StateMachine.WorkshopSM
{
    // Your state machines go here

    // A Door contains one state, which is DoorState, and you can try to 
    // WalkThrough the door.

    public class Door : RootStateMachine<int>
    {
        public Door(int ID, ISaveState<int> save, string user)
            : base(ID, save, user) { }

        // Components are all the states the state machine contains,
        // and its neighbor state machines in the hierarchy (parent
        // and children, although this Door is a root state machine
        // so it cannot have a parent).
        #region Components

        internal Position Position => 
            State<Position>().Single();

        #endregion

        // Actions are the state machine's interface with the rest of
        // your code. Some actions will be resolved by the state machine
        // itself (such as Open, which broadcasts the Open Event to the
        // entire state hierarchy) or delegated to component states (like
        // WalkThrough, which is resolved by the DoorState instead of the
        // Door itself.
        #region Actions

        public void Open() =>
            Broadcast(Event.Open);

        public void Close() =>
            Broadcast(Event.Close);

        public void WalkThrough() =>
            Position.WalkThrough();

        #endregion

        // Attributes are public information about the state machine that
        // you might care about elsewhere, either in the state machine
        // or in the rest of your code. If you need to check to see if
        // this Door can be walked through (for UI or something) you can
        // use its IsOpen attribute.
        #region Attributes

        public bool IsOpen => 
            Position is Open;

        #endregion
    }
}
