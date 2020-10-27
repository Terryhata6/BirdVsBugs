using UnityEngine;

public class StaminaController : MonoBehaviour
{
    private StaminaSlider _staminaSlider;
    private EnemyEffects _enemyEffects;
    private void Awake()
    {
        _staminaSlider = FindObjectOfType<StaminaSlider>();
        _enemyEffects = FindObjectOfType<EnemyEffects>();
    }
    private void FixedUpdate()
    {
        _staminaSlider.ReduceStaminaByTime();
    }
    public void MakeStaminaGoOffFaster()
    {
        _staminaSlider.StaminaOffMultiplyer = _enemyEffects.MultiplyerOfPoisoned;
        Invoke("MakeStaminaGoOffSlower", _enemyEffects.TimeOfPoisoned);
    }
    private void MakeStaminaGoOffSlower()
    {
        _staminaSlider.StaminaOffMultiplyer = 1;
    }
}
