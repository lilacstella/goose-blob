using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
public class Door : MonoBehaviour
{
    public UnityEvent OnOpenDoor;
    public bool PlayerInRange {  get; private set; }
    private Transform _player;
    public Transform newPositionAfterOpeningDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = true;
            _player = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInRange = false;
            _player = null;
        }
    }

    private void OnMouseDown()
    {
        if (PlayerInRange) { OnOpenDoor.Invoke(); _player.transform.SetPositionAndRotation(newPositionAfterOpeningDoor.position, Quaternion.identity); }
    }
}
