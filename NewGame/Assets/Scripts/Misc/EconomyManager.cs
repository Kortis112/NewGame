using UnityEngine;
using TMPro;
using Game.Systems;
using UnityEngine.SceneManagement;

public class EconomyManager : Singleton<EconomyManager>
{
    [Header("UI Reference (заполните в префабе Canvas)")]
    [SerializeField] private TMP_Text goldText;

    public int CurrentGold { get; private set; }

   private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
   private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

   private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
   {
       // ищем новое поле HUD после смены уровня
       if (goldText == null || !goldText)      // учтём разрушенный объект
           goldText = GameObject.Find("Gold Amount Text")?
                                 .GetComponent<TMP_Text>();

       RefreshUI();                            // пересчитать цифру
   }
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
    public void SpendGold(int amount)
    {
       if (CurrentGold<amount) return;
       CurrentGold    -= amount;
       RunData.goldRun = CurrentGold;
       RefreshUI();
    }
    public void ResetRun()
    {
        CurrentGold = 0;
        RunData.goldRun = 0;
        RefreshUI();                       // поставит 000 на HUD (если есть)
    }

    private void RefreshUI()
   {
    if (goldText == null || !goldText) return;
    goldText.text = CurrentGold.ToString("D3");
   }


public void UpdateCurrentGold() => AddGold();


    public void SaveRunResults()
    {
        int total = PlayerPrefs.GetInt("GoldTotal", 0) + RunData.goldRun;
        PlayerPrefs.SetInt("GoldTotal", total);
        PlayerPrefs.Save();
    }
}
