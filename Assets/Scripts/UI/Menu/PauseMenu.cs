using UnityEngine;

public class PauseMenu : BaseMenu
{
    [Header("Panel of Pause Menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _continueButton;
    [SerializeField] private ButtonUI _restartButton;
    [SerializeField] private ButtonUI _exitButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();

        _continueButton.GetControl.onClick.AddListener(delegate
       {
           _uiController.StartGame();
       });
        _restartButton.GetControl.onClick.AddListener(delegate
        {
            //TODO
        });
        _exitButton.GetControl.onClick.AddListener(delegate
        {
            //TODO
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
