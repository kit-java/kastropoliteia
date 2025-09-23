using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public static MapMarker Instance; // <— singleton

    [Header("Assign in Inspector")]
    public RectTransform[] roomRects;   // all your room UI Images
    public RectTransform marker;        // the Marker Image
    public GameObject mapCanvasRoot;    // the MapCanvas root

    void Awake()
    {
        // Singleton guard
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // if another exists, kill this duplicate
            return;
        }
        Instance = this;

        // Persist across scene loads
        DontDestroyOnLoad(gameObject);

        // Optional: keep the canvas as a child so it persists with us
        if (mapCanvasRoot != null && mapCanvasRoot.transform.parent != transform)
            mapCanvasRoot.transform.SetParent(transform, worldPositionStays: false);

        // Start hidden
        if (mapCanvasRoot != null)
            mapCanvasRoot.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && mapCanvasRoot != null)
            mapCanvasRoot.SetActive(!mapCanvasRoot.activeSelf);
    }

    public void SetCurrent(int index)
    {
        if (roomRects == null || index < 0 || index >= roomRects.Length) return;
        var target = roomRects[index];

        // Put marker in same UI space and center it on that room block
        marker.SetParent(target.parent, false);
        marker.anchorMin = target.anchorMin;
        marker.anchorMax = target.anchorMax;
        marker.pivot = target.pivot;
        marker.anchoredPosition = target.anchoredPosition;
    }
}
