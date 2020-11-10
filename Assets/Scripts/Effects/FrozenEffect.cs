using UnityEngine;
using UnityEngine.UI;

public class FrozenEffect : MonoBehaviour
{
    public int HowManyTimesAlphaChanges;
    public Image LeftFrozenEffect;
    public Image RightFrozenEffect;
    private Color _colorForFrozenImages;

    public void TurnOnFrozenEffect(float TimeOfFrozen)
    {
        _colorForFrozenImages = LeftFrozenEffect.color;
        for (int i = 1; i <= HowManyTimesAlphaChanges; i++)
        {
            Invoke("MultiplyAlphaALittle", 0.01f * i);
        }
        Invoke("TurnOffFrozenEffect", TimeOfFrozen);
    }
    public void TurnOffFrozenEffect()
    {
        _colorForFrozenImages = LeftFrozenEffect.color;
        for (int i = 1; i <= HowManyTimesAlphaChanges; i++)
        {
            Invoke("ReduceAlphaALittle", 0.01f * i);
        }
    }
    private void MultiplyAlphaALittle()
    {
        _colorForFrozenImages.a = _colorForFrozenImages.a + 1f / HowManyTimesAlphaChanges;
        LeftFrozenEffect.color = _colorForFrozenImages;
        RightFrozenEffect.color = _colorForFrozenImages;
    }
    private void ReduceAlphaALittle()
    {
        _colorForFrozenImages.a -= 1f / HowManyTimesAlphaChanges;
        LeftFrozenEffect.color = _colorForFrozenImages;
        RightFrozenEffect.color = _colorForFrozenImages;
    }
}
