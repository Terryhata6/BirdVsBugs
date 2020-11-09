using UnityEngine;

public class RotationController : MonoBehaviour
{

	private Vector3 _rotationVector;
	private Vector3 _rotationVectorForCamera;
	private float _rotationSpeedMultiplyer = 1f;
	public bool CanRotate;

	//модель которой управляем 
	private RotatingObject _rotatingObjectModel;
	private EnemyEffects _enemyeffects;

	private void Awake()
	{
		_rotatingObjectModel = FindObjectOfType<RotatingObject>();
		_enemyeffects = FindObjectOfType<EnemyEffects>();
	}
	private void Start()
	{
		_rotationVector = new Vector3();
		_rotationVectorForCamera = new Vector3();
		_rotatingObjectModel.NeedToRotate = true;
	}
	void FixedUpdate()
	{
		if (_rotatingObjectModel.NeedToRotate)
		{
			_rotationVector.y = (_rotatingObjectModel.ObjectRotationSpeed * _rotationSpeedMultiplyer * _rotatingObjectModel.SideSelector);
			_rotationVectorForCamera.y = (_rotatingObjectModel.CameraRotationSpeed * _rotationSpeedMultiplyer * _rotatingObjectModel.SideSelector);

			_rotatingObjectModel.RotateObject(_rotationVector);
			_rotatingObjectModel.RotateCamera(_rotationVectorForCamera);

			CountRotationSide();
		}
	}

	private void CountRotationSide()
	{
		if (_rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y >= _rotatingObjectModel.DistanceOfRotation
			&& _rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y < _rotatingObjectModel.DistanceOfRotation + 5
			&& _rotatingObjectModel.SideSelector > 0)
		{
			_rotatingObjectModel.SideSelector *= -1;
		}
		else 
		if (_rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y <= 360 - _rotatingObjectModel.DistanceOfRotation
			&& _rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y > _rotatingObjectModel.DistanceOfRotation
			&& _rotatingObjectModel.SideSelector < 0)
		{
			_rotatingObjectModel.SideSelector *= -1;
		}
	}
	public void MakeRotationGoSlower()
	{
		_rotationSpeedMultiplyer = _enemyeffects.MultiplyerOfFrozen;
		Invoke("MakeRotationGoFaster", _enemyeffects.TimeOfFrozen);
	}
	public void MakeRotationGoFaster()
	{
		_rotationSpeedMultiplyer = 1;
	}
}
