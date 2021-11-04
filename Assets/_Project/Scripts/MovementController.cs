﻿using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Raycaster raycaster;
    private bool _isHiding = false;
    private bool _canHide;
    private bool _grounded ;

    private Vector2 _direction;
    
    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Move();
        Hiding();
    }

    private void FixedUpdate()
    {
        PhysicsMove();
    }

    private void PhysicsMove()
    {
        var velocityAdjust = body.velocity;
        velocityAdjust.y = 0;
        Debug.DrawRay(transform.position,   _direction* speed, Color.magenta);
        body.AddForce(_direction * speed - velocityAdjust, ForceMode2D.Impulse);
    }
    private void Hiding()
    {
        if(_canHide && Input.GetKeyDown(KeyCode.C)){
            _isHiding = !_isHiding;
           model.SetActive(!_isHiding);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
             _canHide= true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            _canHide= false;
            _isHiding = false;
            model.SetActive(!_isHiding);
        }
        
    }

    private void IsGrounded()
    {
        _grounded = raycaster.TouchGround();
    }
    private void Move()
    {
        if (_grounded)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"),  Input.GetAxisRaw("Vertical"));
        }
        else
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"),  0);
        }   
        
    }
        
}