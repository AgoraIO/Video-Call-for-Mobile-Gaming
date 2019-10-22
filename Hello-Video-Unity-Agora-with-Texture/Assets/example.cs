using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using System.Runtime.InteropServices;
using System.Threading;

// this is an example of using Agora unity sdk
// It demonstrates:
// How to enable video
// How to join/leave channel
//
public class exampleApp : MonoBehaviour
{

    public static void logD(string message)
    {
        Debug.Log("AgoraTest  " + message);
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
        mRtcEngine.SetParameters("{\"rtc.log_filter\": 65535}");
        mRtcEngine.EnableSoundPositionIndication(true);
        // enable log
        mRtcEngine.SetLogFilter(LOG_FILTER.DEBUG | LOG_FILTER.INFO | LOG_FILTER.WARNING | LOG_FILTER.ERROR | LOG_FILTER.CRITICAL);
    }

    public void join(string channel)
    {
        logD("calling join (channel = " + channel + ")");

        if (mRtcEngine == null)
            return;

        // audioRawDataManager = AudioRawDataManager.GetInstance(mRtcEngine);
        // audioRawDataManager.SetOnMixedAudioFrameCallback(OnMixedAudioFrameHandler);
        // audioRawDataManager.SetOnPlaybackAudioFrameBeforeMixingCallback(OnPlaybackAudioFrameBeforeMixingHandler);
        // audioRawDataManager.SetOnPlaybackAudioFrameCallback(OnPlaybackAudioFrameHandler);
        // audioRawDataManager.SetOnRecordAudioFrameCallback(OnRecordAudioFrameHandler);
        // audioRawDataManager.RegisteAudioRawDataObserver();
        // set callbacks (optional)
        mRtcEngine.OnJoinChannelSuccess = onJoinChannelSuccess;
        mRtcEngine.OnUserJoined = onUserJoined;
        mRtcEngine.OnUserOffline = onUserOffline;
        mRtcEngine.OnVolumeIndication = OnAudioVolumeIndication;
        mRtcEngine.OnAudioQuality = OnAudioQuality;
        mRtcEngine.OnStreamInjectedStatus = OnStreamInjectedStatus;
        mRtcEngine.OnStreamUnpublished = OnStreamUnpublished;
        mRtcEngine.OnStreamMessageError = OnStreamMessageError;
        mRtcEngine.OnStreamMessage = OnStreamMessage;
        mRtcEngine.OnConnectionBanned = OnConnectionBanned;
        mRtcEngine.OnRtcStats =  RtcStatsHandler;
        mRtcEngine.OnNetworkQuality = OnNetworkQualityHandler;

        mRtcEngine.SetExternalAudioSink(false, 16000, 1);
        mRtcEngine.SetExternalAudioSource(false, 16000, 1);
        // enable video
        mRtcEngine.EnableVideo();
        mRtcEngine.EnableVideoObserver();

        // allow camera output callback
        mRtcEngine.SetLogFilter(LOG_FILTER.DEBUG);

        // join channel
        //mRtcEngine.EnableVideo();
        mRtcEngine.JoinChannel(channel, null, 0);

        logD("initializeEngine done");
    }

    public void OnRecordAudioFrameHandler(AudioFrame audioFrame)
	{
		//Debug.Log("AgoraTest  OnRecordAudioFrameHandler  ThreadId = " + Thread.CurrentThread.ManagedThreadId.ToString() + " ,bytesPerSample = " + audioFrame.bytesPerSample + ",channels = " + audioFrame.channels + ",renderTimeMs = " + audioFrame.renderTimeMs + ",samples = " + audioFrame.samples + ",samplesPerSec = " + audioFrame.samplesPerSec + ",type = " + audioFrame.type + ",avsync_type = " + audioFrame.avsync_type);
	}

    public void OnPlaybackAudioFrameHandler(AudioFrame audioFrame)
	{
		//Debug.Log("AgoraTest  OnPlaybackAudioFrameHandler ThreadId = " + Thread.CurrentThread.ManagedThreadId.ToString() + " ,bytesPerSample = " + audioFrame.bytesPerSample + ",channels = " + audioFrame.channels + ",renderTimeMs = " + audioFrame.renderTimeMs + ",samples = " + audioFrame.samples + ",samplesPerSec = " + audioFrame.samplesPerSec + ",type = " + audioFrame.type + ",avsync_type = " + audioFrame.avsync_type);
	}

