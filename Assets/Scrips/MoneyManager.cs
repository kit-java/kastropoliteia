using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoneyManager : MonoBehaviour
{
    private float moneyAmound = 2000;
    private List<TextMeshProUGUI> allMoneyDisplay;
    private bool playFlash = true;

    public List<TextMeshProUGUI> noMoneyDisplay;
    public float flashtimer = 0.3f;
    public int flashCount = 3;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        allMoneyDisplay = new List<TextMeshProUGUI>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        allMoneyDisplay.Clear();
        noMoneyDisplay.Clear();
        TextMeshProUGUI[] allObjects = GameObject.FindObjectsOfType<TextMeshProUGUI>(true);

        foreach (TextMeshProUGUI obj in allObjects)
        {
            if (obj.name == "MoneyNumber")
            {
                allMoneyDisplay.Add(obj);
            }

            if (obj.name == "NoMoney")
            {
                noMoneyDisplay.Add(obj);
            }
        }

        UpdateUI();
    }

    public float getMoney() {
        return moneyAmound;
    }
    public void removeMoney(float myRemove) { 
        moneyAmound -= myRemove;
        UpdateUI();
    }

    public void addMoney(float myAdd) { 
        moneyAmound += myAdd;
        UpdateUI();
    }

    public bool IsEnough(float check) {
        if (moneyAmound >= check)
        {
            return true;
        }

        if (noMoneyDisplay != null)
        {
            foreach (TextMeshProUGUI obj in noMoneyDisplay) 
            {
                StartCoroutine(FlashText(obj, false));
            }
        }

        return false;
    }

    void UpdateUI(){
        foreach (TextMeshProUGUI obj in allMoneyDisplay) {
            obj.text = moneyAmound.ToString();
            
            if (playFlash)
                StartCoroutine(FlashText(obj, true));
        }

        playFlash = false;
    }

    private IEnumerator FlashText(TextMeshProUGUI txt, bool finalFlash)
    {
        for (int i = 0; i < flashCount; i++)
        {
            if (txt.IsActive())
            {
                txt.enabled = false; // turn off
                yield return new WaitForSeconds(flashtimer);
            }
            else
            {
                txt.enabled = true; // turn on
                yield return new WaitForSeconds(flashtimer);
            }
        }
        if (finalFlash)
        {
            txt.enabled = true;
        }
        else
        {
            txt.enabled = false;
        }

        if (txt.name == "MoneyNumber")
        {
            playFlash = true;
        }
    }
}
