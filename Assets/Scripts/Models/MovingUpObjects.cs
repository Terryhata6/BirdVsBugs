using UnityEngine;

public class MovingUpObjects : MonoBehaviour
{
	public Transform AllMovingUpObjects;
	public Transform AllBugs;
	public Material TreeMaterial;
	public float MovingUpAmount;
	public int MovingUpSpeed;
	private int MainTex = Shader.PropertyToID("_MainTex");

	public void MoveObjectsUp()
	{
		for (int i = 1; i <= MovingUpSpeed; i++)
		{
			Invoke("MoveUpALittle", i * 0.01f);
		}
	}
	private void MoveUpALittle()
	{
		AllMovingUpObjects.position = new Vector3(AllMovingUpObjects.position.x, AllMovingUpObjects.position.y + MovingUpAmount / MovingUpSpeed, AllMovingUpObjects.position.z);
		AllBugs.position = new Vector3(AllBugs.position.x, AllBugs.position.y - MovingUpAmount / MovingUpSpeed, AllBugs.position.z);
		TreeMaterial.SetTextureOffset(MainTex, new Vector2(0, TreeMaterial.GetTextureOffset("_MainTex").y + MovingUpAmount / 10 / MovingUpSpeed));
	}
}
