using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class testInteract : MonoBehaviour, Interactable
{
    public static TextMeshProUGUI txt;
    public static TextMeshProUGUI txtDialog;
    public static GameObject imageDialog;
    //public TextMeshProUGUI txt1;

    void Awake()
    {
        if (txt == null)
            txt = transform.Find("Canvas/PressE").GetComponent<TextMeshProUGUI>();

        if (txt != null)
            txt.gameObject.SetActive(false);

        if (txtDialog == null)
            txtDialog = GameObject.Find("DialogTxt").GetComponent<TextMeshProUGUI>();

        if (txtDialog != null)
            txtDialog.gameObject.SetActive(false);

        if (imageDialog == null)
            imageDialog = GameObject.Find("ImageDialog");

        if (imageDialog != null)
            imageDialog.gameObject.SetActive(false);
    }

    public void Interact()
    {
        imageDialog.gameObject.SetActive(true);
        txtDialog.gameObject.SetActive(true);
        txtDialog.text = "Hello from user:";
    }

    public void toggle(bool activate){
        if (activate) {
            txt.gameObject.SetActive(true);
        }
        else
        {
            imageDialog.gameObject.SetActive(false);
            txtDialog.gameObject.SetActive(false);
            txt.gameObject.SetActive(false);
        }
    }
}
