using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    public Transform PopUpPointTransform;
    public Transform CoinTransform;
    public Animator CoinAnimator;
    public void MakePopUp()
    {
        CoinTransform.position = PopUpPointTransform.position;
        CoinAnimator.SetTrigger("PopUp");
    }
}