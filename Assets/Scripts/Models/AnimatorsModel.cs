using UnityEngine;

public class AnimatorsModel : MonoBehaviour
{
	public Animator BirdAnimator;

	public void MakeBiteAnimation() 
	{
		BirdAnimator.SetTrigger("Bite");
	}
}
