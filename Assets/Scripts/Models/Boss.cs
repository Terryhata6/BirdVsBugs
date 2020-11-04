using UnityEngine;

public class Boss : MonoBehaviour
{
	public BossVariant[] BossesVariants;
	public float RotationSpeedMyltiplyerForBossBattle;
	public float StaminaMyltiplyerForBossBattle;
	public bool NeedToStartBossBattle;
	public bool IsBossFightNow;

	private GameObject _bossModel;
	private Animator _bossAnimator;
	private string[] _bossesTriggerManager;


	public void SelectBossForThisLvl()
	{
		int num = Random.Range(0, BossesVariants.Length - 1);
		BossesVariants[num].Boss3DModel.SetActive(true);
		_bossModel = BossesVariants[num].Boss3DModel;
		_bossAnimator = _bossModel.GetComponentInChildren<Animator>();
	}
	public void SetTriggerManager()
	{
		_bossesTriggerManager = new string[3]; 
		_bossesTriggerManager[0] = "Damage1";
		_bossesTriggerManager[1] = "Damage2";
		_bossesTriggerManager[2] = "Damage3";
	}
	public void BossGetDamage()
	{
		_bossAnimator.SetTrigger(_bossesTriggerManager[Random.Range(0, _bossesTriggerManager.Length)]);
	}
}
