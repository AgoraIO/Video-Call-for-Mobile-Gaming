using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using System.IO;


// this is an example of using Agora unity sdk
// It demonstrates:
// How to enable video
// How to join/leave channel
//
public class exampleApp : MonoBehaviour
{

    public static void logD(string message)
    {
        Debug.Log("zhangtest" + message);
    }

    // load agora engine
    public void loadEngine()
    {
        // start sdk
        logD("initializeEngine");

        if (mRtcEngine != null)
        {
            logD("Engine exists. Please unload it first!");
            return;
        }

        // init engine
        mRtcEngine = IRtcEngine.getEngine(mVendorKey);

        // enable log
        string filePath = Application.persistentDataPath;
        string fileName = "agoraSdkLog.txt";
        string file = Application.persistentDataPath + "/" + fileName;
        Createfile(filePath, fileName);
        mRtcEngine.SetLogFile(file);
        logD("sdklog  filePath =  " + file);
        //Android :  /storage/emulated/0/Android/data/com.Agora.VideoTexture/files
    }

    public void join(string channel)
    {
        logD("calling join (channel = " + channel + ")");

        if (mRtcEngine == null)
            return;
        // set callbacks (optional)
        mRtcEngine.OnJoinChannelSuccess = onJoinChannelSuccess;
        mRtcEngine.OnUserJoined = onUserJoined;
        mRtcEngine.OnUserOffline = onUserOffline;
        mRtcEngine.OnVolumeIndication = OnAudioVolumeIndication;
        // allow camera output callback
        mRtcEngine.SetLogFilter(LOG_FILTER.DEBUG);

        // join channel
        mRtcEngine.JoinChannel(channel, null, 0);
        logD("initializeEngine done");
    }

    public void leave()
    {
        Debug.Log("calling leave");

        if (mRtcEngine == null)
            return;

        // leave channel
        mRtcEngine.LeaveChannel();
        // deregister video frame observers in native-c code
        //mRtcEngine.DisableVideoObserver();
    }

    // unload agora engine
    public void unloadEngine()
    {
        logD("calling unloadEngine");

        // delete
        if (mRtcEngine != null)
        {
            IRtcEngine.Destroy();
            mRtcEngine = null;
        }
    }

    // accessing GameObject in Scnene1
    // set video transform delegate for statically created GameObject
    public void onScene1Loaded()
    {
        GameObject go = GameObject.Find("Cylinder");
        if (ReferenceEquals(go, null))
        {
            logD("BBBB: failed to find Cylinder");
            return;
        }
        // VideoSurface o = go.GetComponent<VideoSurface> ();
        // o.mAdjustTransfrom += onTransformDelegate;
    }

    // instance of agora engine
    public IRtcEngine mRtcEngine;
    private string mVendorKey = #YOUR_APPID#;

    // implement engine callbacks

    public uint mRemotePeer = 0; // insignificant. only record one peer


    private void onWarning(int warningCode, string message)
    {

        Debug.Log("onWarning  code = " + warningCode + "  message = " + message);

    }

    private void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume)
    {
        Debug.Log("OnAudioVolumeIndication   speakersNumber  =  " + speakerNumber + "  totalVolume  =  " + totalVolume);
    }

    private void onJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        logD("JoinChannelSuccessHandler: uid = " + uid);
    }

    // When a remote user joined, this delegate will be called. Typically
    // create a GameObject to render video on it
    private void onUserJoined(uint uid, int elapsed)
    {
        logD("onUserJoined: uid = " + uid);
        // this is called in main thread
        mRemotePeer = uid;
    }

    // When remote user is offline, this delegate will be called. Typically
    // delete the GameObject for this user
    private void onUserOffline(uint uid, USER_OFFLINE_REASON reason)
    {
        // remove video stream
        logD("onUserOffline: uid = " + uid);
        // this is called in main thread
    }

    // delegate: adjust transfrom for game object 'objName' connected with user 'uid'
    // you could save information for 'uid' (e.g. which GameObject is attached)
    private void onTransformDelegate(uint uid, string objName, ref Transform transform)
    {
        if (uid == 0)
        {
            transform.position = new Vector3(0f, 2f, 0f);
            transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
            transform.Rotate(0f, 1f, 0f);
        }
        else
        {
            transform.Rotate(0.0f, 1.0f, 0.0f);
        }
    }

    void Createfile (string path, string name)
    {
        FileInfo t = new FileInfo (path + "//" + name);
        if (!t.Exists) {//判断文件是否存在
            t.CreateText ();//不存在，创建
        } else {
            t.AppendText ();//存在，则打开
        }
}
}
