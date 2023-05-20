using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private Vector2 _moveDirection;

    private Rigidbody _rb;
    private bool _isGrounded;
    private CapsuleCollider _collider;
    private RaycastHit _hit;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _rb.useGravity = true;
        inputReader.MoveEvent += HandleMove;
    }

    private void HandleMove(Vector2 dir)
    {
        _moveDirection.x = dir.x;
        _moveDirection.y = dir.y;
    }

    void FixedUpdate()
    {
        Move();
        CheckGround();
        Jump();
        Debug.Log(_isGrounded);
        
    }

    
    private void Move()
    {
        if (_moveDirection == Vector2.zero)
        {
            return;
        }

        _rb.velocity = new Vector3(_moveDirection.x * moveSpeed, _rb.velocity.y, 0);

       
        {
            Jump();
        }
    }
    
    private void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, _collider.bounds.extents.y + 0.5f, groundLayer))
        {
            _isGrounded = true;
        }
        else if (Physics.Raycast(transform.position + Vector3.down * 0.1f, Vector3.down, out hit, _collider.bounds.extents.y + 0.5f, groundLayer))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }

    private void Jump()
    {
        if (_moveDirection.y > 0 && _isGrounded)
        {
            _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        
    }
}