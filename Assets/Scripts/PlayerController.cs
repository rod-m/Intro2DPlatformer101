using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Animator _animator;

    private Vector2 _scale;

    private int _direction = 1;

    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(move));
        SetDirection(move);
        SetMovement(move);
    }

    void SetMovement(float move)
    {
        Vector2 newV = _rigidbody.velocity;
        newV.x = speed * move;
        _rigidbody.velocity = newV;
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
}
