using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI runsText;

    private void Start()
    {
        goldText.text = $"Gold total: {PlayerPrefs.GetInt("GoldTotal",0)}";
        runsText.text = $"Runs total: {PlayerPrefs.GetInt("RunsTotal",0)}";
    }

    public void StartGame() => SceneManager.LoadScene("Fight1");   // первый бой
    public void QuitGame()  => Application.Quit();
}
