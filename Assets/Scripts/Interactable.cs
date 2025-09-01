using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Interactable : MonoBehaviour
{
    public UnityEvent OnMouseClick;
    public Vector2 followMouseOffset = Vector2.zero;
    public bool followsMouseWhenHeldDown = true;
    public bool resetRotationUponDrag = false;
    public bool freezeRotationUponDrag = true;
    public bool removeVelocityUponClick = true;
    public bool disableColliderOnDrag = true;

    private Quaternion _rotOnStartClick;
    private Quaternion _defaultRotation = new Quaternion(0, 0, 0, 1);
    private Rigidbody2D _rb;
    private Collider2D _col;

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    public virtual void OnMouseDrag()
    {
        if (followsMouseWhenHeldDown)
        {
            if (freezeRotationUponDrag) { transform.rotation = _rotOnStartClick; }
            else if (resetRotationUponDrag) { transform.rotation = _defaultRotation; }
                transform.position = GetMousePosition(); 
        }
    }
    public virtual void OnMouseUp()
    {
        if(_col != null && disableColliderOnDrag) { _col.enabled = true; }
    }
    public virtual void OnMouseDown()
    {
        OnMouseClick.Invoke();
        if (freezeRotationUponDrag) { _rotOnStartClick = transform.rotation; }
        if (_rb != null && removeVelocityUponClick) { _rb.angularVelocity = 0; _rb.linearVelocity = Vector2.zero; }
        if (_col != null && disableColliderOnDrag) { _col.enabled = false; }
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
