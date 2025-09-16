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
    public bool movesUsingRigidbody = false;
    public float moveForce = 5f;

    public bool Interacting { get; private set; }
    public bool CanInteract {  get; private set; }

    protected Quaternion _rotOnStartClick;
    protected Quaternion _defaultRotation = new Quaternion(0, 0, 0, 1);
    protected Vector3 _mouseOffsetFromPivotPoint = Vector3.zero;
    protected Rigidbody2D _rb;
    protected Collider2D _col;

    public virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        CanInteract = true;
        Interacting = false;
    }

    public void Update()
    {
        if (mouseScrollToRotate) 
        {
            float delta = Input.GetAxis("Mouse ScrollWheel");
            if(delta != 0f)
            {
                if (movesUsingRigidbody) { }
                else { transform.Rotate(0, 0, delta * 5f); }
            }
        }
    }

    public void StopInteraction()
    {
        if (CanInteract) { CanInteract = false; }
    }

    public virtual void OnMouseDrag()
    {
        if (!CanInteract) { return; }
        if (followsMouseWhenHeldDown)
        {
            if (freezeRotationUponDrag) { transform.rotation = _rotOnStartClick; }
            else if (resetRotationUponDrag) { transform.rotation = _defaultRotation; }

            if (_rb != null && removeVelocityUponClick) { _rb.angularVelocity = 0; _rb.linearVelocity = Vector2.zero; }

            Vector3 pos = GetMousePosition();
            if (followsMouseWithOffsetDependingOnWhereMouseWas)
            {
                pos += _mouseOffsetFromPivotPoint;
            }
            if (movesUsingRigidbody) { _rb.AddForce((pos - transform.position).normalized * moveForce); }
            else { transform.position = pos; }
        }
        Interacting = true;
    }
    public virtual void OnMouseUp()
    {
        if (!CanInteract) { return; }
        if (_col != null && disableColliderOnDrag) { _col.enabled = true; }
        Interacting = false;
    }
    public virtual void OnMouseDown()
    {
        if(!CanInteract) { return; }
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
