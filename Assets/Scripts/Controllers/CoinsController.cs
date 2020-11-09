using UnityEngine;

public class CoinsController : MonoBehaviour
{
	private Coins _coinsModel;
	private InGameUI _inGameUi;

	private void Awake()
	{
		_coinsModel = FindObjectOfType<Coins>();
		_inGameUi = FindObjectOfType<InGameUI>();
		_coinsModel.CoinsText = _inGameUi.GetCoinsText();
		_coinsModel.DarkCoinsText = _inGameUi.GetDarkCoinsText();
	}
}
