using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterIteractor : BaseInteractorClass
{

    public static AchievementDialogManager achievementDialogManager;
    public float dialogtimer = 5f;
    private bool isPressOnes = false;
    private bool playerToching = false;
    private IEnumerator myDialogloop;

    public string characterName = "defualt";
    private string achievementText = null;
    public override void Interact()
    {
        base.Interact();

        if (!isPressOnes) {
            myDialogloop = ShowDialog();
            isPressOnes = true;
            StartCoroutine(myDialogloop);
        }

        achievementText = "";
        foreach (LinesOfCSV line in myDialog)
        {
            achievementText = achievementText + " " + line.dialog;
        }

        if (achievementText != null)
        {
            if (achievementDialogManager == null)
                achievementDialogManager = FindInactiveByName("Achievement").GetComponent<AchievementDialogManager>();

            achievementDialogManager.UnlockDialog(characterName, achievementText);
        }
    }

    public override void OnTrigger(bool activate)
    {
        base.OnTrigger(activate);

        playerToching = activate;

        if (!activate)
        {
            isPressOnes = false;
            if (myDialogloop != null)
            {
                StopCoroutine(myDialogloop);
                myDialogloop = null;
                achievementText = null;
            }
        }
    }

    private IEnumerator ShowDialog()
    {
        foreach (LinesOfCSV line in myDialog)
        {
            if (!playerToching) yield break;

            txtDialog.text = line.dialog;

            achievementText = achievementText + line.dialog;

            yield return new WaitForSeconds(dialogtimer);
        }
    }
}
