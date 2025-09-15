using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TutorialNextScene : MonoBehaviour
{
    private string [] stages = {"1Entrance",
                                "2Bastion",
                                "3Yard",
                                "4SecondYard",
                                "5Armory",
                                "6Garden",
                                "7TrainingGrounds",
                                "8Shop"};
public int numStage = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try{
            SceneManager.LoadScene(stages[numStage - 1]);
        }
        catch (Exception e) {
            Debug.LogException(e);
        }
    }
}
