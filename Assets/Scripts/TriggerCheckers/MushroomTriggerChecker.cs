using UnityEngine;

public class MushroomTriggerChecker : MonoBehaviour
{
	private StaminaController _staminaController;
	private EatingBugsController _eatingController;
	private void Awake()
	{
		_staminaController = FindObjectOfType<StaminaController>();
		_eatingController = FindObjectOfType<EatingBugsController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_staminaController.MakeStaminaGoOffFaster();
		_eatingController.EatSomething();
		Destroy(this.gameObject);
	}
}
