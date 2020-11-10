using UnityEngine;

public class FrozenMushroomTriggerChecker : MonoBehaviour
{
	private RotationController _rotationController;
	private EatingBugsController _eatingController;
	private ParticlesController _particlesController;
	private EnemyEffects _enemyEffects;
	private FrozenEffect _frozenEffect;
	private void Awake()
	{
		_rotationController = FindObjectOfType<RotationController>();
		_eatingController = FindObjectOfType<EatingBugsController>();
		_particlesController = FindObjectOfType<ParticlesController>();
		_frozenEffect = FindObjectOfType<FrozenEffect>();
		_enemyEffects = FindObjectOfType<EnemyEffects>();
	}
	private void OnTriggerEnter(Collider other)
	{
		_frozenEffect.TurnOnFrozenEffect(_enemyEffects.TimeOfFrozen);
		_rotationController.MakeRotationGoSlower();
		_eatingController.EatSomething();
		_particlesController.PlayFrozenMushroomsParticles();
		Destroy(this.gameObject);
	}
}
