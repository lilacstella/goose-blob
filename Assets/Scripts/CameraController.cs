using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Room 1 should always be the bedroom or wherever the player starts their day. Room 2 should be where the exit is. Room 3 should be bathroom / household chores. 
    /// </summary>
    public Transform[] rooms;
    
    public void SwitchRooms(int roomNumber)
    {
        if (rooms.Length >= roomNumber + 1) { transform.position = rooms[roomNumber].position; }
    }
}