    public void OnMixedAudioFrameHandler(AudioFrame audioFrame)
	{
		//Debug.Log("AgoraTest  OnMixedAudioFrameHandler  ThreadId = " + Thread.CurrentThread.ManagedThreadId.ToString() +  " ,bytesPerSample = " + audioFrame.bytesPerSample + ",channels = " + audioFrame.channels + ",renderTimeMs = " + audioFrame.renderTimeMs + ",samples = " + audioFrame.samples + ",samplesPerSec = " + audioFrame.samplesPerSec + ",type = " + audioFrame.type + ",avsync_type = " + audioFrame.avsync_type);
	}


    public void OnPlaybackAudioFrameBeforeMixingHandler(uint uid, AudioFrame audioFrame)
	{
		//Debug.Log("AgoraTest  OnPlaybackAudioFrameBeforeMixingHandler  ThreadId = " + Thread.CurrentThread.ManagedThreadId.ToString() + " ,bytesPerSample = " + audioFrame.bytesPerSample + ",channels = " + audioFrame.channels + ",renderTimeMs = " + audioFrame.renderTimeMs + ",samples = " + audioFrame.samples + ",samplesPerSec = " + audioFrame.samplesPerSec + ",type = " + audioFrame.type + ",avsync_type = " + audioFrame.avsync_type);
	}

    public void RtcStatsHandler(RtcStats stats)
    {
        // logD("OnRtcStats " + " ,duration = " + stats.duration + " ,txBytes = " + stats.txBytes + " ,rxBytes = " + stats.rxBytes 
        // + " ,txKBitRate = " + stats.txKBitRate + " ,rxKBitRate = " + stats.rxKBitRate + " ,txAudioKBitRate = " + stats.txAudioKBitRate + " ,rxAudioKBitRate = " + stats.rxAudioKBitRate
        // + " ,txVideoKBitRate = " + stats.txVideoKBitRate + " ,rxVideoKBitRate = " + stats.rxVideoKBitRate +
        // " ,lastmileQuality = " + stats.lastmileQuality + " ,users = " + stats.users + " ,cpuAppUsage = " + stats.cpuAppUsage + " ,cpuTotalUsage = " + stats.cpuTotalUsage
        // + " ,txPacketLossRate = " + stats.txPacketLossRate + " ,rxPacketLossRate = " + stats.rxPacketLossRate);
    }

    public void OnNetworkQualityHandler(uint uid, int txQuality, int rxQuality)
    {
        //logD("OnNetworkQuality  " + "  ,uid = " + uid + "  ,txQuality = " + txQuality + " ,rxQuality = " + rxQuality);
    }

    public void OnStreamInjectedStatus(string url, uint userId, int status)
    {
        logD("OnStreamInjectedStatus  url = " + url + "  userId = " + userId);
    }

    public void OnStreamUnpublished(string url) 
    {
        logD("OnStreamUnpublished  url = " + url);
    }

    public void OnConnectionBanned()
    {
        logD("OnConnectionBanned  ");
    }

    public void OnStreamPublished (string url, int error)
    {
        logD("OnStreamPublished url = " + url + "  error = " + error);
    }

    public void OnStreamMessageError(uint userId, int streamId, int code, int missed, int cached)
    {
        logD("OnStreamMessageError  userId = " + userId + "  streamId = " + streamId);
    }

    public void OnStreamMessage (uint userId, int streamId, string data, int length)
    {
        logD("OnStreamMessage  userId = " + userId + "  streamId = " + streamId + "  data = " + data);
    }

    public void OnAudioQuality(uint userId, int quality, ushort delay, ushort lost){
       // logD("OnAudioQuality  userId = " + userId + "  quality = " + quality + "  delay = " + delay);
    }

