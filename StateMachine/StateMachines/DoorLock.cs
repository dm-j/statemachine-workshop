using Dots.Standard.StateMachine.State;
using System.Linq;

namespace SM.WorkshopSM
{
    public class DoorLock : SM<int>
    {
        public DoorLock(int ID)
            : base(ID) { }

        public LockedState Locked =>
            State<LockedState>().Single();

        public Door Door => Parent<Door>();

        public void Lock() =>
            Send(Event.Lock);

        public void Unlock() =>
            Send(Event.Unlock);

        public bool IsLocked => Locked is Locked;
    }
}
