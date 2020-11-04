using UnityEngine;

public class RotationController : MonoBehaviour
{

	private Vector3 _rotationVector;
	private Vector3 _rotationVectorForCamera;
	private float _sideSelector = 1;
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
		CanRotate = true;
	}
	void FixedUpdate()
	{
		if (CanRotate)
		{
			_rotationVector.y = (_rotatingObjectModel.ObjectRotationSpeed * _rotationSpeedMultiplyer * _sideSelector);
			_rotationVectorForCamera.y = (_rotatingObjectModel.CameraRotationSpeed * _rotationSpeedMultiplyer * _sideSelector );

			_rotatingObjectModel.RotateObject(_rotationVector);
			_rotatingObjectModel.RotateCamera(_rotationVectorForCamera);

			CountRotationSide();
		}
	}

	private void CountRotationSide()
	{
		if (_rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y >= _rotatingObjectModel.DistanceOfRotation
			&& _rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y < _rotatingObjectModel.DistanceOfRotation + 5
			&& _sideSelector > 0)
		{
			_sideSelector *= -1;
		}
		else 
		if (_rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y <= 360 - _rotatingObjectModel.DistanceOfRotation
			&& _rotatingObjectModel.RotatingObjectTransform.rotation.eulerAngles.y > _rotatingObjectModel.DistanceOfRotation
			&& _sideSelector < 0)
		{
			_sideSelector *= -1;
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
