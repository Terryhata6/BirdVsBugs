using UnityEngine;

public class RotateAroundCylindr : MonoBehaviour
{
	public float DistanceOfRotation;
	public float BirdRotationSpeed;
	public float CameraRotationSpeed;
	public bool CanRotate;
	private float _sideSelector = 1;
	private Vector3 _rotationVector;
	private Transform _playerTransform;
	public Transform CameraTransform;
	private void Start()
	{
		_playerTransform = GetComponent<Transform>();
		_rotationVector = new Vector3();
		CanRotate = true;
	}
	void FixedUpdate()
	{
		if (CanRotate)
		{
			RotateFromSideToSide();
		}
	}

	private void RotateFromSideToSide()
	{
		//
		_rotationVector.y = (BirdRotationSpeed * _sideSelector);
		_playerTransform.Rotate(_rotationVector);

		_rotationVector.y = (CameraRotationSpeed * _sideSelector);
		CameraTransform.Rotate(_rotationVector);

		if (_playerTransform.rotation.eulerAngles.y >= DistanceOfRotation
			&& _playerTransform.rotation.eulerAngles.y < DistanceOfRotation + 5
			&& _sideSelector > 0)
		{
			_sideSelector *= -1;
		}
		else 
		if (_playerTransform.rotation.eulerAngles.y <= 360 - DistanceOfRotation
			&& _playerTransform.rotation.eulerAngles.y > DistanceOfRotation
			&& _sideSelector < 0)
		{
			_sideSelector *= -1;
		}
	}

	public void MoveUp()
	{
		_playerTransform.position += new Vector3(0, 1.5f, 0);
		CameraTransform.position += new Vector3(0, 1.5f, 0);
	}
}
