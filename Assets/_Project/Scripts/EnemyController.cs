using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float maxDistance;

    // void Update()
    // {
    //     var ray = new Ray(transform.position + offset, direction);
    //     Debug.DrawRay(ray.origin, ray.direction.normalized*maxDistance, Color.red);
    //     return Physics.Raycast(ray, maxDistance, layerMask,);
    // }
  
    
}
