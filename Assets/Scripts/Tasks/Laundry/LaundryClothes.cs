using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Interactable))]
public class LaundryClothes : MonoBehaviour
{
    public Laundry LaundryStatus {  get; private set; }

    [SerializeField] Collider2D _col;
    [SerializeField] SpriteRenderer laundryRenderer;
    [SerializeField] Sprite dirty, wet, clean;
    public Laundry startStatus = Laundry.Dirty;

    private void Start()
    {
        SwitchState(startStatus);
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
        }
    }
    public void EnterMachine()
    {
        _col.enabled = false;
    }
    public void ExitMachine()
    {
        _col.enabled = true;
    }
}
