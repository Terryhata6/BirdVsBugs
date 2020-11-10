using UnityEngine;

public class SoundController : MonoBehaviour
{
	[SerializeField] private AudioSource _audioSourceBugEat;
	[SerializeField] private AudioSource _audioSourceMushroomEat;
	[SerializeField] private AudioSource _audioSourceCoin;
	[SerializeField] private AudioSource _audioSourceMusic;
	[SerializeField] private AudioSource _audioSourceButtonClick;
	public bool SoundOn;
	public bool MusicOn;

	private void Start()
	{
		PlayMusic();
	}
	public void ChangeSoundBool()
	{
		if (SoundOn)
		{
			SoundOn = false;
		}
		else
		{
			SoundOn = true;
			PlayButtonClick();
		}
	}
	public void ChangeMusicBool()
	{
		if (MusicOn)
		{
			MusicOn = false;
			_audioSourceMusic.Stop();
			PlayButtonClick();
		}
		else
		{
			MusicOn = true;
			PlayButtonClick();
			PlayMusic();
		}
	}
	public void PlaySingleExplode()
	{
		if (_audioSourceBugEat.isPlaying) return;
		if (SoundOn)
		{
			_audioSourceBugEat.PlayOneShot(_audioSourceBugEat.clip);
		}
	}
	public void PlayLineExplode()
	{
		if (SoundOn)
		{
			_audioSourceMushroomEat.PlayOneShot(_audioSourceMushroomEat.clip);
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
