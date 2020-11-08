using UnityEngine;

public class UIController : MonoBehaviour
{
    private StartGameMenu _startGameMenu;
    private InGameUI _inGameUI;
    private PauseMenu _pauseMenu;
    private WinGameMenu _winGameMenu;
    private LoseGameMenu _loseGameMenu;

    private void Start()
    {
        Time.timeScale = 0;

        _startGameMenu = GetComponentInChildren<StartGameMenu>();
        _inGameUI = GetComponentInChildren<InGameUI>();
        _pauseMenu = GetComponentInChildren<PauseMenu>();
        _winGameMenu = GetComponentInChildren<WinGameMenu>();
        _loseGameMenu = GetComponentInChildren<LoseGameMenu>();

        SwitchUI(UIState.StartGame);
    }

    public void SwitchUI(UIState state)
    {
        switch (state)
        {
            case UIState.StartGame:
                _startGameMenu.Show();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _winGameMenu.Hide();
                _loseGameMenu.Hide();
                break;
            case UIState.InGame:
                _startGameMenu.Hide();
                _inGameUI.Show();
                _pauseMenu.Hide();
                _winGameMenu.Hide();
                _loseGameMenu.Hide();
                break;
            case UIState.Pause:
                _startGameMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Show();
                _winGameMenu.Hide();
                _loseGameMenu.Hide();
                break;
            case UIState.WinGame:
                _startGameMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _winGameMenu.Show();
                _loseGameMenu.Hide();
                break;
            case UIState.LoseGame:
                _startGameMenu.Hide();
                _inGameUI.Hide();
                _pauseMenu.Hide();
                _winGameMenu.Hide();
                _loseGameMenu.Show();
                break;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SwitchUI(UIState.InGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SwitchUI(UIState.Pause);
    }
    public void LoseGame()
    {
        Time.timeScale = 0;
        SwitchUI(UIState.LoseGame);
    }
    public void WinGame()
    {
        //Time.timeScale = 0;
        SwitchUI(UIState.WinGame);
    }
}
