using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("0.5Tutorial");
    }
    public void Exitgame() {
        Application.Quit();
    }
}