    public void leave()
    {
        Debug.Log("calling leave");

        if (mRtcEngine == null)
            return;

        mRtcEngine.LeaveChannel();
       // audioRawDataManager.UnRegisteAudioRawDataObserver();
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
    private string mVendorKey = "f73615b1269e45ecbc7f2337f089471a";

    // implement engine callbacks

    public uint mRemotePeer = 0; // insignificant. only record one peer

    //private AudioRawDataManager audioRawDataManager = null;


    private void onWarning(int warningCode, string message)
    {

        Debug.Log("onWarning  code = " + warningCode + "  message = " + message);

    }

    private void OnAudioVolumeIndication(AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume)
    {
        Debug.Log("OnAudioVolumeIndication   speakersNumber  =  " + speakerNumber + "  totalVolume  =  " + totalVolume);
    }
        
    public Texture2D mTexture;
    public Rect mRect;
	void cutScreen()
	{
		//yield return new WaitForEndOfFrame();
        //videoBytes = Marshal.AllocHGlobal(Screen.width * Screen.height * 4);
        mTexture.ReadPixels(mRect, 0, 0);
		mTexture.Apply();  
		byte[] bytes = mTexture.GetRawTextureData();
		int size = Marshal.SizeOf(bytes[0]) * bytes.Length;	
        IRtcEngine rtc = IRtcEngine.QueryEngine();

        if (rtc != null)
        {
            ExternalVideoFrame externalVideoFrame = new ExternalVideoFrame();
            externalVideoFrame.type = ExternalVideoFrame.VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
            externalVideoFrame.format = ExternalVideoFrame.VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_BGRA;
            externalVideoFrame.buffer = bytes;
            externalVideoFrame.stride = (int)mRect.width;
            externalVideoFrame.height = (int)mRect.height;
            externalVideoFrame.cropLeft = 10;
            externalVideoFrame.cropTop = 10;
            externalVideoFrame.cropRight = 10;
            externalVideoFrame.cropBottom = 10;
            externalVideoFrame.rotation = 10;
            externalVideoFrame.timestamp =100;
            int a = rtc.PushExternVideoFrame(externalVideoFrame);
            Debug.Log(" pushVideoFrame =       "  + a);
        }
        }  
    private void onJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        // mRect = new Rect(0, 0, Screen.width, Screen.height);
        // mTexture = new Texture2D((int)mRect.width, (int)mRect.height,TextureFormat.RGBA32 ,false);  
        // cutScreen();
        ExternalVideoFrame externalVideoFrame = new ExternalVideoFrame();
        mRtcEngine.PushExternVideoFrame(externalVideoFrame);
        logD("JoinChannelSuccessHandler: uid = " + uid);
        AudioFrame audioFrame = new AudioFrame();
        mRtcEngine.PushAudioFrame(audioFrame);
    }

    // When a remote user joined, this delegate will be called. Typically
    // create a GameObject to render video on it
    private void onUserJoined(uint uid, int elapsed)
    {
        logD("onUserJoined: uid = " + uid);
        // this is called in main thread

        // find a game object to render video stream from 'uid'
        GameObject go = GameObject.Find(uid.ToString());
        if (!ReferenceEquals(go, null))
        {
            return; // reuse
        }


        go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        if (!ReferenceEquals(go, null))
        {
            go.name = uid.ToString();

            VideoSurface o = go.AddComponent<VideoSurface>();
            o.SetForUser(uid);
            o.mAdjustTransfrom += onTransformDelegate;
            o.SetEnable(true);
            o.transform.Rotate(-90.0f, 0.0f, 0.0f);
            float r = Random.Range(-5.0f, 5.0f);
            o.transform.position = new Vector3(0f, r, 0f);
            o.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }
        mRemotePeer = uid;
    }

    // When remote user is offline, this delegate will be called. Typically
    // delete the GameObject for this user
    private void onUserOffline(uint uid, USER_OFFLINE_REASON reason)
    {
        // remove video stream
        logD("onUserOffline: uid = " + uid);
        // this is called in main thread
        GameObject go = GameObject.Find(uid.ToString());
        if (!ReferenceEquals(go, null))
        {
            Destroy(go);
        }
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
}
