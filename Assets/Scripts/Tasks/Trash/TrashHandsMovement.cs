using UnityEngine;

public class TrashHandsMovement : Interactable
{
    public override void OnMouseDown()
    {
        OnMouseClick.Invoke();
    }

    public override void OnMouseDrag()
    {
        if (followsMouseWhenHeldDown)
        {
            if (GetMousePosition().y < -3.5f)
                transform.position = GetMousePosition();
            else
                transform.position = new Vector3(GetMousePosition().x, -3.5f, GetMousePosition().z);
        }
    }
}
