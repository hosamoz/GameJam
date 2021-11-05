using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject model;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private List<Raycaster> raycasters;
    [SerializeField] private Animator anim;

    private bool _isHiding = false;
    private bool _canHide;
    private bool _grounded;
    private bool _dead;
    private Vector2 _direction;

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
        _grounded = false;
        foreach (Raycaster raycaster in raycasters) {
            _grounded = raycaster.Cast();
            if (_grounded)
                break;
        }
        anim.SetBool("isJump", !_grounded);
    }
    private void Move()
    {
        var directionX = _direction.x;
        if (_grounded)
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"),  Input.GetAxisRaw("Vertical"));
            if(directionX == 0) anim.SetBool("isRun", false);
            else
            {
                if (directionX < 0)
                    transform.localScale = new Vector3(-1,transform.localScale.y,1);
                else 
                    transform.localScale = new Vector3(1,transform.localScale.y,1);
            
                anim.SetBool("isRun", true);
            }
        }
        else
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"),  0);
            if (directionX != 0)
            {
                if (directionX < 0)
                    transform.localScale = new Vector3(-1,transform.localScale.y,1);
                else 
                    transform.localScale = new Vector3(1,transform.localScale.y,1);
            
                anim.SetBool("isRun", false);  
            }
        }
    }

    public void Death()
    {
        if(!_dead)
        {
            if (!_isHiding)
            {
                _dead = true;
                anim.SetBool("die", true);
            }      
        }
        
    }
        
}