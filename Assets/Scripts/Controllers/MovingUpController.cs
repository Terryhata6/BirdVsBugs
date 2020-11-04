using UnityEngine;

public class MovingUpController : MonoBehaviour
{
    private MovingUpObjects _movingUpModel;

    private void Awake()
    {
        _movingUpModel = FindObjectOfType<MovingUpObjects>();
    }
    public void MoveObjectsUp()
    {
        _movingUpModel.MoveObjectsUp();
    }
}
