using Game.Systems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    private bool paused;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) TogglePause();
    }

    public void TogglePause()
    {
        paused = !paused;
        pauseCanvas.SetActive(paused);
        Time.timeScale = paused ? 0f : 1f;
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        RunData.goldRun = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
