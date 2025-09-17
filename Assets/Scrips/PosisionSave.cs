using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosisionSave : MonoBehaviour
{
    public static Dictionary<string, Vector3> LastPos = new Dictionary<string, Vector3> ();
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        try
        {
            GameObject.Find("Player").transform.position = LastPos[sceneName];
        }
        catch (KeyNotFoundException) { }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
}
