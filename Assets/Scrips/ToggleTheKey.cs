using System.Linq;
using TMPro;
using UnityEngine;

public class ToggleTheKey : MonoBehaviour, Interactable
{
    public TextMeshProUGUI txt;
    public TextMeshProUGUI txtDialog;
    public GameObject imageDialog;
    //public TextMeshProUGUI txt1;

    void Awake()
    {
        //Get the PressE child and diactivate it
        if (txt == null)
            txt = transform.Find("Canvas/PressButton").GetComponent<TextMeshProUGUI>();

        if (txt != null)
            txt.gameObject.SetActive(false);

        //Get the myDialog and diactivate it
        var myDialog = FindInactiveByName("DialogTxt");
        if (myDialog != null)
            txtDialog = myDialog.GetComponent<TextMeshProUGUI>();

        if (txtDialog != null)
            txtDialog.gameObject.SetActive(false);

        //Get the imageDialog child and diactivate it
        imageDialog = FindInactiveByName("ImageDialog");

        if (imageDialog != null)
            imageDialog.gameObject.SetActive(false);
    }

    public void Interact()
    {
        //Make sure that the child is calling this method
        imageDialog.gameObject.SetActive(true);
        txtDialog.gameObject.SetActive(true);
    }

    //Used for toggleing the text when it id in the colider box
    public void toggle(bool activate)
    {
        if (activate)
        {
            txt.gameObject.SetActive(true);
        }
        else
        {
            imageDialog.gameObject.SetActive(false);
            txtDialog.gameObject.SetActive(false);
            txt.gameObject.SetActive(false);
        }
    }

    //Find all the object children of a object and return the one that the name is the same as the objectName
    private static GameObject FindInactiveByName(string objectName)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == objectName && go.scene.isLoaded);
    }
}

