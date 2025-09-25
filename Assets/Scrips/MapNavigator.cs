using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNavigator : MonoBehaviour
{
    public string[] sceneNames;
    public GameObject mapCanvasRoot;


    public void GoToRoomByIndex(int index)
    {
        mapCanvasRoot = FindInactiveByName("MapContainer");

        if (index < 0 || index >= sceneNames.Length) return;

        if (mapCanvasRoot != null) mapCanvasRoot.SetActive(false);

        SceneManager.LoadScene(sceneNames[index]);
    }

    public static GameObject FindInactiveByName(string objectName)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == objectName && go.scene.isLoaded);
    }
}
