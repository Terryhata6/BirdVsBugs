using UnityEngine;

public class BossController : MonoBehaviour
{
    private Boss _bossModel;
    private StaminaSlider _staminaSlider;
    private RotatingObject _rotatingObject;

    //Player Prefs : BossesBeaten - Побито боссов(для того что бы в начале по порядку боссов пустить)
    private void Awake()
    {
        _bossModel = FindObjectOfType<Boss>();
        _staminaSlider = FindObjectOfType<StaminaSlider>();
        _rotatingObject = FindObjectOfType<RotatingObject>();
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt("BossesBeaten") < 6)
        {
            _bossModel.SelectNotRandomBossForThisLvl(PlayerPrefs.GetInt("BossesBeaten"));
        }
        else
        {
            _bossModel.SelectRandomBossForThisLvl();
        }
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
