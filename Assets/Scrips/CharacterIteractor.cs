using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterIteractor : BaseInteractorClass
{

    public static AchievementDialogManager achievementDialogManager;
    public static string activeScene = null;
    public float dialogtimer = 5f;
    private bool stopDialog = false;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(ShowDialog());
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
