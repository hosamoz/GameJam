using System;
using System.Collections;
using UnityEngine;

public class AIMovementController : MonoBehaviour
{
    [SerializeField] private AIRaycaster raycast;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float waitingTime;

    private bool _grounded;
    private bool _waiting;
    private Vector2 movement;

    private void Start()
    {
        movement = new Vector2(0, 0);
    }

    private void Update()
    {
        ApplyMovement();
        IsGrounded();
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
        _grounded = raycast.TouchGround();
        if(_grounded)
        {
            Debug.Log("Grounded");
        }
    }
}
