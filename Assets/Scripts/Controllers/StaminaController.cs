using UnityEngine;

public class StaminaController : MonoBehaviour
{
	private StaminaSlider _staminaSlider;
	private EnemyEffects _enemyEffects;
	private Boss _bossModel;
	private UIController _uiController;
	private void Awake()
	{
		_staminaSlider = FindObjectOfType<StaminaSlider>();
		_enemyEffects = FindObjectOfType<EnemyEffects>();
		_uiController = FindObjectOfType<UIController>();
		_bossModel = FindObjectOfType<Boss>();
		_staminaSlider.BasicStaminaOffMultiplyer = _staminaSlider.StaminaOffMultiplyer;
	}
	private void FixedUpdate()
	{
		_staminaSlider.ReduceStaminaByTime();
		if(_staminaSlider.BirdPower <= 0)
		{
			if (_bossModel.IsBossFightNow)
			{
				_uiController.WinGame();
			}
			else
			{
				_uiController.LoseGame();
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
