using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody2D))]
public class LaundryClothes : MonoBehaviour
{
    public Laundry LaundryStatus {  get; private set; }

    [SerializeField] Collider2D _col;
    [SerializeField] SpriteRenderer laundryRenderer;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Sprite dirty, wet, clean;
    public Laundry startStatus = Laundry.Dirty;
    private int _dirtTouchTimes = 0;

    private void Start()
    {
        SwitchState(startStatus);
        _dirtTouchTimes = 0;
    }

    public void SwitchState(Laundry laundry)
    {
        if(laundry != LaundryStatus)
        {
            switch (laundry) 
            {
                case Laundry.Dirty:
                    laundryRenderer.sprite = dirty;
                    break;
                case Laundry.Wet:
                    laundryRenderer.sprite = wet;
                    break;
                case Laundry.Clean:
                    laundryRenderer.sprite = clean;
                    break;
            }
            LaundryStatus = laundry;
            _dirtTouchTimes = 0;
        }
    }
    public void EnterMachine()
    {
        GetComponent<Interactable>().StopInteraction();
        _rb.bodyType = RigidbodyType2D.Static;
        _col.enabled = false;
    }
    public void ExitMachine()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
        Vector2 force = Random.insideUnitCircle;
        force.y = Random.Range(3f, 10f);
        _rb.AddForce(force, ForceMode2D.Impulse);
        _col.enabled = true;
        GetComponent<Interactable>().AllowInteraction();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (LaundryStatus != Laundry.Dirty) 
        { 
            if (collision.gameObject.CompareTag("Laundry"))
            {
                LaundryClothes lc = collision.gameObject.GetComponent<LaundryClothes>();
                if (lc != null) 
                {
                    if (lc.LaundryStatus == Laundry.Dirty) 
                    {
                        _dirtTouchTimes++;
                        if (_dirtTouchTimes > 4) { SwitchState(Laundry.Dirty); }
                    }
                    else if(lc.LaundryStatus == Laundry.Wet && LaundryStatus == Laundry.Clean)
                    {
                        SwitchState(Laundry.Wet);
                    }
                }
            } 
        }
    }
}
