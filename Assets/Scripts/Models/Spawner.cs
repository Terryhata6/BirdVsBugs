using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject BugPrefab;
	public BugsPreset[] LvlPresets;
	public float StartYPostion;
	public int AmountOfPresets;
	public bool NeedToSpawnPreset;
	public Vector3[] PositonOfBugs;
	public float[] RotationOfBugs;

	private int[] _bugsOnLvl;
	private int _linesWrited;

	public int[] SpawnBugsFromPreset()
	{
		_bugsOnLvl = new int[0];
		for (int i = 0; i < AmountOfPresets; i++)
		{
			BugsPreset Preset = LvlPresets[Random.Range(0, LvlPresets.Length)];
			int[] Temp = new int[Preset.PartsOfPreset.Length];
			
			for (int j = 0; j < Preset.PartsOfPreset.Length; j++)
			{
				for (int k = 0; k < Preset.PartsOfPreset[j].PositionOfBug.Length; k++)
				{
					Temp[j] = Preset.PartsOfPreset[j].PositionOfBug.Length;
					Vector3 PositionOfBug = PositonOfBugs[Preset.PartsOfPreset[j].PositionOfBug[k]];
					PositionOfBug.y = StartYPostion;
					GameObject Bug = Instantiate(BugPrefab, PositionOfBug, Quaternion.identity);
					Bug.transform.Rotate(new Vector3(0, RotationOfBugs[Preset.PartsOfPreset[j].PositionOfBug[k]], 0));
				}
				StartYPostion += 1.5f;
			}
			int[] BugsWrited = new int[_bugsOnLvl.Length]; 
			for (int j = 0; j < _bugsOnLvl.Length; j++)
			{
				BugsWrited[j] = _bugsOnLvl[j];
			}
			_bugsOnLvl = new int[BugsWrited.Length + Temp.Length];
			for (int j = 0; j < BugsWrited.Length; j++)
			{
				_bugsOnLvl[j] = BugsWrited[j];
			}
			for (int j = 0; j < Temp.Length; j++)
			{
				_bugsOnLvl[_linesWrited] = Temp[j];
				_linesWrited++;
			}
		}
		return _bugsOnLvl;
	}
}
