using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Teeth : MonoBehaviour
{
    private SpriteRenderer _sr;
    public float dirtyness = 0f;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.tag == "Toothbrush")
            {
                dirtyness -= Random.Range(0.01f, 0.05f);
            }
        }
    }

    public void ChangeColor(Color color)
    {
        _sr.color = color;
    }
}
