using UnityEngine;

public class WinPanelModel : MonoBehaviour
{
	public SingleBossWindow[] BossWindows;
	private int[] BossesDefeatedNums;
	[SerializeField] private int BossesCollected;

	// plyer prefs : 
	//				MeetBossN - сколько раз встречал босса
	//				CollectedBossN - встречал босса в текущем подсчете боссов, если равен 1 то встречал
	//				N - номер босса
	public void ActivateWinPanel(int LastBossNum)
	{
		CrossBoss(LastBossNum);
		EnableDarkImages();
		CheckIfAllBossesCollected(LastBossNum);
		SetBossDefeatedNum();
		CheckIfNewBossCollected(LastBossNum);
		if (BossesCollected == BossWindows.Length)
		{
			ClearCurrentCollectedBosses();
		}
	}
	private void EnableDarkImages()
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			if (PlayerPrefs.GetInt("MeetBoss" + i.ToString()) > 0)
			{
				BossWindows[i].DarkImage.gameObject.SetActive(false);
			}
			else
			{
				BossWindows[i].DarkImage.gameObject.SetActive(true);
			}
		}
	}
	private void CrossBoss(int BossNum)
	{
		PlayerPrefs.SetInt("MeetBoss" + BossNum.ToString(), PlayerPrefs.GetInt("MeetBoss" + BossNum.ToString()) + 1);
		BossWindows[BossNum].CrossOnBoss.SetTrigger("Cross");
		if (PlayerPrefs.GetInt("CollectedBoss" + BossNum.ToString()) == 0)
		{
			PlayerPrefs.SetInt("CollectedBoss" + BossNum.ToString(), 1);
		}

	}
	private void SetBossDefeatedNum()
	{
		BossesDefeatedNums = new int[BossWindows.Length];
		for (int i = 0; i < BossWindows.Length; i++)
		{
			BossesDefeatedNums[i] = PlayerPrefs.GetInt("MeetBoss" + i.ToString());
			BossWindows[i].BossDefeatedNum.text = ("x" + PlayerPrefs.GetInt("MeetBoss" + i.ToString().ToString()));
		}
	}
	private void CheckIfNewBossCollected(int BossNum)
	{
		if (PlayerPrefs.GetInt("CollectedBoss" + BossNum.ToString()) == 0)
		{
			BossesCollected++;
		}
	}
	private void CheckIfAllBossesCollected(int BossNum)
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			if (PlayerPrefs.GetInt("CollectedBoss" + i.ToString()) == 1)
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
			PlayerPrefs.SetInt("CollectedBoss" + i.ToString(), 0);
		}
	}
}