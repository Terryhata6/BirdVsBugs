using UnityEngine;

public class EatingBugsController : MonoBehaviour
{
	public float WaitTimeBeforeCheckingCollisionWithTree;
	public int[] BugsOnLvl;

	private InputController _inputController;

	private EatingModel _eatingModel;
	private MovingUpObjects _movingUpObjects;
	private StaminaSlider _staminaSlider;
	private AnimatorsModel _animatorsModel;
	private Coins _coins;
	private Boss _bossModel;

	[SerializeField] private int _currentLvl = 0;
	private bool _nothingWasEaten = true;

	private void Awake()
	{
		_eatingModel = FindObjectOfType<EatingModel>();
		_movingUpObjects = FindObjectOfType<MovingUpObjects>();
		_inputController = FindObjectOfType<InputController>();
		_staminaSlider = FindObjectOfType<StaminaSlider>();
		_animatorsModel = FindObjectOfType<AnimatorsModel>();
		_bossModel = FindObjectOfType<Boss>();
		_coins = FindObjectOfType<Coins>();
	}
	private void Start()
	{
		BugsOnLvl = _eatingModel.BugsOnLvls;
	}
	private void FixedUpdate()
	{
		if (_inputController.DragingStarted && !_eatingModel.IsBiting && _eatingModel.СanBiteAgain)
		{
			_nothingWasEaten = true;
			_eatingModel.IsBiting = true;
			_eatingModel.СanBiteAgain = false;
			_animatorsModel.MakeBiteAnimation();
			if (_bossModel.IsBossFightNow)
			{
				_bossModel.BossGetDamage();
			}
			Invoke("ReduceStamina", WaitTimeBeforeCheckingCollisionWithTree);
		}
		if (!_inputController.DragingStarted && !_eatingModel.СanBiteAgain)
		{
			_eatingModel.СanBiteAgain = true;
		}
		if (_eatingModel.IsBiting)
		{
			_eatingModel.MakeBite();
		}
	}
	public void EatBug(GameObject BugObject)
	{
		_coins.AddCoin();
		Destroy(BugObject);
		_nothingWasEaten = false;
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
			_bossModel.StartBossBattle();
		}
		_staminaSlider.IncreaseStaminaByNum(_eatingModel.EnergyBySingleBug);
	}
	public void EatSomething()
	{
		_nothingWasEaten = false;
	}
	private void ReduceStamina()
	{
		if (_nothingWasEaten)
		{
			if (!_bossModel.IsBossFightNow)
			{
				_staminaSlider.ReduceStaminaByNum(10);
			}
			_nothingWasEaten = false;
		}
	}
}
