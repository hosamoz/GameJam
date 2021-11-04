using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject model;
    private bool _isHiding = false;
    private bool _canHide;

    // Update is called once per frame
    void Update()
    {
        Move();
        Hiding();
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

    private void Move()
    {
        {
            Vector3 dir;
                 
            dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0 );
            var newPos = transform.position;
            newPos += dir.normalized * Time.deltaTime * speed;
            transform.position = newPos;
        }
    }
        
}