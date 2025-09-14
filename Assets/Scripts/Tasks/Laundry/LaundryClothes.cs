using UnityEngine;

public class LaundryClothes : MonoBehaviour
{
    public Laundry LaundryStatus {  get; private set; }

    [SerializeField] Sprite dirty, wet, clean;
}
