using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;   // <-- needed to get current scene name

public class CharacterIteractor : BaseInteractorClass
{
    public float dialogtimer = 5f;

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(ShowDialog());
    }

    private IEnumerator ShowDialog()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        foreach (LinesOfCSV line in myDialog)
        {
            txtDialog.text = line.dialog;

            // Automatically add to achievements log
            if (AchievementDialogManager.Instance != null)
            {
                AchievementDialogManager.Instance.UnlockDialog(sceneName, line.dialog);
            }

            yield return new WaitForSeconds(dialogtimer);
        }
    }
}
