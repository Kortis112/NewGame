using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Systems;

public class DeathScreenUI : MonoBehaviour
{
    [Header("Ссылки на текстовые поля")]
    [SerializeField] private TextMeshProUGUI runGoldText;
    [SerializeField] private TextMeshProUGUI totalGoldText;
    [SerializeField] private TextMeshProUGUI runsText;

    private void Start()
    {
        EconomyManager.Instance.SaveRunResults();   // ← новая строка
        RunData.runFinished = true;

        runGoldText.text = $"Gold this run : {RunData.goldRun}";
        totalGoldText.text = $"Gold total    : {PlayerPrefs.GetInt("GoldTotal", 0)}";
        runsText.text = $"Runs total    : {PlayerPrefs.GetInt("RunsTotal", 0)}";
    }

    // Кнопка «Retry»
    public void Retry()
    {
        RunData.goldRun = 0;
        RunData.hpCur = 0;
        RunData.hpMax = 0;
        RunData.staminaCur = 0;
        RunData.activeSlot = 0;                    // обнуляем золото забега
        SceneManager.LoadScene("Fight1");         // загружаем первый бой
    }

    // Кнопка «Main Menu»
    public void GoMainMenu() =>
        SceneManager.LoadScene("MainMenu");
}
