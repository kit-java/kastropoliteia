using UnityEngine;

public class RoomIndex : MonoBehaviour
{
    public int roomIndex; // 0-based index matching the MapManager's array order

    void Start()
    {
        if (MapMarker.Instance != null)
            MapMarker.Instance.SetCurrent(roomIndex);
    }
}
