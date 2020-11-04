using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss _bossModel;
    private StaminaSlider _staminaSlider;
    private RotatingObject _rotatingObject;

    private void Awake()
    {
        _bossModel = FindObjectOfType<Boss>();
        _staminaSlider = FindObjectOfType<StaminaSlider>();
        _rotatingObject = FindObjectOfType<RotatingObject>();
    }
    private void Start()
    {
        _bossModel.SelectBossForThisLvl();
        _bossModel.SetTriggerManager();
    }
    private void FixedUpdate()
    {
        if (_bossModel.NeedToStartBossBattle && !_bossModel.IsBossFightNow)
        {
            StartBossBattle();
        }
    }
    public void StartBossBattle()
    {
        _bossModel.IsBossFightNow = true;
        _staminaSlider.StaminaOffMultiplyer = _bossModel.StaminaMyltiplyerForBossBattle;
        _rotatingObject.ObjectRotationSpeed *= _bossModel.RotationSpeedMyltiplyerForBossBattle;
    }
}
