using System;
using _DrRush;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

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

        [SerializeField] private InputReader inputReader;
        
        private Vector2 _moveDirection;
        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        private IContext _context;

        //  Initialization  -------------------------------

        private void OnEnable()
        {
            inputReader.MoveEvent += HandleMove;
        }

        private void OnDisable()
        {
            inputReader.MoveEvent -= HandleMove;
        }

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

        private void Start()
        {
            
            Debug.Log("start");
        }

        //  Unity Methods ---------------------------------
        protected void Update()
        {
            if (!IsInitialized)
            {
                return;
            }

            float moveHorizontal = _moveDirection.x * Time.deltaTime;
            Vector3 movement = new Vector3 (moveHorizontal, 0f, 0);

            OnInput.Invoke(movement);
            Debug.Log(IsInitialized);
        }
        
        
          private void HandleMove(Vector2 dir)
                {
                    _moveDirection = dir;
                }

          
        //  Methods ---------------------------------------
        
        
        //  Event Handlers --------------------------------

    }
}