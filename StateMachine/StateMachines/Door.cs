using Dots.Standard.StateMachine;
using Dots.Standard.StateMachine.State;
using System.Linq;

namespace SM.WorkshopSM
{
    public class Door : RootStateMachine<int>
    {
        public Door(int ID, ISaveState<int> save, string user)
            : base(ID, save, user) { }

        // States
        public Position Position => 
            State<Position>().Single();

        // State Machines
        public DoorLock Lock =>
            Child<DoorLock>().Single();

        // Actions
        public void Open() =>
            Broadcast(Event.Open);

        public void Close() =>
            Broadcast(Event.Close);

        public void WalkThrough() =>
            Position.WalkThrough();

        // Attributes
        public bool IsOpen => 
            Position is Open;
    }
}
