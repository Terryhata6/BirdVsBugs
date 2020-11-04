using UnityEngine;

public class StaminaController : MonoBehaviour
{
	private StaminaSlider _staminaSlider;
	private EnemyEffects _enemyEffects;
	private Boss _bossModel;
	private SceneController _sceneController;
	private void Awake()
	{
		_staminaSlider = FindObjectOfType<StaminaSlider>();
		_enemyEffects = FindObjectOfType<EnemyEffects>();
		_sceneController = FindObjectOfType<SceneController>();
		_bossModel = FindObjectOfType<Boss>();
	}
	private void FixedUpdate()
	{
		_staminaSlider.ReduceStaminaByTime();
		if(_staminaSlider.BirdPower <= 0)
		{
			if (_bossModel.IsBossFightNow)
			{
				_sceneController.ActivateWinPanel();
			}
			else
			{
				_sceneController.ActivateLosePanel();
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
		_staminaSlider.StaminaOffMultiplyer = 1;
	}
}
