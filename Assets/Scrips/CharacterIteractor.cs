using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterIteractor : BaseInteractorClass
{

    public static AchievementDialogManager achievementDialogManager;
    public static string activeScene = null;
    public float dialogtimer = 5f;
    private bool isPressOnes = false;
    private bool playerToching = false;
    private IEnumerator myDialogloop;


    public override void Interact()
    {
        base.Interact();

        if (!isPressOnes) {
            myDialogloop = ShowDialog();
            isPressOnes = true;
            StartCoroutine(myDialogloop);
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
            }
        }
    }

    private IEnumerator ShowDialog()
    {
        foreach (LinesOfCSV line in myDialog)
        {
            if (!playerToching) yield break;

            txtDialog.text = line.dialog;

            activeScene = SceneManager.GetActiveScene().name;

            if (achievementDialogManager == null)
                achievementDialogManager = FindInactiveByName("Achievement").GetComponent<AchievementDialogManager>();

            achievementDialogManager.UnlockDialog(activeScene, line.dialog);

            yield return new WaitForSeconds(dialogtimer);
        }
    }

}
