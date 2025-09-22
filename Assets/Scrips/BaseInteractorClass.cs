using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LinesOfCSV
{
    public int dialogNumber { get; set; }
    public string dialog { get; set; }
}

public class BaseInteractorClass : MonoBehaviour, Interactable
{
    public TextMeshProUGUI txt;
    public TextMeshProUGUI txtDialog;
    public GameObject imageDialog;
    protected bool playerToching = false;
    public string pathName = string.Empty;
    public List<LinesOfCSV> myDialog = new List<LinesOfCSV>();

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

    public virtual void Start()
    {
        using (StreamReader myRead = new StreamReader(pathName))
        {
            string line;
            bool first = true;

            while ((line = myRead.ReadLine()) != null)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                // Regex to split CSV but ignore commas inside quotes
                var matches = Regex.Matches(line, @"(?:^|,)(?:(?:""(?<val>[^""]*)"")|(?<val>[^,]*))");
                var part = new List<string>();
                foreach (Match match in matches)
                {
                    part.Add(match.Groups["val"].Value);
                }

                LinesOfCSV oneLine = new LinesOfCSV
                {
                    dialogNumber = int.Parse(part[0]),
                    dialog = part[1]
                };

                myDialog.Add(oneLine);
            }
        }
    }

    public virtual void Interact()
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
            playerToching = true;
            txt.gameObject.SetActive(true);
        }
        else
        {
            playerToching = false;
            imageDialog.gameObject.SetActive(false);
            txtDialog.gameObject.SetActive(false);
            txt.gameObject.SetActive(false);
        }
    }

    //Find all the object children of a object and return the one that the name is the same as the objectName
    public static GameObject FindInactiveByName(string objectName)
    {
        return Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(go => go.name == objectName && go.scene.isLoaded);
    }
}