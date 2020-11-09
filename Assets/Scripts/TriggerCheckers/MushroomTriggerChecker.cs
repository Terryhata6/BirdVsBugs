using UnityEngine;

public class MushroomTriggerChecker : MonoBehaviour
{
	private StaminaController _staminaController;
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private void Awake()
	{
		_staminaController = FindObjectOfType<StaminaController>();
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_staminaController.MakeStaminaGoOffFaster();
		_eatingController.EatSomething();
		_particlesController.PlayAcidMushroomsParticles();
		Destroy(this.gameObject);
	}
}
