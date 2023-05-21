using System;
using _DrRush.Scripts.Runtime.Components;
using _DrRush.Scripts.Runtime.Mini.Controller.Commands;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using UnityEngine;
using UnityEngine.Events;

namespace _DrRush.Scripts.Runtime.Mini.View
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------
    public class PickupUnityEvent : UnityEvent<PickupComponent> {}

    /// <summary>
    /// The View handles user interface and user input
    /// </summary>
    public class PlayerView: MonoBehaviour, IView
    {
        //  Events ----------------------------------------
        [HideInInspector] 
        public readonly PickupUnityEvent OnPickup = new PickupUnityEvent();

        
        //  Properties ------------------------------------
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        
        //  Fields ----------------------------------------
        private bool _isInitialized = false;
        private IContext _context;

        [SerializeField] 
        private Rigidbody _rigidBody;
        
        [SerializeField] 
        private float _speed = 500;


        private void Update()
        {
            //Debug.Log(IsInitialized ? "player is initialized" : "player is pidor");
        }

        //  Initialization  -------------------------------
        public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;
                
                Context.CommandManager.AddCommandListener<InputCommand>(
                    OnInputCommand);
            }

            _rigidBody.useGravity = true;
        }

        public void RequireIsInitialized()
        {
            if (!IsInitialized)
            {
                throw new Exception("MustBeInitialized");
            }
        }
        
        
        //  Unity Methods ---------------------------------
        protected void OnTriggerEnter(Collider myCollider) 
        {
            RequireIsInitialized();

            // Did I collide with the correct object?
            PickupComponent pickupComponent = myCollider.gameObject.GetComponent<PickupComponent>();
            if (pickupComponent != null)
            {
                OnPickup.Invoke(pickupComponent);
                
            }
        }
        protected void OnDisable()
        {
            Context?.CommandManager?.RemoveCommandListener<InputCommand>(
                OnInputCommand);
        }

        //  Methods ---------------------------------------
        
        
        //  Event Handlers --------------------------------
        private void OnInputCommand(InputCommand inputCommand)
        {
            RequireIsInitialized();
            
            _rigidBody.velocity = (inputCommand.Value * _speed);
            Debug.Log(_rigidBody.velocity);
        }
    }
}