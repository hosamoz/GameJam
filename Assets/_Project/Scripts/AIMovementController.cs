using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class AIMovementController : MonoBehaviour
{
    [SerializeField] private Raycaster raycastGround;
    [SerializeField] private List<Raycaster> raycastsKill;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime;
    [SerializeField] private Animator animator;
    [SerializeField] private DeathEvent OnKill;

    private bool _grounded;
    private bool _waiting;
    private bool _killed;
    private Vector2 movement;
    private Vector2 left;
    private Vector2 right;
    

    private void Start()
    {
        movement = new Vector2(0, 0);
        left = Vector2.left;
        right = Vector2.right;
    }

    private void Update()
    {
        ApplyMovement();
        IsGrounded();
        DetectAlice();
    }

    private void ApplyMovement()
    {
        if (_grounded)
        {
            if (!_waiting)
            {
                StartCoroutine(ChangingDirection());
            }
            if(movement.x != speed && movement.x != -speed)
            {
                movement.x = speed;
            }
            animator.SetFloat("actualSpeed", -movement.x);
            body.velocity = movement;
        }
    }

    private IEnumerator ChangingDirection()
    {
        _waiting = true;
        movement = -movement;
        yield return new WaitForSeconds(waitingTime);
        _waiting = false;
    }

    private void IsGrounded()
    {
        _grounded = raycastGround.Cast();
    }

    private void DetectAlice()
    {
        if (movement.x > 0)
        {
            foreach (Raycaster raycastKill in raycastsKill)
            {
                if (_killed != true)
                {
                    _killed = raycastKill.Cast(right);
                }
            }
        }   
        else
        {
            foreach (Raycaster raycastKill in raycastsKill)
            {
                if(_killed != true)
                {
                    _killed = raycastKill.Cast(left);
                }   
            }

            if(_killed == true)
            {
                OnKill?.Invoke();
            }
        }
    }
}
