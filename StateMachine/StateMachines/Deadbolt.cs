using Dots.Standard.StateMachine.State;
using System.Linq;

namespace SM.WorkshopSM
{
    public class Deadbolt : SM<int>
    {
        public Deadbolt(int ID)
            : base(ID) { }

        public DeadboltLockState Locked =>
            State<DeadboltLockState>().Single();

        public Door Door => Parent<Door>();

        public void Lock() =>
            Send(Event.Lock);

        public void Unlock() =>
            Send(Event.Unlock);

        public bool IsLocked => Locked is Locked;
    }
}
