using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 40f;
    private float _horizontalMove = 0f;
    [Range(0, .3f)][SerializeField] private float _movementSmoothing = .05f;
    private Camera _cam;
    private Rigidbody2D _rb;
    private bool _facingRight = true;  
    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    void FixedUpdate()
    {
       Move(_horizontalMove * Time.fixedDeltaTime);
    }

    private void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, _movementSmoothing);

        if (move > 0 && !_facingRight)
        {
            Flip();
        }
        else if (move < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
