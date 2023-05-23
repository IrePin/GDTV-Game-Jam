using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputReader : MonoBehaviour, MainControls.I_2DcontrolsActions, MainControls.IUIActions
    {
        public bool IsAttacking { get; private set; }
        public bool IsBlocking { get; private set; }

        private MainControls _mainControls;

        public Vector2 MovementValue { get; private set; }
        public event Action ClimbEvent;


        private void OnEnable()
        {
            if (_mainControls == null)
            {
                _mainControls = new MainControls();
                _mainControls._2Dcontrols.SetCallbacks(this);
                _mainControls.UI.SetCallbacks(this);
            }

            Set2Dcontrols();
        }

        public void Set2Dcontrols()
        {
            _mainControls._2Dcontrols.Enable();
            _mainControls.UI.Disable();
        }

        public void OnMove2D(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {

        }

        public void OnClimb(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }
            
            ClimbEvent?.Invoke();
        }
    }
}
   