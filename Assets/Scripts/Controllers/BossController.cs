using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss BossModel;

    private void Awake()
    {
        BossModel = FindObjectOfType<Boss>();
    }
    private void Start()
    {
        BossModel.SelectBossForThisLvl();
        BossModel.SetTriggerManager();
    }
}
