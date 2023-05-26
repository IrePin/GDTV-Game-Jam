using System;
using _DrRush.Input;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using UnityEngine;
using UnityEngine.Events;

namespace _DrRush.Scripts.Runtime.Mini.View
{
    //  Namespace Properties ------------------------------
    public class OnInputUnityEvent : UnityEvent<Vector3> {}
    
    //  Class Attributes ----------------------------------

    /// <summary>
    /// The View handles user interface and user input
    /// </summary>
    public class InputView: MonoBehaviour, IView
    {
     
        //  Events ----------------------------------------
        [HideInInspector] 
        public readonly OnInputUnityEvent OnInput = new OnInputUnityEvent();
       

        [field: Header("Components")]
        //  Input ----------------------------------------
        [field: SerializeField] public InputReader inputReader { get; private set; }
        
        [NonSerialized] public static Vector2 MoveDirection;
        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        private IContext _context;
   
        
        //  Initialization  -------------------------------
       public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;
            }

        }

        public void RequireIsInitialized()
        {
            if (!IsInitialized)
            {
                throw new Exception("MustBeInitialized");
            }
        }

        //  Unity Methods ---------------------------------
        protected void Update()
        {
            if (!IsInitialized)
            {
                return;
            }
            float moveHorizontal = inputReader.MovementValue.x * Time.deltaTime;
            float moveVertical = inputReader.MovementValue.y * Time.deltaTime;
            Vector3 movementVector = new Vector3 (moveHorizontal, 0.0f, moveVertical);
            Vector3 normalizedMovementVector = movementVector.normalized;
            
            OnInput.Invoke(normalizedMovementVector);
            MoveDirection = inputReader.MovementValue;
            //Debug.Log(inputReader.MovementValue);
        }

        //  Methods ---------------------------------------
        
        //  Event Handlers --------------------------------

    }
}