using System.Collections;
using UnityEngine;

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
        foreach (LinesOfCSV line in myDialog)
        {
            txtDialog.text = line.dialog;
            yield return new WaitForSeconds(dialogtimer);
        }
    }
}
