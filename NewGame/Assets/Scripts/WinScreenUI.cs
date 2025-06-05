using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Systems;

public class WinScreenUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI runGold;
    [SerializeField] TextMeshProUGUI totalGold;
    [SerializeField] TextMeshProUGUI runs;

    private void Start()
    {
        // фиксируем результаты ровно ОДИН раз
        EconomyManager.Instance.SaveRunResults();
        PlayerPrefs.SetInt("RunsTotal", PlayerPrefs.GetInt("RunsTotal", 0) + 1);
        PlayerPrefs.Save();

        runGold.text = $"Gold this run : {RunData.goldRun}";
        totalGold.text = $"Gold total    : {PlayerPrefs.GetInt("GoldTotal")}";
        runs.text = $"Runs total    : {PlayerPrefs.GetInt("RunsTotal")}";
    }

    public void Retry()
    {
        RunData.goldRun = 0;
        RunData.hpCur = 0;
        RunData.hpMax = 0;
        RunData.staminaCur = 0;
        RunData.activeSlot = 0;
        RunData.runFinished = false;
        EconomyManager.Instance.ResetRun();
        SceneManager.LoadScene("Fight1");
    }
    public void MainMenu()
    {
        RunData.goldRun = 0;
        RunData.runFinished = false;
        EconomyManager.Instance.ResetRun();
        SceneManager.LoadScene("MainMenu");
    }
}
