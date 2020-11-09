using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int ChanceOfCoin;
    public int CoinsCollectedOnThisLvl;

    public Text CoinsText; 
    public Text DarkCoinsText; 

    //player prefs : Coins - сохраненные монеты
    public void AddCoin()
    {
        if(Random.Range(1,101) <= ChanceOfCoin)
        {
            CoinsCollectedOnThisLvl++;
            CoinsText.text = CoinsCollectedOnThisLvl.ToString();
            DarkCoinsText.text = CoinsCollectedOnThisLvl.ToString();
        }
    }
    public int GetAllCollectedCoinsAmount()
    {
        return PlayerPrefs.GetInt("Coins");
    }
    public void AddCoinsCollectedOnLvl()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CoinsCollectedOnThisLvl);
    }
}
