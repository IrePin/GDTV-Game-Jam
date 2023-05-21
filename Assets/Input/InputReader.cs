using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
    public class InputReader : ScriptableObject, MainControls.I_2DcontrolsActions, MainControls.IUIActions
    {
        private MainControls _mainControls;

        //public event Action InteractEvent;
        public event UnityAction<Vector2> MoveEvent = delegate { };
        

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
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {

        }
    }
    