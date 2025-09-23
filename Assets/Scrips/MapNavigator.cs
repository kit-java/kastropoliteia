using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNavigator : MonoBehaviour
{
    [Tooltip("Scene names for each room index (0..N)")]
    public string[] sceneNames;

    [Tooltip("Optional: reference to your Map Canvas root to auto-close")]
    public GameObject mapCanvasRoot;

    public void GoToRoomByIndex(int index)
    {
        if (index < 0 || index >= sceneNames.Length) return;

        // Optional: close the map before loading
        if (mapCanvasRoot != null) mapCanvasRoot.SetActive(false);

        SceneManager.LoadScene(sceneNames[index]);
    }
}
