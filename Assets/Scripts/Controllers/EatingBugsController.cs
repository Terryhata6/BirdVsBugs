using UnityEngine;

public class EatingBugsController : MonoBehaviour
{
    public float WaitTimeBeforeCheckingCollisionWithTree;
    public int[] BugsOnLvl;

    private MovingUpController _movingUpController;
    private EatingModel _eatingModel;
    private MovingUpObjects _movingUpObjects;
    private InputController _inputController;
    private StaminaSlider _staminaSlider;
    private AnimatorsModel _animatorsModel;
    private int _currentLvl = 0;
    private bool _nothingWasEaten = true;

    private void Awake()
    {
        _eatingModel = FindObjectOfType<EatingModel>();
        _movingUpObjects = FindObjectOfType<MovingUpObjects>();
        _movingUpController = FindObjectOfType<MovingUpController>();
        _inputController = FindObjectOfType<InputController>();
        _staminaSlider = FindObjectOfType<StaminaSlider>();
        _animatorsModel = FindObjectOfType<AnimatorsModel>();
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
        Destroy(BugObject); 
        _nothingWasEaten = false;
        if (BugsOnLvl.Length - _currentLvl == 9)
        {
            _movingUpObjects.NeedToMoveOnlyCharacter = true;
        }
        BugsOnLvl[_currentLvl]--;
        if(BugsOnLvl[_currentLvl] <= 0)
        {
            _currentLvl++;
            _movingUpController.MoveObjectsUp();
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
            _staminaSlider.ReduceStaminaByNum(10);
            _nothingWasEaten = false;
        }
    } 
}
