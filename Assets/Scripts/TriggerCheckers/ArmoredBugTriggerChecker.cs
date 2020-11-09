using UnityEngine;

public class ArmoredBugTriggerChecker : MonoBehaviour
{
	public GameObject Shield;
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	[SerializeField] private bool _hasShield = true;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
	}
	private void OnTriggerEnter(Collider other)
	{
		if (_hasShield)
		{
			_hasShield = false;
			Shield.SetActive(false);
			_eatingController.EatSomething();
			_particlesController.PlayArmoredBugParticles();
		}
		else
		{
			_particlesController.PlayArmoredBugParticles();
			_eatingController.EatBug(this.gameObject);
		}
	}
}
