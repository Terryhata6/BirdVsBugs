using UnityEngine;
using TapticPlugin;

public class EatingBugsController : MonoBehaviour
{
	public int[] BugsOnLvl;


	private SampleUI _sampleUI;
	private InputController _inputController;
	private EatingModel _eatingModel;
	private MovingUpObjects _movingUpObjects;
	private StaminaSlider _staminaSlider;
	private AnimatorsModel _animatorsModel;
	private ParticlesController _particlesController;
	private SoundController _soundController;
	private Coins _coins;
	private Boss _bossModel;
	private int _currentLvl = 0;
	private bool _nothingWasEaten = true;
	private bool _bitingEnded = true;

	private void Awake()
	{
		_eatingModel = FindObjectOfType<EatingModel>();
		_movingUpObjects = FindObjectOfType<MovingUpObjects>();
		_inputController = FindObjectOfType<InputController>();
		_staminaSlider = FindObjectOfType<StaminaSlider>();
		_animatorsModel = FindObjectOfType<AnimatorsModel>();
		_particlesController = FindObjectOfType<ParticlesController>();
		_soundController = FindObjectOfType<SoundController>();
		_bossModel = FindObjectOfType<Boss>();
		_coins = FindObjectOfType<Coins>();
		_sampleUI = FindObjectOfType<SampleUI>();
	}
	private void Start()
	{
		BugsOnLvl = _eatingModel.BugsOnLvls;
	}
	private void Update()
	{
		if (_inputController.InputStarted && !_eatingModel.IsBiting && _eatingModel.СanBiteAgain && _eatingModel.СanBiteAtAll)
		{
			_nothingWasEaten = true;
			_eatingModel.IsBiting = true;
			_eatingModel.СanBiteAgain = false;
			_animatorsModel.MakeBiteAnimation();
			_bitingEnded = false;
			if (_bossModel.IsBossFightNow)
			{	
				if(_eatingModel.SpeedOfBiting != _eatingModel.SpeedOfBitingForBossBattle)
				{
					_eatingModel.SpeedOfBiting = _eatingModel.SpeedOfBitingForBossBattle;
				}
				_soundController.PlayEatSomethingSound();
				_bossModel.BossGetDamage();
				_particlesController.PlayBossParticles();
				_coins.AddCoin();
			}
		}
		if (!_inputController.InputStarted && !_eatingModel.СanBiteAgain)
		{
			_eatingModel.СanBiteAgain = true;
		}
		if (_eatingModel.BiteWasMade && !_bitingEnded)
		{
			BiteTree();
		}
	}
	private void FixedUpdate()
	{
		if (_eatingModel.IsBiting)
		{
			_eatingModel.MakeBite();
		}
	}
	public void EatBug(GameObject BugObject)
	{
		_sampleUI.OnImpactClick(2);
		_coins.AddCoin();
		Destroy(BugObject);
		_nothingWasEaten = false;
		_soundController.PlayEatSomethingSound();
		if (BugsOnLvl.Length - _currentLvl == 9)
		{
			_movingUpObjects.NeedToMoveOnlyCharacter = true;
		}
		if (BugsOnLvl.Length - _currentLvl == 1)
		{
			_movingUpObjects.MovingUpAmount = 2f;
		}
		BugsOnLvl[_currentLvl]--;
		if (BugsOnLvl[_currentLvl] <= 0)
		{
			_currentLvl++;
			_movingUpObjects.MoveObjectsUp();
		}
		if (BugsOnLvl.Length - _currentLvl == 0)
		{
			_bossModel.NeedToStartBossBattle = true;
		}
		//_staminaSlider.IncreaseStaminaByNum(_eatingModel.EnergyBySingleBug);
	}
	public void EatSomething()
	{
		_sampleUI.OnImpactClick(1);
		_soundController.PlayEatSomethingSound();
		_nothingWasEaten = false;
	}
	private void BiteTree()
	{
		if (_nothingWasEaten)
		{
			if (!_bossModel.IsBossFightNow)
			{
				_sampleUI.OnImpactClick(0);
				_soundController.PlayHitTreeSound();
			}
			if (_bossModel.IsBossFightNow)
			{
				//_staminaSlider.ReduceStaminaByNum(_eatingModel.EnergyMissClick);
				_sampleUI.OnImpactClick(2);
			}
			_nothingWasEaten = false;
		}
		_bitingEnded = true;
	}
}
