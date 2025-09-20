using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MuteTheAudio : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource audioSource;
    private static float previousTime = 0;
    public bool isMenu = false;
    private static bool isPlaying;
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
        myMusic = GameObject.Find("Music_Button").GetComponent<Button>();
        myMusic.onClick.AddListener(ToggleMuteTheMusic);

        myAudio = GameObject.Find("Sound_Button").GetComponent<Button>();
        myAudio.onClick.AddListener(ToggleMuteTheAudio);


        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menu;
        audioSource.playOnAwake = true;
        audioSource.loop = true;

        if (previousTime != 0) {
            //audioSource.time = previousTime;
        }

        audioSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
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
    public void SetPreviousTime() {
        previousTime = audioSource.time;
    }
}
