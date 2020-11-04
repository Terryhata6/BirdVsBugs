using UnityEngine;

public class Coins : MonoBehaviour
{
    public int ChanceOfCoin;
    public int CoinsCollectedOnThisLvl;

    public void AddCoin()
    {
        if(Random.Range(1,101) <= ChanceOfCoin)
        {
            Debug.Log("GotCoin");
            CoinsCollectedOnThisLvl++;
        }
    }
}
