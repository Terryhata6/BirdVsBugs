using UnityEngine;

public class EatingModel : MonoBehaviour
{

	public float DistanceOfBiting;
	public float SpeedOfBiting;
	public float EnergyBySingleBug;

	public Transform ColliderTransform;
	private Vector3 _biteVector;
	private float _startZPosition;
	[SerializeField] private float _sideSelector = -1;
	private bool _biteWasMade;

	[HideInInspector] public bool СanBiteAgain = true;
	public bool IsBiting;
    public int[] BugsOnLvls;

	private void Start()
	{
		_startZPosition = ColliderTransform.localPosition.z;
	}

	public void MakeBite()
	{
		_biteVector = ColliderTransform.localPosition;
		_biteVector.z += SpeedOfBiting * _sideSelector;
		ColliderTransform.localPosition = _biteVector;
		if (ColliderTransform.localPosition.z >= _startZPosition + DistanceOfBiting)
		{
			_biteWasMade = true;
			_sideSelector *= -1;
		}
		if (_biteWasMade && ColliderTransform.localPosition.z <= _startZPosition)
		{
			IsBiting = false;
			_biteVector.z = _startZPosition;
			ColliderTransform.localPosition = _biteVector;
			_sideSelector *= -1;
			_biteWasMade = false;
		}
	}
}
