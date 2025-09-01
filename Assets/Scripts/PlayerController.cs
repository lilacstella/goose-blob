using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public Vector2 MoveVector { get; private set; }
    private Rigidbody2D _rb;
    public float moveSpeed = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
    }

    private void FixedUpdate()
    {
        //_rb.MovePosition(MoveVector + (Vector2)transform.position); 
        if(MoveVector.x != 0f) { _rb.linearVelocity = new Vector2(MoveVector.x * moveSpeed, _rb.linearVelocityY); }
        
    }
}
