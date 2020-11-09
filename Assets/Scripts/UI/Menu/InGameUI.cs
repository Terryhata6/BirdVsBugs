using UnityEngine;
using UnityEngine.UI;

public class InGameUI : BaseMenu
{
    [Header("Panel of In Game UI")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Pause button")]
    [SerializeField] private ButtonUI _pauseButton;

    [Header("Coins Text")]
    [SerializeField] private TextUI _coinsText;

    [Header("Dark Coins Text")]
    [SerializeField] private TextUI _darkCoinsText;

    private UIController _uiController;

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();

        _pauseButton.GetControl.onClick.AddListener(delegate
        {
            _uiController.PauseGame();
        });
    }

    public Text GetCoinsText()
    {
        return _coinsText.GetControll();
    }
    public Text GetDarkCoinsText()
    {
        return _darkCoinsText.GetControll();
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
