using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("0.5Tutorial");
        MuteTheAudio myScipt = GameObject.Find("MusicEngine").GetComponent<MuteTheAudio>();
        myScipt.SetPreviousTime();
    }
    public void Exitgame() {
        Application.Quit();
    }
}
