using UnityEngine;
using GameAnalyticsSDK;

public class SDKController : MonoBehaviour
{
    private void Start()
    {
        GameAnalytics.Initialize();
    }
}
