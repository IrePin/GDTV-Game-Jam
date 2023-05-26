//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/_DrRush/Input/MainControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainControls"",
    ""maps"": [
        {
            ""name"": ""2D controls"",
            ""id"": ""a78b4ac4-5923-424c-b859-544e7dbf7608"",
            ""actions"": [
                {
                    ""name"": ""Move2D"",
                    ""type"": ""Value"",
                    ""id"": ""e42a1f86-c2f7-4d51-a933-9fed5356409a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""70991223-4910-4428-9f73-ce6be0cb2d94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Climb"",
                    ""type"": ""Button"",
                    ""id"": ""851d2f52-c826-4022-9791-7958131b2e5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""dc031493-4efe-4e69-8ab5-5f426989ddce"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move2D"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb97a1be-de65-41ed-bad0-9f4961dd6ab9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""34db9685-91c0-480f-9b5d-bd23b06983ab"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move2D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d64f1390-4dcf-4e52-ba39-56dbd4c0896a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee66350a-fe1f-469c-b696-63dba9f0c35f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Climb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""3D controls"",
            ""id"": ""ea693390-9dd8-4d6b-a747-52d90442b527"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""ac75bb4e-bd36-4c80-8137-5205a24e39f9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""68fbae2a-0bd1-406c-916d-b4cf156a7942"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""97766348-72c7-4afe-a1e9-f2847e117592"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Move"",
                    ""id"": ""ac41e7ee-fc69-4339-92b4-b9f083ae924a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""89c0934b-1921-4ac2-a178-664ea9923e1c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""92b3ee1d-cca0-41ac-bab5-db8d23960150"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f1fd8f3-bd60-4e2b-86d4-f27facb3aa40"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8c382e22-29ba-40c5-ad3e-7a2b77d26008"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6442a99f-4526-45a5-962c-3f7630e94fef"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70a53d37-1b0f-4868-b418-5a00e8f8b658"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""4da05cab-e53f-492d-9fea-2b3e7e4f5643"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // 2D controls
        m__2Dcontrols = asset.FindActionMap("2D controls", throwIfNotFound: true);
        m__2Dcontrols_Move2D = m__2Dcontrols.FindAction("Move2D", throwIfNotFound: true);
        m__2Dcontrols_Interact = m__2Dcontrols.FindAction("Interact", throwIfNotFound: true);
        m__2Dcontrols_Climb = m__2Dcontrols.FindAction("Climb", throwIfNotFound: true);
        // 3D controls
        m__3Dcontrols = asset.FindActionMap("3D controls", throwIfNotFound: true);
        m__3Dcontrols_Movement = m__3Dcontrols.FindAction("Movement", throwIfNotFound: true);
        m__3Dcontrols_Shoot = m__3Dcontrols.FindAction("Shoot", throwIfNotFound: true);
        m__3Dcontrols_Look = m__3Dcontrols.FindAction("Look", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // 2D controls
    private readonly InputActionMap m__2Dcontrols;
    private List<I_2DcontrolsActions> m__2DcontrolsActionsCallbackInterfaces = new List<I_2DcontrolsActions>();
    private readonly InputAction m__2Dcontrols_Move2D;
    private readonly InputAction m__2Dcontrols_Interact;
    private readonly InputAction m__2Dcontrols_Climb;
    public struct _2DcontrolsActions
    {
        private @MainControls m_Wrapper;
        public _2DcontrolsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move2D => m_Wrapper.m__2Dcontrols_Move2D;
        public InputAction @Interact => m_Wrapper.m__2Dcontrols_Interact;
        public InputAction @Climb => m_Wrapper.m__2Dcontrols_Climb;
        public InputActionMap Get() { return m_Wrapper.m__2Dcontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_2DcontrolsActions set) { return set.Get(); }
        public void AddCallbacks(I_2DcontrolsActions instance)
        {
            if (instance == null || m_Wrapper.m__2DcontrolsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m__2DcontrolsActionsCallbackInterfaces.Add(instance);
            @Move2D.started += instance.OnMove2D;
            @Move2D.performed += instance.OnMove2D;
            @Move2D.canceled += instance.OnMove2D;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Climb.started += instance.OnClimb;
            @Climb.performed += instance.OnClimb;
            @Climb.canceled += instance.OnClimb;
        }

        private void UnregisterCallbacks(I_2DcontrolsActions instance)
        {
            @Move2D.started -= instance.OnMove2D;
            @Move2D.performed -= instance.OnMove2D;
            @Move2D.canceled -= instance.OnMove2D;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Climb.started -= instance.OnClimb;
            @Climb.performed -= instance.OnClimb;
            @Climb.canceled -= instance.OnClimb;
        }

        public void RemoveCallbacks(I_2DcontrolsActions instance)
        {
            if (m_Wrapper.m__2DcontrolsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(I_2DcontrolsActions instance)
        {
            foreach (var item in m_Wrapper.m__2DcontrolsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m__2DcontrolsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public _2DcontrolsActions @_2Dcontrols => new _2DcontrolsActions(this);

    // 3D controls
    private readonly InputActionMap m__3Dcontrols;
    private List<I_3DcontrolsActions> m__3DcontrolsActionsCallbackInterfaces = new List<I_3DcontrolsActions>();
    private readonly InputAction m__3Dcontrols_Movement;
    private readonly InputAction m__3Dcontrols_Shoot;
    private readonly InputAction m__3Dcontrols_Look;
    public struct _3DcontrolsActions
    {
        private @MainControls m_Wrapper;
        public _3DcontrolsActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m__3Dcontrols_Movement;
        public InputAction @Shoot => m_Wrapper.m__3Dcontrols_Shoot;
        public InputAction @Look => m_Wrapper.m__3Dcontrols_Look;
        public InputActionMap Get() { return m_Wrapper.m__3Dcontrols; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(_3DcontrolsActions set) { return set.Get(); }
        public void AddCallbacks(I_3DcontrolsActions instance)
        {
            if (instance == null || m_Wrapper.m__3DcontrolsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m__3DcontrolsActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
        }

        private void UnregisterCallbacks(I_3DcontrolsActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
        }

        public void RemoveCallbacks(I_3DcontrolsActions instance)
        {
            if (m_Wrapper.m__3DcontrolsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(I_3DcontrolsActions instance)
        {
            foreach (var item in m_Wrapper.m__3DcontrolsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m__3DcontrolsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public _3DcontrolsActions @_3Dcontrols => new _3DcontrolsActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    public struct UIActions
    {
        private @MainControls m_Wrapper;
        public UIActions(@MainControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface I_2DcontrolsActions
    {
        void OnMove2D(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnClimb(InputAction.CallbackContext context);
    }
    public interface I_3DcontrolsActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
    }
}
