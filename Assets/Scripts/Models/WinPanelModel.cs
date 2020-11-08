using UnityEngine;

public class WinPanelModel : MonoBehaviour
{
	public SingleBossWindow[] BossWindows;
	private int[] BossesDefeatedNums;
	private bool[] IsBossActive;
	public void ActivateWinPanel(int LastBossNum)
	{
		EnableDarkImages();
		CrossBoss(LastBossNum);
		SetBossDefeatedNum();
	}
	private void EnableDarkImages()
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			if (PlayerPrefs.GetInt("HasBeenMeetBoss" + i.ToString()) > 0)
			{
				IsBossActive[i] = true;
			}
			BossWindows[i].DarkImage.gameObject.SetActive(IsBossActive[i]);
		}
	}
	private void CrossBoss(int BossNum)
	{
		PlayerPrefs.SetInt("HasBeenMeetBoss" + BossNum.ToString(), PlayerPrefs.GetInt("HasBeenMeetBoss" + BossNum.ToString()) + 1);
		Animator CrossAnimator = BossWindows[BossNum].CrossOnBoss.GetComponent<Animator>();
	}
	private void SetBossDefeatedNum()
	{
		for (int i = 0; i < BossWindows.Length; i++)
		{
			BossesDefeatedNums[i] = PlayerPrefs.GetInt("HasBeenMeetBoss" + i.ToString());
			BossWindows[i].BossDefeatedNum.text = ("x" + PlayerPrefs.GetInt("HasBeenMeetBoss" + i.ToString().ToString()));
		}
	}

}
