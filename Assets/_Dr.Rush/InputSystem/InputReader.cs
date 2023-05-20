
using System;
using _Dr.Rush;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, MainControls.I_2DcontrolsActions, MainControls.IUIActions
{
    private MainControls _mainControls;

    public event Action<Vector2> MoveEvent;
    public event Action InteractEvent;

    private void OnEnable()
    {
        if (_mainControls == null)
        {
            _mainControls = new MainControls();
            _mainControls._2Dcontrols.SetCallbacks(this);
            //_mainControls._3Dcontrols.SetCallbacks(this);
            _mainControls.UI.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        throw new NotImplementedException();
    }

    public void OnMove2D(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
