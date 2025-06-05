using UnityEngine;
using TMPro;
using Game.Systems;

public class EconomyManager : Singleton<EconomyManager>
{
    [Header("UI Reference (заполните в префабе Canvas)")]
    [SerializeField] private TMP_Text goldText;

    public int CurrentGold { get; private set; }

    public void AddGold(int amount = 1)
    {
        CurrentGold += amount;
        RunData.goldRun = CurrentGold;

        if (goldText == null)
            goldText = GameObject.Find("Gold Amount Text")?.GetComponent<TMP_Text>();

        if (goldText != null)
            goldText.text = CurrentGold.ToString("D3");
        else
            Debug.LogWarning("EconomyManager: Gold Text not found!");
    }


    public void UpdateCurrentGold() => AddGold();


    public void SaveRunResults()
    {
        int total = PlayerPrefs.GetInt("GoldTotal", 0) + RunData.goldRun;
        PlayerPrefs.SetInt("GoldTotal", total);
        PlayerPrefs.Save();
    }
}
