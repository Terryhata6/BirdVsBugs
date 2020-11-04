using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LosePanel;
    public void ActivateWinPanel()
    {
        WinPanel.SetActive(true);
    }
    public void ActivateLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void LoadNextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
