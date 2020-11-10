using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int ChanceOfCoin;
    public int CoinsCollectedOnThisLvl;

    public Text CoinsText; 
    public Text DarkCoinsText;

    private CoinEffect _coinEffect;
    private SoundController _soundController;

    //player prefs : Coins - сохраненные монеты
    private void Awake()
    {
        _coinEffect = FindObjectOfType<CoinEffect>();
        _soundController = FindObjectOfType<SoundController>();
    }
    public void AddCoin()
    {
        if(Random.Range(1,101) <= ChanceOfCoin)
        {
            _soundController.PlayCoinSound();
            _coinEffect.MakePopUp();
            CoinsCollectedOnThisLvl++;
            CoinsText.text = CoinsCollectedOnThisLvl.ToString();
            DarkCoinsText.text = CoinsCollectedOnThisLvl.ToString();
        }
    }
    public void AddCoins(int Amount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Amount);
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
