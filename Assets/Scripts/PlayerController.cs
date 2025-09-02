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
        MoveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * 0.5f);
    }

    private void FixedUpdate()
    {
        //_rb.MovePosition(MoveVector + (Vector2)transform.position); 
        if(MoveVector.magnitude > 0.1f) 
        {
            _rb.linearVelocity = MoveVector.normalized * moveSpeed;

            Vector3 turn = transform.localScale;
            turn.x = MoveVector.x;
            transform.localScale = turn;
        }
    }
}
