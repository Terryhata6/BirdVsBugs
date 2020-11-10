using UnityEngine;

public class MovingUpObjects : MonoBehaviour
{
	public Transform AllMovingUpObjects;
	public Transform CharacterTransform;
	public Transform CameraTransform;
	public Material TreeMaterial;
	public float MovingUpAmount;
	public float StartMovingUpAmount;
	public int TimeLenghtOfMovingUp;
	public int TimeLenghtOfStartMovingUp;
	public bool NeedToMoveOnlyCharacter;
	private int MainTex = Shader.PropertyToID("_MainTex");


	public void MoveBirdUpAtStart()
	{
		for (int i = 1; i <= TimeLenghtOfStartMovingUp; i++)
		{
			Invoke("MoveUpALittleAtStart", i * 0.01f);
		}
	}
	private void MoveUpALittleAtStart()
	{
		CharacterTransform.position = new Vector3(CharacterTransform.position.x, CharacterTransform.position.y + StartMovingUpAmount / TimeLenghtOfStartMovingUp, CharacterTransform.position.z);
	}
	public void MoveObjectsUp()
	{
		for (int i = 1; i <= TimeLenghtOfMovingUp; i++)
		{
			Invoke("MoveUpALittle", i * 0.01f);
		}
	}
	private void MoveUpALittle()
	{
		if (NeedToMoveOnlyCharacter)
		{
			CharacterTransform.position = new Vector3(CharacterTransform.position.x, CharacterTransform.position.y + MovingUpAmount / TimeLenghtOfMovingUp, CharacterTransform.position.z);
			CameraTransform.position = new Vector3(CameraTransform.position.x, CameraTransform.position.y + MovingUpAmount / TimeLenghtOfMovingUp, CameraTransform.position.z);
		}
		else
		{
			AllMovingUpObjects.position = new Vector3(AllMovingUpObjects.position.x, AllMovingUpObjects.position.y + MovingUpAmount / TimeLenghtOfMovingUp, AllMovingUpObjects.position.z);
			TreeMaterial.SetTextureOffset(MainTex, new Vector2(0, TreeMaterial.GetTextureOffset("_MainTex").y + MovingUpAmount / 10 / TimeLenghtOfMovingUp));
		}
	}
}
