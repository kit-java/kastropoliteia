using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public static MapMarker Instance;
    public RectTransform[] roomRects;
    public RectTransform marker;
    public GameObject mapCanvasRoot;

    void Awake()
    {

        if ( Instance != null && Instance != this )
        {
            Destroy( gameObject );
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);

        if ( mapCanvasRoot != null && mapCanvasRoot.transform.parent != transform )
            mapCanvasRoot.transform.SetParent( transform, worldPositionStays: false );

        if ( mapCanvasRoot != null )
            mapCanvasRoot.SetActive(false);
    }

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.M) && mapCanvasRoot != null )
            mapCanvasRoot.SetActive(!mapCanvasRoot.activeSelf);
    }

    public void SetCurrent(int index)
    {
        if ( roomRects == null || index < 0 || index >= roomRects.Length )
            return;

        var target = roomRects[index];

        marker.SetParent(target.parent, false);
        marker.anchorMin = target.anchorMin;
        marker.anchorMax = target.anchorMax;
        marker.pivot = target.pivot;
        marker.anchoredPosition = target.anchoredPosition;
    }
}
