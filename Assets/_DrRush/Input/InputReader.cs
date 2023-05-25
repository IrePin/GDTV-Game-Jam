using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Input
{
    public class InputReader : MonoBehaviour, MainControls.I_2DcontrolsActions, MainControls.IUIActions, MainControls.I_3DcontrolsActions
    {
        private MainControls _mainControls;

        public Vector2 MovementValue { get; private set; }
        public Vector2 look { get; private set; }
        
        public event Action ClimbEvent;
        public event Action ShootEvent;


        private void OnEnable()
        {
            if (_mainControls == null)
            {
                _mainControls = new MainControls();
                _mainControls._2Dcontrols.SetCallbacks(this);
                _mainControls._3Dcontrols.SetCallbacks(this);
                _mainControls.UI.SetCallbacks(this);
            }
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "MadHospital")
            {
                Set2Dcontrols();
                Debug.Log("platform controls enabled");
            }
            else if (currentScene.name == "ShooterScene")
            {
                Set3Dcontrols();
                Debug.Log("shooter controls enabled");
            }else if (currentScene.name == "MainMenu")
            {
                SetUI();
                Debug.Log("UI enabled");
            }
        }

        public void Set2Dcontrols()
        {
            _mainControls._2Dcontrols.Enable();
            _mainControls._3Dcontrols.Disable();
            _mainControls.UI.Disable();
        }
        
        public void Set3Dcontrols()
        {
            _mainControls._2Dcontrols.Disable();
            _mainControls._3Dcontrols.Enable();
            _mainControls.UI.Disable();
        }
        
        public void SetUI()
        {
            _mainControls._2Dcontrols.Disable();
            _mainControls._3Dcontrols.Disable();
            _mainControls.UI.Enable();
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

        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            if (!context.performed) { return; }
            
            ShootEvent?.Invoke();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            look = context.ReadValue<Vector2>();
        }
    }
}
   