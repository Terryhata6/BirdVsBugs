﻿using UnityEngine;

public class MovingUpObjects : MonoBehaviour
{
	public Transform AllMovingUpObjects;
	public Transform AllBugs;
	public Transform CharacterTransform;
	public Transform CameraTransform;
	public Material TreeMaterial;
	public float MovingUpAmount;
	public int TimeLenghtOfMovingUp;
	public bool NeedToMoveOnlyCharacter;
	private int MainTex = Shader.PropertyToID("_MainTex");

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
			AllBugs.position = new Vector3(AllBugs.position.x, AllBugs.position.y - MovingUpAmount / TimeLenghtOfMovingUp, AllBugs.position.z);
			TreeMaterial.SetTextureOffset(MainTex, new Vector2(0, TreeMaterial.GetTextureOffset("_MainTex").y + MovingUpAmount / 10 / TimeLenghtOfMovingUp));
		}
	}
}
