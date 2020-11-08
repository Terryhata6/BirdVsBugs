using UnityEngine;

public class LoseGameMenu : BaseMenu
{
    [Header("Panel of Lose Game Menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _restartButton;
    [SerializeField] private ButtonUI _exitButton;

    public override void Hide()
    {
        if (!IsShow) return;
        _mainPanel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _mainPanel.gameObject.SetActive(true);
        IsShow = true;
    }
}
