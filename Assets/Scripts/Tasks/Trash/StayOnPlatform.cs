using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{

    // When another GameObject touches this GameObject, set its gravity to 0
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero; 
        }
    }
}