using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyerInteractor : BaseInteractorClass
{

    public static AchievementDialogManager achievementDialogManager;
    public static string activeScene = null;
    public float dialogtimer = 5f;
    private bool isPressable = true;

    public GameObject myShop;

    public override void Interact()
    {
        myShop = FindInactiveByName("Shop");

        if (isPressable)
        {
            myShop.SetActive(true);
            isPressable = false;
        }
        else
        {
            myShop.SetActive(false);
            isPressable = true;
        }
    }

    public override void OnTrigger(bool activate)
    {
        base.OnTrigger(activate);

        if ((myShop != null) && !activate)
        {
            myShop.SetActive(false);
            isPressable = true;
        }
    }
}
