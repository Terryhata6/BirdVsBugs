using UnityEngine;

public class PauseMenu : BaseMenu
{
    [Header("Panel of Pause Menu")]
    [SerializeField] private GameObject _mainPanel;

    [Header("Buttons")]
    [SerializeField] private ButtonUI _continueButton;

    private UIController _uiController;

    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();

        _continueButton.GetControl.onClick.AddListener(delegate
       {
           _uiController.StartGame();
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
