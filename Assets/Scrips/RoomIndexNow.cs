using UnityEngine;

public class RoomIndex : MonoBehaviour
{
    public int roomIndex; 

    void Start()
    {
        if (MapMarker.Instance != null)
            MapMarker.Instance.SetCurrent(roomIndex);
    }
}
