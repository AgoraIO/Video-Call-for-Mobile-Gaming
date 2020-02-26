using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using agora_gaming_rtc;


public class ScreenShareAppController : TestHelloUnityVideo
{
    protected override void onJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        base.onJoinChannelSuccess(channelName, uid, elapsed);
    }

    protected override void onUserJoined(uint uid, int elapsed)
    {
        //base.onUserJoined(uid, elapsed);
    }

    protected override void onUserOffline(uint uid, USER_OFFLINE_REASON reason)
    {
        //base.onUserOffline(uid, reason);
    }

    public override void onSceneHelloVideoLoaded()
    {
        GameObject sphere = GameObject.Find("Sphere");
        if (sphere != null)
        {
            sphere.AddComponent<ScreenShareCtrl>();
        }
    }
}
