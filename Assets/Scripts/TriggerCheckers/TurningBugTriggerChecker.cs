using UnityEngine;

public class TurningBugTriggerChecker : MonoBehaviour
{
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private RotatingObject _rotatingModel;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
		_rotatingModel = FindObjectOfType<RotatingObject>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_rotatingModel.ChangeSide();
		_particlesController.PlayArmoredBugParticles();
		_eatingController.EatBug(this.gameObject);
	}
}
