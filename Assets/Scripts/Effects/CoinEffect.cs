using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public Transform PopUpPointTransform;
    public Transform CoinTransform;
    public Animator CoinAnimator;

    private Boss _bossModel;
    private GameObject _tempCoin;
    public Animator _coinTempAnimator;
    private void Awake()
    {
        _bossModel = FindObjectOfType<Boss>();
    }
    public void MakePopUp()
    {
        if (_bossModel.IsBossFightNow)
        {
            _tempCoin = Instantiate(CoinTransform.gameObject, PopUpPointTransform.position, Quaternion.identity);
            _coinTempAnimator = _tempCoin.GetComponentInChildren<Animator>();
            _coinTempAnimator.SetTrigger("PopUp");
        }
        else
        {
            CoinTransform.position = PopUpPointTransform.position;
            CoinAnimator.SetTrigger("PopUp");
        }
    }
}