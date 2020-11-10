using UnityEngine;

public class TurningBugTriggerChecker : MonoBehaviour
{
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private RotatingObject _rotatingModel;
	private TurningEffect _turningEffect;
	private void Awake()
	{
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
		_rotatingModel = FindObjectOfType<RotatingObject>();
		_turningEffect = FindObjectOfType<TurningEffect>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_rotatingModel.ChangeSide();
		_particlesController.PlayArmoredBugParticles();
		_turningEffect.MakePopUp();
		_eatingController.EatBug(this.gameObject);
	}
}
