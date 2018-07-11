﻿using Dots.Standard.StateMachine.State;

namespace StateMachine.WorkshopSM
{
    /// <summary>
    /// This is a state machine with no states.
    /// The states will be added in the workshop.
    /// </summary>
    public class Handle : SM<int>
    {
        public Handle(int ID)
            : base(ID) { }

        #region Components

        public Door Door => 
            Parent<Door>();

        #endregion Components

        #region Actions

        public void Turn()
        {
            // Turn code goes here
        }

        public void Release()
        {
            // Release code goes here
        }

        #endregion Actions

        #region Attributes

        // public bool IsTurned => ?

        #endregion Attributes
    }
}
