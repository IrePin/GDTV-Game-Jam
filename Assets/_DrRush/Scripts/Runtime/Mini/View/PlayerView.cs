using System;
using System.Collections;
using _DrRush.Scripts.Runtime.Components;
using _DrRush.Scripts.Runtime.Mini.Controller.Commands;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace _DrRush.Scripts.Runtime.Mini.View
{
    //  Namespace Properties ------------------------------

    //  Class Attributes ----------------------------------
    //public class PickupUnityEvent : UnityEvent<PickupComponent> {}

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
        [field: SerializeField] public InputView InputView { get; private set; }
        
        //  Fields ----------------------------------------
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private GameObject lights;
        private bool _onLedge;
        private bool _isInitialized = false;
        private IContext _context;
        private Vector2 _currentAnimationBlendVector;
        private Vector2 _animationVelocity;
        private readonly Vector3 Offset = new Vector3(0f, 2.325f, 0.65f);
        private Vector3 ledgeForward;
        private Vector3 closestPoint;
        [SerializeField] private float speed = 10;

        private float _velocityY;
        private Vector3 _movement;
        private float _rotationDamping;
        
        [Header("GroundCheck")]
        public float gravity = -9.81f;
        public Vector3 velocity;

        private Scene currentScene;
        

        
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
                currentScene = SceneManager.GetActiveScene();
                InputView.inputReader.ClimbEvent += OnClimb;
                LedgeDetector.OnLedgeDetect += OnLedge;
            }
        }

        private void OnClimb()
        {
            OnLedge(ledgeForward, closestPoint);
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
            /*RequireIsInitialized();
            // Did I collide with the correct object?
            PickupComponent pickupComponent = myCollider.gameObject.GetComponent<PickupComponent>();
            if (pickupComponent != null)
            {
                OnPickup.Invoke(pickupComponent);
            }*/

            if (myCollider.CompareTag("ElShield"))
            {
               StartCoroutine(InteractCoroutine());
               myCollider.enabled = false;
            }

            if (myCollider.CompareTag("Cargo"))
            {
                myCollider.attachedRigidbody.velocity = new Vector3(-1.5f, 0,0 );
                Debug.Log(myCollider.tag);
            }
        }

        private void FixedUpdate()
        {
            if (currentScene.name == "MadHospital")
            { 
                _movement = transform.position;
                RotateCharacter(_movement);
                AnimationsID();
                HandleGravity();
                HandleAnimator();
            
            }
        }
        protected void OnDisable()
        {
            Context?.CommandManager?.RemoveCommandListener<InputCommand>(
                OnInputCommand);
            LedgeDetector.OnLedgeDetect -= OnLedge;
            InputView.inputReader.ClimbEvent -= OnClimb;
            
        }

        //  Event Handlers --------------------------------
        private void OnInputCommand(InputCommand inputCommand)
        {
            RequireIsInitialized();
         
            if (currentScene.name == "MadHospital")
            {
                Vector3 movement = transform.TransformDirection(inputCommand.Value);
                characterController.Move(movement * Time.deltaTime * speed);
                Debug.Log(movement);
            }

            if (currentScene.name == "ShooterScene" && currentScene.name == "MainMenu" )
            {
                return;
            }
            
            
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),
                Time.deltaTime * _rotationDamping);
        }
        IEnumerator ClimbCoroutine(Vector3 closestPoint)
        {
            characterController.enabled = false;
            animator.SetFloat("VelocityX", 0);
            transform.position = closestPoint - (LedgeDetector.transform.position - transform.position) + new Vector3(0.05f,0,0);;
            animator.SetBool("OnLedge", true);
            yield return new WaitForSeconds(2.5f);
            transform.position = closestPoint + new Vector3(0.1f, 0, 0);
            animator.SetBool("OnLedge", false);
            characterController.enabled = true;
        }

        IEnumerator InteractCoroutine()
        {
            characterController.enabled = false;
            animator.SetBool("Interact",true);
            yield return new WaitForSeconds(1);
            animator.SetBool("Interact",false);
            yield return new WaitForSeconds(1);
            lights.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            characterController.enabled = true;
        }

    }
}