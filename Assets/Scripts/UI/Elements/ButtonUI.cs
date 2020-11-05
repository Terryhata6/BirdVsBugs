using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    private Button _button;
    public Button GetControll()
    {
        if (!_button)
        {
            _button = GetComponent<Button>();
        }
        return _button;
    }
}
