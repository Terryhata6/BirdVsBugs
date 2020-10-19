using UnityEngine;

public class Bite : MonoBehaviour
{
	public float DistanceOfBiting;
	public float SpeedOfBiting;
	public Transform StartOfRaycast;
	public Transform EndOfRaycast;
	public LayerMask BugsLayer;

	private MainGameController _gameController;
	private Transform _transform;
	private InputController _inputController;
	private RotateAroundCylindr _rotateScript;
	private Vector3 _biteVector;
	private float _startZPosition;
	private float _sideSelector = 1;
	private bool _biteWasMade;
	private bool _raycastHit;
	[SerializeField] private bool _canBiteAgain = true;
	[SerializeField] private bool _isBiting;

	private void Start()
	{
		_gameController = FindObjectOfType<MainGameController>();
		_transform = GetComponent<Transform>();
		_startZPosition = transform.localPosition.z;
		_inputController = FindObjectOfType<InputController>();
		_biteVector = new Vector3();
		_rotateScript = FindObjectOfType<RotateAroundCylindr>();
	}
	private void FixedUpdate()
	{
		if (_inputController.DragingStarted && !_isBiting && _canBiteAgain)
		{
			_gameController.EatNothing();
			_rotateScript.CanRotate = false;
			_isBiting = true;
			_canBiteAgain = false;
		}
		if (!_inputController.DragingStarted && !_canBiteAgain)
		{
			_canBiteAgain = true;
		}
		if (_isBiting)
		{
			MakeBite();
		}
		Debug.DrawLine(StartOfRaycast.position, EndOfRaycast.position, Color.red, 0f);
	}

	private void MakeBite()
	{
		_biteVector = _transform.localPosition;
		_biteVector.z += SpeedOfBiting * _sideSelector;
		_transform.localPosition = _biteVector;
		if (_transform.localPosition.z >= _startZPosition + DistanceOfBiting)
		{
			_biteWasMade = true;
			_sideSelector *= -1;
		}
		if (_biteWasMade && _transform.localPosition.z <= _startZPosition)
		{
			_biteVector.z = _startZPosition;
			_transform.localPosition = _biteVector;
			_sideSelector *= -1;
			_isBiting = false;
			_rotateScript.CanRotate = true;
			_biteWasMade = false;
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
		_gameController.EatBug();
	}
}
