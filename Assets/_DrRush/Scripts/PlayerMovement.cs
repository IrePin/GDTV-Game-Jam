using Input;
using UnityEngine;

namespace _DrRush.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        //[SerializeField] private InputReader inputReader;

        private Vector2 _moveDirection;

        [SerializeField] Animator animator;
        private float _velocityX;

        private Rigidbody _rb;

        private RaycastHit _hit;

        public float moveSpeed = 5f;
        public float jumpForce = 10f;
    
        [Header("GroundCheck")]
        public LayerMask groundLayer;
        public Transform groundCheck;
        public bool isGrounded;
        private static readonly int VelocityX = Animator.StringToHash("VelocityX");
        private static readonly int Run = Animator.StringToHash("Run");

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.useGravity = true;
            //inputReader.MoveEvent += HandleMove;
        }

        private void Update()
        {
            HandleAnimations();
            Debug.Log(isGrounded);
            Debug.Log(_moveDirection);
        }
        void FixedUpdate()
        {
            CheckingGround();
            Jump();
            Move();
        }
        private void HandleMove(Vector2 dir)
        {
            _moveDirection = dir;
        }

        private void Move()
        {
            if (isGrounded){
                _rb.velocity = new Vector3(_moveDirection.x * moveSpeed, _rb.velocity.y, 0);
            }
        }

        void CheckingGround()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        }

        private void Jump()
        {
            if (_moveDirection.y > 0 && isGrounded)
            {
                _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }

        private void HandleAnimations()
        {
            if (_moveDirection.x == 0)
            {
                animator.SetBool(Run, false);
            }
            else
            {
                animator.SetBool(Run, true);
                animator.SetFloat(VelocityX, _moveDirection.x);
            }
        }
    }
}