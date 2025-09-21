using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("0.5Tutorial");
    }
    public void Exitgame() {
        Application.Quit();
    }
}
