using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    public UnityEvent OnMouseClick;
    public Vector2 followMouseOffset = Vector2.zero;
    public bool followsMouseWhenHeldDown = true;
    public bool followsMouseWithOffsetDependingOnWhereMouseWas = true;
    public bool resetRotationUponDrag = false;
    public bool freezeRotationUponDrag = true;
    public bool removeVelocityUponClick = true;
    public bool disableColliderOnDrag = true;
    public bool mouseScrollToRotate = false;

    public bool Interacting { get; private set; }

    protected Quaternion _rotOnStartClick;
    protected Quaternion _defaultRotation = new Quaternion(0, 0, 0, 1);
    protected Vector3 _mouseOffsetFromPivotPoint = Vector3.zero;
    protected Rigidbody2D _rb;
    protected Collider2D _col;

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

            if (_rb != null && removeVelocityUponClick) { _rb.angularVelocity = 0; _rb.linearVelocity = Vector2.zero; }

            if (followsMouseWithOffsetDependingOnWhereMouseWas)
            {
                transform.position = GetMousePosition() + _mouseOffsetFromPivotPoint;
            }
            else { transform.position = GetMousePosition(); }
        }
        Interacting = true;
    }
    public virtual void OnMouseUp()
    {
        if(_col != null && disableColliderOnDrag) { _col.enabled = true; }
        Interacting = false;
    }
    public virtual void OnMouseDown()
    {
        OnMouseClick.Invoke();
        if (freezeRotationUponDrag) { _rotOnStartClick = transform.rotation; }
        if (_col != null && disableColliderOnDrag) { _col.enabled = false; }
        if (followsMouseWithOffsetDependingOnWhereMouseWas) { _mouseOffsetFromPivotPoint = transform.position - GetMousePosition(); }
        Interacting = true;
    }

    public Vector3 GetMousePosition()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
