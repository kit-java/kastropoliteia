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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Unlocks a new dialog and stores it as an achievement.
    /// </summary>
    public void UnlockDialog(string sceneName, string dialogLine)
    {
        // Prevent duplicates
        if (!unlockedDialogs.Exists(d => d.scene == sceneName && d.text == dialogLine))
        {
            unlockedDialogs.Add(new UnlockedDialog { scene = sceneName, text = dialogLine });
            Debug.Log($"Unlocked new dialog-achievement: [{sceneName}] {dialogLine}");
        }
    }

    /// <summary>
    /// Toggle the achievements panel (show/hide).
    /// </summary>
    public void ToggleAchievements()
    {
        if (achievementsPanel == null) return;

        achievementsPanel.SetActive(!achievementsPanel.activeSelf);

        if (achievementsPanel.activeSelf)
            RefreshUI();
    }

    /// <summary>
    /// Refresh the achievements panel with all unlocked dialogs.
    /// </summary>
    private void RefreshUI()
    {
        achievementsText.text = "";
        foreach (var d in unlockedDialogs)
        {
            achievementsText.text += $"[{d.scene}] ✔ {d.text}\n";
        }
    }
}
