using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EatingBugsController : MonoBehaviour
{
    private MovingUpController _movingUpController;
    private EatingModel _eatingModel;
    private MovingUpObjects _movingUpObjects;
    private InputController _inputController;
    public int[] BugsOnLvl;
    public Slider PowerSlider;
    private int _currentLvl = 0;
    private float BirdPower = 50;

    private void Awake()
    {
        _eatingModel = FindObjectOfType<EatingModel>();
        _movingUpObjects = FindObjectOfType<MovingUpObjects>();
        _movingUpController = FindObjectOfType<MovingUpController>();
        _inputController = FindObjectOfType<InputController>();
    }
    private void Start()
    {
        BugsOnLvl = _eatingModel.BugsOnLvls;
    }
    private void FixedUpdate()
    {
        if (_inputController.DragingStarted && !_eatingModel.IsBiting && _eatingModel.СanBiteAgain)
        {
            EatNothing();
            _eatingModel.IsBiting = true;
            _eatingModel.СanBiteAgain = false;
        }
        if (!_inputController.DragingStarted && !_eatingModel.СanBiteAgain)
        {
            _eatingModel.СanBiteAgain = true;
        }
        if (_eatingModel.IsBiting)
        {
            _eatingModel.MakeBite();
        }

        BirdPower -= Time.deltaTime * 4f;
        PowerSlider.value = BirdPower / 50;
        if (BirdPower <= 0)
        {
            RestartLvl();
        }
    }
    public void EatBug(GameObject BugObject)
    {
        Destroy(BugObject);
        if(BugsOnLvl.Length - _currentLvl == 9)
        {
            _movingUpObjects.NeedToMoveOnlyCharacter = true;
        }
        BugsOnLvl[_currentLvl]--;
        if(BugsOnLvl[_currentLvl] <= 0)
        {
            _currentLvl++;
            _movingUpController.MoveObjectsUp();
        }
        BirdPower += 15;
        if(BirdPower > 50)
        {
            BirdPower = 50;
        }
    }
    public void EatSomething()
    {
        BirdPower += 10;
    } 
    public void EatNothing()
    {
        BirdPower -= 10;
    } 
    private void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
