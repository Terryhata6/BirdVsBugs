using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaminaSlider : MonoBehaviour
{

    public Slider PowerSlider;
    public float BirdPower = 50;
    public float StaminaOffPower = 3;
    public float StaminaOffMultiplyer = 1;

    public void ReduceStaminaByTime()
    {
        BirdPower -= Time.deltaTime * (StaminaOffPower * StaminaOffMultiplyer);
        PowerSlider.value = BirdPower / 50;
        if (BirdPower <= 0)
        {
            RestartLvl();
        }
    }
    private void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReduceStaminaByNum(float num)
    {
        BirdPower -= num;
    }
    public void IncreaseStaminaByNum(float num)
    {
        BirdPower += num;
        if (BirdPower > 50)
        {
            BirdPower = 50;
        }
    }
}
