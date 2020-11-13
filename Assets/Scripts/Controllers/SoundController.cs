using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSourceBugEat;
	[SerializeField] private AudioSource _audioSourceHitTree;
	[SerializeField] private AudioSource _audioSourceCoin;
	[SerializeField] private AudioSource _audioSourceMusic;
	[SerializeField] private AudioSource _audioSourceButtonClick;
	public Image MusicButton;
	public Image SoundButton;
	public Sprite MusicOnSprite;
	public Sprite SoundOnSprite;
	public Sprite MusicOffSprite;
	public Sprite SoundOffSprite;
	public bool SoundOn;
	public bool MusicOn;
	// player prefs : SoundOff если 1 то true
	//				  MusicOff если 1 то true
	private void Start()
	{
		if(PlayerPrefs.GetInt("SoundOnSprite") == 1)
		{
			SoundOn = false;
			SoundButton.sprite = SoundOffSprite;
		}
		if(PlayerPrefs.GetInt("MusicOff") == 1)
		{
			MusicOn = false;
			MusicButton.sprite = MusicOffSprite;
		}
		PlayMusic();
	}
	public void ChangeSoundBool()
	{
		if (SoundOn)
		{
			SoundOn = false;
			PlayerPrefs.SetInt("SoundOnSprite", 1);
			SoundButton.sprite = SoundOffSprite;
		}
		else
		{
			SoundOn = true;
			PlayerPrefs.SetInt("SoundOnSprite", 0);
			SoundButton.sprite = SoundOnSprite;
			PlayButtonClick();
		}
	}
	public void ChangeMusicBool()
	{
		if (MusicOn)
		{
			MusicOn = false;
			PlayerPrefs.SetInt("MusicOff", 1);
			MusicButton.sprite = MusicOffSprite;
			_audioSourceMusic.Stop();
			PlayButtonClick();
		}
		else
		{
			MusicOn = true;
			PlayerPrefs.SetInt("MusicOff", 0);
			MusicButton.sprite = MusicOnSprite;
			PlayButtonClick();
			PlayMusic();
		}
	}
	public void PlayEatSomethingSound()
	{
		if (_audioSourceBugEat.isPlaying) return;
		if (SoundOn)
		{
			_audioSourceBugEat.PlayOneShot(_audioSourceBugEat.clip);
		}
	}
	public void PlayHitTreeSound()
	{
		if (SoundOn)
		{
			_audioSourceHitTree.PlayOneShot(_audioSourceHitTree.clip);
		}
	}
	public void PlayCoinSound()
	{
		if (SoundOn)
		{
			_audioSourceCoin.PlayOneShot(_audioSourceCoin.clip);
		}
	}
	public void PlayButtonClick()
	{
		if (SoundOn)
		{
			_audioSourceButtonClick.PlayOneShot(_audioSourceButtonClick.clip);
		}
	}
	public void PlayMusic()
	{
		if (MusicOn)
		{
			_audioSourceMusic.Play();
		}
	}
}
