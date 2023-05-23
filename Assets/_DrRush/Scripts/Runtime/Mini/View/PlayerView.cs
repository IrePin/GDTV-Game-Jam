using System;
using System.Collections;
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
        
        [field: SerializeField] public LedgeDetector LedgeDetector { get; private set; }
        
        //  Fields ----------------------------------------
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterController characterController;
        private bool _onLedge;
        private bool _isInitialized = false;
        private IContext _context;
        private Vector2 _currentAnimationBlendVector;
        private Vector2 _animationVelocity;
        private readonly Vector3 Offset = new Vector3(0f, 2.325f, 0.65f);
        private Vector3 ledgeForward;
        private Vector3 closestPoint;
        [SerializeField] 
        private float speed = 10;

        private float _velocityY;
        private Vector3 _movement;
        private float _rotationDamping;
        
        [Header("GroundCheck")]
        public float gravity = -9.81f;
        public Vector3 velocity;
        

        
        // Anim Id`s
        public int HorizontalInputID { get; private set; }
        public int IsGroundID { get; private set; }
        public int RunID { get; private set; }
        
        

        //  Initialization  -------------------------------
        public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;
                
                Context.CommandManager.AddCommandListener<InputCommand>(
                    OnInputCommand);
                LedgeDetector.OnLedgeDetect += OnLedge;
            }
        }

        private void OnLedge(Vector3 ledgeForward, Vector3 closestPoint)
        {
            
            StartCoroutine(ClimbCoroutine(closestPoint));
           
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

        private void FixedUpdate()
        {
            _movement = transform.position;
            RotateCharacter(_movement);
            AnimationsID();
            HandleGravity();
            HandleAnimator();
        }
        protected void OnDisable()
        {
            Context?.CommandManager?.RemoveCommandListener<InputCommand>(
                OnInputCommand);
            LedgeDetector.OnLedgeDetect -= OnLedge;
            
        }

        //  Event Handlers --------------------------------
        private void OnInputCommand(InputCommand inputCommand)
        {
            RequireIsInitialized();

            Vector3 movement = transform.TransformDirection(inputCommand.Value);
            characterController.Move(movement * Time.deltaTime * speed);
        }
        //  Methods ---------------------------------------
        private void AnimationsID()
        {
            HorizontalInputID = Animator.StringToHash("VelocityX");
            IsGroundID = Animator.StringToHash("IsGrounded");
            RunID = Animator.StringToHash("Run");
        }
        private bool IsGrounded(CharacterController characterController)
        {
            return Physics.Raycast(characterController.transform.position + Vector3.up * 0.1f, 
                -Vector3.up, 
                characterController.height / 1.8f + 0.1f);
        }
        private void HandleGravity()
        {
            if (IsGrounded(characterController))
            {
                velocity.y = -2f;
                animator.SetBool(IsGroundID, true);
            }
            else if(!IsGrounded(characterController))
            {
                animator.SetBool(IsGroundID, false);
                velocity.y += gravity * Time.deltaTime;
            }

            characterController.Move(velocity * Time.deltaTime);
        }
        private void HandleAnimator()
        {
            bool isInputReceived = InputView.MoveDirection.x  != 0f || InputView.MoveDirection.y  != 0f;

            animator.SetBool(RunID, isInputReceived);

            if (isInputReceived)
            {
                _currentAnimationBlendVector = Vector2.SmoothDamp(_currentAnimationBlendVector, InputView.MoveDirection,
                    ref _animationVelocity, 0.1f);
                animator.SetFloat(HorizontalInputID, _currentAnimationBlendVector.x);
            }
            else
            {
                _currentAnimationBlendVector = Vector2.SmoothDamp(_currentAnimationBlendVector, new Vector2(0, 0),
                    ref _animationVelocity, 0.1f);
                animator.SetFloat(HorizontalInputID, _currentAnimationBlendVector.x);
            }
        }
        private void RotateCharacter(Vector3 movement)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * _rotationDamping);
        }
        IEnumerator ClimbCoroutine(Vector3 closestPoint)
        {
            characterController.enabled = false;
            animator.SetFloat("VelocityX", 0);
            transform.position = closestPoint - (LedgeDetector.transform.position - transform.position);
            animator.SetBool("OnLedge", true);
            yield return new WaitForSeconds(3);
            Debug.Log(closestPoint);
            transform.position = closestPoint;
            animator.SetBool("OnLedge", false);
            characterController.enabled = true;
        }
    }
}