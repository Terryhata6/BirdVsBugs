using UnityEngine;

public class InGameUI : BaseMenu
{
    [Header("Panel of In Game UI")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Pause button")]
    [SerializeField] private ButtonUI _pauseButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();

        _pauseButton.GetControl.onClick.AddListener(delegate
        {
            _uiController.PauseGame();
        });
    }

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
