using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _scale;
    private int _direction = 1;
    public float jumpForce = 10f;
    public float speed = 5f;
    public LayerMask whatIsGround;
    private bool falling = false;
    public Transform groundPoint;
    private Vector3 _startPosition;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _scale = transform.localScale;
        _startPosition = transform.position;
    }
 
    // Update is called once per frame
    void Update()
    {
        
        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(move));
        SetDirection(move);
        SetMovement(move);
        Falling();
    }
 
    void SetMovement(float move)
    {
        if (IsGrounded())
        {
            Vector2 newVelocity = _rigidbody.velocity;
            newVelocity.x = speed * move;
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            {
                newVelocity.y = jumpForce;
                _animator.SetTrigger("Jump");
            }
            _rigidbody.velocity = newVelocity;
        }
      
    }
    void SetDirection(float move)
    {
        if (Mathf.RoundToInt(move) != 0 && Mathf.RoundToInt(move) != _direction)
        {
            _direction = Mathf.RoundToInt(move);
            _scale.x *= -1;
            transform.localScale = _scale;
        }
    }

    bool IsGrounded()
    {
        Collider2D col = Physics2D.OverlapCircle(groundPoint.position, 0.1f, whatIsGround);
        return col != null;
    }
    private void Falling()
    {
        if (_rigidbody.velocity.y < 0 && !IsGrounded())
        {
            falling = true;
            _animator.SetBool("Falling", true);
        }
        else if (falling)
        {
            falling = false;
            _animator.SetBool("Falling", false);
        }
    }

    public void ReSpawn()
    {
        transform.position = _startPosition;
    }

}