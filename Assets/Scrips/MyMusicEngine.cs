using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MuteTheAudio : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource audioSource;
    public bool isMenu = false;
    public static MuteTheAudio I { get; private set; }

    //buttons
    private Button myMusic;
    private Button myAudio;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this;

        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        //Set listener in the Ui button 
        myMusic = GameObject.Find("Music_Button").GetComponent<Button>();
        myMusic.onClick.AddListener(ToggleMuteTheMusic);

        myAudio = GameObject.Find("Sound_Button").GetComponent<Button>();
        myAudio.onClick.AddListener(ToggleMuteTheAudio);

        //Setup the audio Source and play
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menu;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Set listener in the Ui button when the scene is cahnge
        myMusic = GameObject.Find("Music_Button").GetComponent<Button>();
        myMusic.onClick.AddListener(ToggleMuteTheMusic);

        myAudio = GameObject.Find("Sound_Button").GetComponent<Button>();
        myAudio.onClick.AddListener(ToggleMuteTheAudio);
    }

    public void ToggleMuteTheAudio(){
        AudioListener.pause = !AudioListener.pause;
    }

    public void ToggleMuteTheMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
}
