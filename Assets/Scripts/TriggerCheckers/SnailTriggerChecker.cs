using UnityEngine;

public class SnailTriggerChecker : MonoBehaviour
{
	private RotationController _rotationController;
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private void Awake()
	{
		_rotationController = FindObjectOfType<RotationController>();
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_rotationController.MakeRotationGoSlower();
		_eatingController.EatSomething();
		_particlesController.PlayFrozenMushroomsParticles(transform.position);
		Destroy(this.gameObject);
	}
}
