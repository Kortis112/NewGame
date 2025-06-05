using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void TogglePause()
    {
        bool nowPaused = Time.timeScale == 0;
        Time.timeScale = nowPaused ? 1 : 0;
        pausePanel.SetActive(!nowPaused);
    }
}
