using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private Spawner _spawner;
    private EatingModel _bugsOnLines;
    private void Awake()
    {
        _spawner = FindObjectOfType<Spawner>();
        _bugsOnLines = FindObjectOfType<EatingModel>();
        _bugsOnLines.BugsOnLvls = _spawner.SpawnBugsFromPreset();
    }
}
