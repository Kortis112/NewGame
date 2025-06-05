using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Game.Systems;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI runsText;

    private void Start()
    {
        goldText.text = $"Gold total: {PlayerPrefs.GetInt("GoldTotal",0)}";
        runsText.text = $"Runs total: {PlayerPrefs.GetInt("RunsTotal",0)}";
    }

    public void StartGame()
    {
        // очистить состояние прошлого забега
        RunData.goldRun = 0;
        RunData.hpCur = 0;
        RunData.hpMax = 0;
        RunData.staminaCur = 0;
        RunData.activeSlot = 0;

        SceneManager.LoadScene("Fight1");
    }   // первый бой
    public void QuitGame()  => Application.Quit();

}
