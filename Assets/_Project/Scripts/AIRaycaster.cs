using UnityEngine;

public class AIRaycaster : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float maxDistance;

    public bool TouchGround()
    {
        var ray = new Ray2D(new Vector2(transform.position.x, transform.position.y) + offset, direction);
        Debug.DrawRay(ray.origin, ray.direction.normalized * maxDistance, Color.red);
        return Physics2D.Raycast(ray.origin, ray.direction, maxDistance, layerMask);
    }
}
