using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class PortalExit : MonoBehaviour
{
    [SerializeField] private string targetScene;      // куда грузить

    /**  Вызывает PortalActivator  */
    public void Init(string sceneName)
    {
        targetScene = sceneName;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.GetComponent<PlayerController>()) return;
        SceneManager.LoadScene(targetScene);
    }
}
