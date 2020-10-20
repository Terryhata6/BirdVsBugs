using UnityEngine;

public class RotationController : MonoBehaviour
{

	private Vector3 _rotationVector;
	private Vector3 _rotationVectorForCamera;
	private float _sideSelector = 1;
	public bool CanRotate;

	//модель которой управляем 
	private RotatingObject _rotatingObjectModel;

	private void Awake()
	{
		_rotatingObjectModel = FindObjectOfType<RotatingObject>();
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
			_rotationVector.y = (_rotatingObjectModel.ObjectRotationSpeed * _sideSelector);
			_rotationVectorForCamera.y = (_rotatingObjectModel.CameraRotationSpeed * _sideSelector);

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

	public void MoveUp()
	{
		_rotatingObjectModel.RotatingObjectTransform.position += new Vector3(0, 1.5f, 0);
		_rotatingObjectModel.CameraTransform.position += new Vector3(0, 1.5f, 0);
	}
}
