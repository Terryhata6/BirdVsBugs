using UnityEngine;

public class StartGameMenu : BaseMenu
{
    [Header("Panel of Main Menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Tap to start button")]
    [SerializeField] private ButtonUI _tapToStart;

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
