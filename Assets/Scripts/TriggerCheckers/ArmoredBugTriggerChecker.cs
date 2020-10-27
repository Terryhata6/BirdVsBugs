using UnityEngine;

public class ArmoredBugTriggerChecker : MonoBehaviour
{
	public GameObject Shield;
	private EatingBugsController _eatingController;
	[SerializeField] private bool _hasShield = true;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (_hasShield)
		{
			_hasShield = false;
			Shield.SetActive(false);
			_eatingController.EatSomething();
		}
		else
		{
			_eatingController.EatBug(this.gameObject);
		}
	}
}
