using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESP : MonoBehaviour
{
    public GameObject esp;

    public bool toggle = true;
    private void Awake()
    {
        esp = FindInactiveByName("ESP");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("0.1MainMenu");
    }
    public void Exitgame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("adsdas");
            esp.SetActive(toggle);
            toggle = !toggle;
        }
    }

    public static GameObject FindInactiveByName(string objectName)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == objectName && go.scene.isLoaded);
    }
}
