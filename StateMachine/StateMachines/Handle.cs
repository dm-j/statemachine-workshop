using Dots.Standard.StateMachine.State;

namespace StateMachine.WorkshopStateMachine
{
    public class Handle : SM<int>
    {
        public Handle(int ID)
            : base()
        {
            this.ID = ID;
        }

        public void Turn() { }
        public void Release() { }
    }
}
