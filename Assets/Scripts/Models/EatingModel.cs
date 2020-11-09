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

	[HideInInspector] public bool СanBiteAtAll = true;
	[HideInInspector] public bool СanBiteAgain = true;
	[HideInInspector] public bool BiteWasMade;
	[HideInInspector] public bool IsBiting;
	[HideInInspector] public int[] BugsOnLvls;

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
			BiteWasMade = true;
			_sideSelector *= -1;
		}
		if (BiteWasMade && ColliderTransform.localPosition.z <= _startZPosition)
		{
			IsBiting = false;
			_biteVector.z = _startZPosition;
			ColliderTransform.localPosition = _biteVector;
			_sideSelector *= -1;
			BiteWasMade = false;
		}
	}
}
