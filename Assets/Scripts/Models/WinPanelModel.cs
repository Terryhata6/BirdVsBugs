using UnityEngine;
using UnityEngine.UI;

public class WinPanelModel : MonoBehaviour
{
	public SingleBossWindow[] BossWindows;
	public Animator PopUPSquare1;
	public Animator PopUPSquare2;
	public Slider RoadMapSlider;
	public Text CoinsText;
	public float PauseBeforeAddingCoins;
	public float PauseBeforeAddingSingleCoin;
	public int TimesOfAddingInSlider;

	private Coins _coinsModel;
	private string MeetBossPlayerPrefsName = "MeetBoss";
	private string CollectedBossPlayerPrefsName = "CollectedBoss";
	private string CurrentLvlOfSliderPrefsName = "CurrentLvlOfSlider";

	private int[] BossesDefeatedNums;
	private int BossesCollected;
	private int Coins;

	// plyer prefs : 
	//				MeetBossN - сколько раз встречал босса
	//				CollectedBossN - встречал босса в текущем подсчете боссов, если равен 1 то встречал
	//				CurrentLvlOfSlider - каой уровень у слайдера
	//				N - номер босса
	//				BossesBeaten - Побито боссов(для того что бы в начале по порядку боссов пустить)
	//TODO вынести в отдельный контроллер
	public void ActivateWinPanel(int LastBossNum)
	{
		SetAlreadyCollectedCoins();
		Invoke("AddCoinsInUI", PauseBeforeAddingCoins);
		Invoke("CheckForBonusCoins", PauseBeforeAddingCoins);
		CountSliderLvl(LastBossNum);
		CrossBoss(LastBossNum);
		EnableDarkImages();
		CheckIfAllBossesCollected(LastBossNum);
		SetBossDefeatedNum();
		CheckIfNewBossCollected(LastBossNum);

		PlayerPrefs.SetInt("BossesBeaten", PlayerPrefs.GetInt("BossesBeaten") + 1);

		if (BossesCollected == BossWindows.Length)
		{
			ClearCurrentCollectedBosses();
		}
	}
	private void EnableDarkImages()
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			if (PlayerPrefs.GetInt(MeetBossPlayerPrefsName + i.ToString()) > 0)
			{
				BossWindows[i].DarkImage.gameObject.SetActive(false);
				BossWindows[i].BossImage.gameObject.SetActive(true);
			}
			else
			{
				BossWindows[i].DarkImage.gameObject.SetActive(true);
				BossWindows[i].BossImage.gameObject.SetActive(false);
			}
		}
	}
	private void CrossBoss(int BossNum)
	{
		PlayerPrefs.SetInt(MeetBossPlayerPrefsName + BossNum.ToString(), PlayerPrefs.GetInt(MeetBossPlayerPrefsName + BossNum.ToString()) + 1);
		if (PlayerPrefs.GetInt(CollectedBossPlayerPrefsName + BossNum.ToString()) == 0)
		{
			BossWindows[BossNum].CrossOnBoss.SetTrigger("Cross");
			PlayerPrefs.SetInt(CollectedBossPlayerPrefsName + BossNum.ToString(), 1);
		}
		else
		{
			BossWindows[BossNum].CrossOnBoss.SetTrigger("Crossed");
		}

	}
	private void SetBossDefeatedNum()
	{
		BossesDefeatedNums = new int[BossWindows.Length];
		for (int i = 0; i < BossWindows.Length; i++)
		{
			BossesDefeatedNums[i] = PlayerPrefs.GetInt(MeetBossPlayerPrefsName + i.ToString());
			BossWindows[i].BossDefeatedNum.text = ("x" + PlayerPrefs.GetInt(MeetBossPlayerPrefsName + i.ToString().ToString()));
		}
	}
	private void CheckIfNewBossCollected(int BossNum)
	{
		if (PlayerPrefs.GetInt(CollectedBossPlayerPrefsName + BossNum.ToString()) == 0)
		{
			BossesCollected++;
		}
	}
	private void CheckIfAllBossesCollected(int BossNum)
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			if (PlayerPrefs.GetInt(CollectedBossPlayerPrefsName + i.ToString()) == 1)
			{
				if (i != BossNum)
				{
					BossWindows[i].CrossOnBoss.SetTrigger("Crossed");
				}
				BossesCollected++;
			}
		}
	}
	private void ClearCurrentCollectedBosses()
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			PlayerPrefs.SetInt(CollectedBossPlayerPrefsName + i.ToString(), 0);
		}
		PlayerPrefs.SetInt(CurrentLvlOfSliderPrefsName, 0);
	}
	private void SetAlreadyCollectedCoins()
	{
		_coinsModel = FindObjectOfType<Coins>();
		Coins = _coinsModel.GetAllCollectedCoinsAmount();
		CoinsText.text = Coins.ToString();
	}
	private void AddCoinsInUI()
	{
		for (int i = 0; i < _coinsModel.CoinsCollectedOnThisLvl; i++)
		{
			Invoke("AddSingleCoin", PauseBeforeAddingSingleCoin * i);
		}
	}
	private void AddMoreCoinsInUI(int Amount)
	{
		for (int i = 0; i < Amount; i++)
		{
			Invoke("AddSingleCoin", PauseBeforeAddingSingleCoin * i);
		}
	}
	private void AddSingleCoin()
	{
		Coins++;
		CoinsText.text = Coins.ToString();
	}
	private void CountSliderLvl(int BossNum)
	{
		RoadMapSlider.value = PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName);
		if (PlayerPrefs.GetInt(CollectedBossPlayerPrefsName + BossNum.ToString()) == 0)
		{
			AddLvlToSlider();
		}
		else
		{
			if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 3)
			{
				PopUPSquare1.SetTrigger("Visible");
			}
			else if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 4 || PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 5)
			{
				PopUPSquare1.SetTrigger("Visible");
			}
		}
	}

	private void AddLvlToSlider()
	{
		PlayerPrefs.SetInt(CurrentLvlOfSliderPrefsName, PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) + 1);
		for (int i = 1; i <= TimesOfAddingInSlider + 1; i++)
		{
			if (i != TimesOfAddingInSlider + 1)
			{
				Invoke("AddLittlePartToSlider", 0.01f * i);
			}
			else
			{
				if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 3)
				{
					Invoke("FirstPopUp", 1);
					_coinsModel.AddCoins(250);
				}
				else if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 6)
				{
					PopUPSquare1.SetTrigger("Visible");
					Invoke("SecondPopUp", 1);
					_coinsModel.AddCoins(500);
				}
				else if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 4 || PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 5)
				{
					PopUPSquare1.SetTrigger("Visible");
				}
			}
		}
	}
	private void CheckForBonusCoins()
	{
		if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 3)
		{
			AddMoreCoinsInUI(250);
		}
		else if (PlayerPrefs.GetInt(CurrentLvlOfSliderPrefsName) == 0)// 0 потому что обнуляется счетчик
		{
			AddMoreCoinsInUI(500);
		}
	}
	private void AddLittlePartToSlider()
	{
		RoadMapSlider.value = RoadMapSlider.value + 1f / TimesOfAddingInSlider;
	}
	private void FirstPopUp()
	{
		PopUPSquare1.SetTrigger("Pop Up");
	}
	private void SecondPopUp()
	{
		PopUPSquare2.SetTrigger("Pop Up");
	}
}