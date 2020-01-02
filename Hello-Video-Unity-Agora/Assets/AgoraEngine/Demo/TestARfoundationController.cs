using UnityEngine;
using agora_gaming_rtc;

public class TestARfoundationController : TestHelloUnityVideo
{
    public override void join(string channel)
    {
        base.join(channel);
        mRtcEngine.EnableLocalVideo(false);
    }


    // When a remote user joined, this delegate will be called. Typically
    // create a GameObject to render video on it
    protected override void onUserJoined(uint uid, int elapsed)
    {
        Debug.Log("onUserJoined: uid = " + uid);
        // this is called in main thread

        // find a game object to render video stream from 'uid'
        GameObject go = GameObject.Find(uid.ToString());
        if (!ReferenceEquals(go, null))
        {
            return; // reuse
        }

        // create a GameObject and assigne to this new user
        go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        if (!ReferenceEquals(go, null))
        {
            go.name = uid.ToString();

            // configure videoSurface
            VideoSurface o = go.AddComponent<VideoSurface>();
            o.SetForUser(uid);
            o.SetEnable(true);
            o.transform.Rotate(-90.0f, 0.0f, 0.0f);
            o.transform.position = getNextCubePosition();
            o.transform.localScale = Vector3.one;
        }

    }

    private static int totalUsers = 0;

    // Generate a new position to place the new cube in.  
    Vector3 getNextCubePosition()
    {
        totalUsers += 1;
        GameObject go = GameObject.Find("Sphere");
        float x = 0;
        if (go != null)
        {
            x = go.transform.position.x + totalUsers * 1.5f;
        }
        else
        {
            x = Random.Range(-2.0f, 2.0f);
        }

        return new Vector3(x, 0, 8.17f);
    }
}
