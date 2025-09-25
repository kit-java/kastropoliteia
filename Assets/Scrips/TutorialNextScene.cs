using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TutorialNextScene : MonoBehaviour, Interactable
{
    public KeyCode keyCode = KeyCode.W;
    public TextMeshProUGUI mytextMeshPro;

    private string[] stages = {"1Entrance",
                                "2Bastion",
                                "3Yard",
                                "4SecondYard",
                                "5Armory",
                                "6Garden",
                                "7TrainingGrounds",
                                "8Shop",
                                "5.1Kitchen"};
    public int numStage = 0;
    public float triggerCooldown = 1f; // seconds
    private bool canTrigger = false;
    public bool isPress = false;

    private void Start()
    {
        StartCoroutine(EnableTriggerAfterDelay());

        if (isPress) {
            mytextMeshPro = transform.Find("Canvas/PressButton").GetComponent<TextMeshProUGUI>();

            mytextMeshPro.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(keyCode) && isPress)
        {
            SceneManager.LoadScene(stages[numStage - 1]);
        }
    }

    private IEnumerator EnableTriggerAfterDelay()
    {
        canTrigger = false;
        yield return new WaitForSeconds(triggerCooldown);
        canTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canTrigger) return;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        try
        {
            PosisionSave.LastPos.Add(sceneName, GameObject.Find("Player").transform.position);
        }
        catch (ArgumentException) {
            PosisionSave.LastPos[sceneName] = GameObject.Find("Player").transform.position;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        try {
            if (!isPress) {
                SceneManager.LoadScene(stages[numStage - 1]);
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }


    public void Interact() { }
    public void OnTrigger(bool a)
    {
        if (isPress && a)
        {
            mytextMeshPro.gameObject.SetActive(true);
        }

        if(isPress && !a){
            mytextMeshPro.gameObject.SetActive(false);
        }
    }
    public string interactionText() { return "none"; }

}
