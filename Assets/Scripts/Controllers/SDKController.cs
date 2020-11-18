using UnityEngine;
using GameAnalyticsSDK;
using Facebook.Unity;

public class SDKController : MonoBehaviour
{
    void Awake()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            //Handle FB.Init
            FB.Init(() => {
                FB.ActivateApp();
            });
        }
    }

    private void Start()
    {
        GameAnalytics.Initialize();
    }
}
