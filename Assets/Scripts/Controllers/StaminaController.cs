using UnityEngine;

public class StaminaController : MonoBehaviour
{
	private StaminaSlider _staminaSlider;
	private EnemyEffects _enemyEffects;
	private UIController _uiController;
	private WinPanelModel _winPanel;
	private Coins _coinsModel;
	private Boss _bossModel;
	private bool _gameEnded;
	private void Awake()
	{
		_staminaSlider = FindObjectOfType<StaminaSlider>();
		_enemyEffects = FindObjectOfType<EnemyEffects>();
		_uiController = FindObjectOfType<UIController>();
		_winPanel = FindObjectOfType<WinPanelModel>();
		_coinsModel = FindObjectOfType<Coins>();
		_bossModel = FindObjectOfType<Boss>();
		_staminaSlider.BasicStaminaOffMultiplyer = _staminaSlider.StaminaOffMultiplyer;
	}
	private void FixedUpdate()
	{
		_staminaSlider.ReduceStaminaByTime();
		if(_staminaSlider.BirdPower <= 0 && !_gameEnded)
		{
			if (_bossModel.IsBossFightNow)
			{
				_uiController.WinGame();
				_winPanel.ActivateWinPanel(_bossModel.BossNumber);
				_coinsModel.AddCoinsCollectedOnLvl(); 
				_gameEnded = true;
			}
			else
			{
				_uiController.LoseGame();
				_gameEnded = true;
			}
		}
	}
	public void MakeStaminaGoOffFaster()
	{
		_staminaSlider.StaminaOffMultiplyer = _enemyEffects.MultiplyerOfPoisoned;
		Invoke("MakeStaminaGoOffSlower", _enemyEffects.TimeOfPoisoned);
	}
	private void MakeStaminaGoOffSlower()
	{
		_staminaSlider.StaminaOffMultiplyer = _staminaSlider.BasicStaminaOffMultiplyer;
	}
}
