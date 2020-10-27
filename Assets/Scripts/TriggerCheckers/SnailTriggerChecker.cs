using UnityEngine;

public class SnailTriggerChecker : MonoBehaviour
{
	private RotationController _rotationController;
	private EatingBugsController _eatingController;
	private void Awake()
	{
		_rotationController = FindObjectOfType<RotationController>();
		_eatingController = FindObjectOfType<EatingBugsController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_rotationController.MakeRotationGoSlower();
		_eatingController.EatSomething();
		Destroy(this.gameObject);
	}
}
