using UnityEngine;

public class TurningEffect : MonoBehaviour
{
	public Animator TurningAnimator;
	public Transform EffectPoint;
	public Transform EffectTransform;
	public void MakePopUp()
	{
		TurningAnimator.SetTrigger("PopUp");
	}
	private void FixedUpdate()
	{
		EffectTransform.position = EffectPoint.position;
	}
}