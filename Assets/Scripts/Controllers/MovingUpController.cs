using UnityEngine;

public class MovingUpController : MonoBehaviour
{
    private MovingUpObjects _movingUpModel;

    private void Awake()
    {
        _movingUpModel = FindObjectOfType<MovingUpObjects>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _movingUpModel.MoveObjectsUp();
        }
    }
    public void MoveObjectsUp()
    {
        _movingUpModel.MoveObjectsUp();
    }
}
