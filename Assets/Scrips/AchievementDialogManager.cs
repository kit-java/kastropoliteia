using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class UnlockedDialog
{
    public string scene;
    public string text;
}

public class AchievementDialogManager : MonoBehaviour
{
    public static AchievementDialogManager Instance;

    [Header("UI References")]
    [SerializeField] private GameObject achievementsPanel;   // Panel with ScrollView
    [SerializeField] private TextMeshProUGUI achievementsText; // Text inside ScrollView

    private List<UnlockedDialog> unlockedDialogs = new List<UnlockedDialog>();
    private MoneyManager moneyManager;

    public void UnlockDialog(string sceneName, string dialogLine)
    {
        // Prevent duplicates
        if (!unlockedDialogs.Exists(d => d.scene == sceneName && d.text == dialogLine))
        {
            unlockedDialogs.Add(new UnlockedDialog { scene = sceneName, text = dialogLine });

            moneyManager = GameObject.Find("MoneyManager").GetComponent<MoneyManager>();
            if (moneyManager != null )
                moneyManager.addMoney(100);

            RefreshUI();
        }
    }

    public void ToggleAchievements()
    {
        if (achievementsPanel == null) return;

        achievementsPanel.SetActive(!achievementsPanel.activeSelf);

        if (achievementsPanel.activeSelf)
            RefreshUI();
    }

    private void RefreshUI()
    {
        achievementsText.text = "";
        foreach (var d in unlockedDialogs)
        {
            achievementsText.text += $"[{d.scene}] : {d.text}\n\n";
        }
    }
}
