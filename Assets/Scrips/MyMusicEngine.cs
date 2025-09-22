using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MuteTheAudio : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource audioSource;
    public bool isMenu = false;

    public Image musicButtonCollor;
    public Image soundButtonCollor;

    public static MuteTheAudio I { get; private set; }

    //buttons
    public Button myMusic;
    public Button myAudio;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        //Setup the audio Source and play
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menu;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "0.5Tutorial" || scene.name == "0.1MainMenu")
        {
            //Set listener in the Ui button when the scene is cahnge
            myMusic = GameObject.Find("Music_Button").GetComponent<Button>();
            myMusic.onClick.AddListener(ToggleMuteTheMusic);

            myAudio = GameObject.Find("Sound_Button").GetComponent<Button>();
            myAudio.onClick.AddListener(ToggleMuteTheAudio);
        }
    }

    public void ToggleMuteTheAudio(){
        AudioListener.pause = !AudioListener.pause;

       if (AudioListener.pause)
       {
            myAudio.GetComponent<Image>().color = Color.red;
       }
       else
       {
            myAudio.GetComponent<Image>().color = Color.white;
       }
    }

    public void ToggleMuteTheMusic()
    {
        audioSource.mute = !audioSource.mute;

        if (audioSource.mute)
        {
            myMusic.GetComponent<Image>().color = Color.red;
        }
        else {
            myMusic.GetComponent<Image>().color = Color.white;
        }
    }
}
