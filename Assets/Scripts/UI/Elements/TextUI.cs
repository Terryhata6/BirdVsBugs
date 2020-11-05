using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    private Text _text;

    public Text GetControll()
    {
        if (!_text)
        {
            _text = GetComponent<Text>();
        }
        return _text;
    }
}
