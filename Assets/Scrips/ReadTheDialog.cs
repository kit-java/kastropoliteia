using System.Collections.Generic;
using UnityEngine;

class LinesOfCSV {
    public int dialogNumber { get; set; }
    public string dialog { get; set; }
}

public class ReadTheDialog : MonoBehaviour
{
    public string pathName = string.Empty;
    private List<LinesOfCSV> myDialog = new List<LinesOfCSV>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
