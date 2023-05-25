using System;
using _DrRush.Scripts.Runtime.Components;
using _DrRush.Scripts.Runtime.Mini.Controller.Commands;
using RMC.Core.Architectures.Mini.Context;
using RMC.Core.Architectures.Mini.View;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;


namespace _DrRush.Scripts.Runtime.Mini.View
{
    public class PickupUnityEvent : UnityEvent<PickupComponent> {}
    public class ShooterView : MonoBehaviour, IView
    {
        [HideInInspector] 
        public readonly PickupUnityEvent OnPickup = new PickupUnityEvent();
        public bool IsInitialized { get { return _isInitialized;} }
        public IContext Context { get { return _context;} }
        
        private bool _isInitialized = false;
        private IContext _context;
        
        [field: SerializeField] public InputView InputView { get; private set; }
        
        [SerializeField] private CharacterController shooterCharController;
        [Header("GroundCheck")]
        public float gravity = -9.81f;
        public Vector3 velocity;
        [SerializeField] private float speed;
        
        
        // cinemachine
        [SerializeField] GameObject CinemachineCameraTarget;
        private float _cinemachineTargetPitch;
        [SerializeField] private float rotationVelocity;
        private const float RotationSpeed = 0.1f;
        private const float Threshold = 0.01f;
        [SerializeField] private float topClamp = 90.0f;
        [SerializeField] private float bottomClamp = -90.0f;

        public void Initialize(IContext context)
        {
            if (!IsInitialized)
            {
                _isInitialized = true;
                _context = context;

                Context.CommandManager.AddCommandListener<InputCommand>(
                    OnInputCommand);
            }
        }

        public void RequireIsInitialized()
        {
            if (!IsInitialized)
            {
                throw new Exception("MustBeInitialized");
            }
        }

        private void LateUpdate()
        {
            HandleGravity();
            CameraRotation();
        }

        private void OnInputCommand(InputCommand inputCommand)
        {
            RequireIsInitialized();
            
            Vector3 movement = transform.TransformDirection(inputCommand.Value);
            shooterCharController.Move((movement * speed) * Time.deltaTime);
            Debug.Log(movement);
        }

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
        
        private bool IsGrounded(CharacterController characterController)
        {
            return Physics.Raycast(characterController.transform.position + Vector3.up * 0.1f, 
                -Vector3.up, 
                characterController.height / 1.8f + 0.1f);
        }
        private void HandleGravity()
        {
            if (IsGrounded(shooterCharController))
            {
                velocity.y = -2f;
            }
            else if(!IsGrounded(shooterCharController))
            {
                velocity.y += gravity * Time.deltaTime;
            }

            shooterCharController.Move(velocity * Time.deltaTime);
        }
        
        private void CameraRotation()
        {
            // if there is an input
            if (InputView.inputReader.look.sqrMagnitude >= Threshold)
            {
                _cinemachineTargetPitch += InputView.inputReader.look.y * RotationSpeed;
                rotationVelocity = InputView.inputReader.look.x * RotationSpeed;

                // clamp our pitch rotation
                _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, bottomClamp, topClamp);

                // Update Cinemachine camera target pitch
                CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

                // rotate the player left and right
                transform.Rotate(Vector3.up * rotationVelocity);
            }
        }
        
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
        
        



    }
}
