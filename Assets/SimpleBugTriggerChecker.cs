using UnityEngine;

public class SimpleBugTriggerChecker : MonoBehaviour
{
	private EatingBugsController _eatingController;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_eatingController.EatBug(this.gameObject);
	}
}
