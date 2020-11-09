using UnityEngine;

public class RotatingObject : MonoBehaviour
{
	public float DistanceOfRotation;
	public float ObjectRotationSpeed;
	public float CameraRotationSpeed;

	public Transform RotatingObjectTransform;
	public Transform CameraTransform;

	public bool NeedToRotate;
	public float SideSelector = 1;

	public void RotateObject(Vector3 RotationVector)
	{
		RotatingObjectTransform.Rotate(RotationVector);
	}
	public void RotateCamera(Vector3 RotationVector)
	{
		CameraTransform.Rotate(RotationVector);
	}
	public void ChangeSide()
	{
		SideSelector *= -1;
	}
}
