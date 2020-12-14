using UnityEngine;
using TapticPlugin;

public class InputController : MonoBehaviour
{
    //следит за пальцем на экране
    public Vector3 TouchPosition;
    public bool InputStarted = false;
    private Camera CameraForInput;
    private Touch touch;
    private SampleUI _sampleUI;

    private void Start()
    {
        CameraForInput = FindObjectOfType<Camera>();
        _sampleUI = FindObjectOfType<SampleUI>();
        TouchPosition = new Vector3(0, 0);
    }

    private void Update()
    {
        for (int i = 1; i <= Input.touchCount; i++)
        {
            if (Input.touchCount > 0 && !InputStarted)
            {
                touch = Input.GetTouch(i - 1);
                if (touch.phase == TouchPhase.Began)
                {
                    InputStarted = true;
                    TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
                    _sampleUI.OnImpactClick(2);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    TouchPosition = CameraForInput.ScreenToWorldPoint(touch.position);
                }
            }
            else if(InputStarted)
            {
                InputStarted = false;
            }
        }
    }
}