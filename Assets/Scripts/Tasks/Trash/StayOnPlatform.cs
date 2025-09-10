using UnityEngine;

public class StayOnPlatform : MonoBehaviour
{
    [SerializeField] TrashSpawner spawner;
    // When another GameObject touches this GameObject, set its gravity to 0
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = Vector2.zero;
            spawner.gameObjectsLeftOnFloor.Add(rb.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 1f;
            spawner.gameObjectsLeftOnFloor.Remove(rb.gameObject);
        }
    }
}