using UnityEngine;

public class SimpleBugTriggerChecker : MonoBehaviour
{
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_particlesController.PlaySimpleBugParticles(transform.position);
		_eatingController.EatBug(this.gameObject);
	}
}
