using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class testInteract : MonoBehaviour, Interactable
{
    public static TextMeshProUGUI txt;
    //public TextMeshProUGUI txt1;

    void Awake()
    {
        if (txt == null)
            txt = GameObject.Find("PressE").GetComponent<TextMeshProUGUI>();

        if (txt != null)
            txt.gameObject.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log("hello");
    }

    public string interactionText(){
        return "Press E";  
    }
    public void toggleE(bool activate){
        if (activate) {
            txt.gameObject.SetActive(true);
        }
        else
        {
            txt.gameObject.SetActive(false);
        }
    }
}
