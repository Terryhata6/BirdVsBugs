using UnityEngine;

public class RotatingObject : MonoBehaviour
{
	public float DistanceOfRotation;
	public float ObjectRotationSpeed;
	public float CameraRotationSpeed;

	public Transform RotatingObjectTransform;
	public Transform CameraTransform;

	public void RotateObject(Vector3 RotationVector)
	{
		RotatingObjectTransform.Rotate(RotationVector);
	}
	public void RotateCamera(Vector3 RotationVector)
	{
		CameraTransform.Rotate(RotationVector);
	}
}
