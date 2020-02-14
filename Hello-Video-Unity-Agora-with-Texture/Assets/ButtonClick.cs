using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using agora_gaming_rtc;
using System.Runtime.InteropServices;
using System.IO;
using System;
#if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
using UnityEngine.Android;
#endif

public class ButtonClick : MonoBehaviour
{

    string deviceName = "";
    string deviceID = "";
    #if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
    private ArrayList permissionList = new ArrayList();
    #endif

    void Awake ()
    {         
        #if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
        permissionList.Add(Permission.Microphone);         
        permissionList.Add(Permission.Camera);               
        #endif     
    }
    void Start()
    {
        exampleApp.logAPICall("ButtonClick Start is called!");
        GameObject go = GameObject.Find("ApiList");
        Dropdown dd = go.GetComponent<Dropdown>();
        dd.ClearOptions();
        List<string> options = new List<string>();
        options.Add("createEngine");
        options.Add("destroyEngine");
        options.Add("GetSdkVersion");
        options.Add("SetLogFile");
        options.Add("SetAudioProfile"); 
        options.Add("leaveChannel");
        options.Add("JoinChannel");
        options.Add("SetDefaultEngineSettings");
        options.Add("SetChannelProfile");
        options.Add("EnableDualStreamMode");
        options.Add("GetCallId");
        options.Add("SetVideoProfile");
        options.Add("SetClientRole");
        options.Add("Pause");
        options.Add("Resume");
        options.Add("SwitchCamera");
        options.Add("MuteLocalVideoStream");
        options.Add("MuteAllRemoteVideoStreams");
        options.Add("SetDefaultMuteAllRemoteAudioStreams");
        options.Add("SetDefaultMuteAllRemoteVideoStreams");
        options.Add("MuteRemoteVideoStream");
        options.Add("SetRemoteVideoStreamType");
        options.Add("EnableVideo");
        options.Add("DisableVideo");
        options.Add("EnableLocalVideo");
        options.Add("StartPreview");
        options.Add("StopPreview");
        options.Add("SetLocalVoicePitch");
        options.Add("SetRemoteVoicePosition");
        //options.Add("SetVoiceOnlyMode");
        options.Add("EnableLocalAudio");
        options.Add("SetEnableSpeakerPhone");
        options.Add("IsSpeakerPhoneEnabled");
        options.Add("SetDefaultAudioRouteToSpeakerphone");
        options.Add("EnableAudioVolumeIndication");
        options.Add("MuteLocalAudioStream");
        options.Add("MuteAllRemoteAudioStreams");
        options.Add("MuteRemoteAudioStream");
        options.Add("AdjustRecordingSignalVolume");
        options.Add("AdjustPlaybackSignalVolume");
        options.Add("EnableVideoObserver");
        options.Add("DisableVideoObserver");
        options.Add("EnableAudio");
        options.Add("DisableAudio");
        options.Add("SetLiveTranscoding");
        options.Add("AddPublishStreamUrl");
        options.Add("RemovePublishStreamUrl");
        //options.Add("ConfigPublisher");
        options.Add("SetVideoCompositingLayout");
        options.Add("ClearVideoCompositingLayout");
        options.Add("AddVideoWatermark");
        options.Add("ClearVideoWatermarks");
        options.Add("SetBeautyEffectOptions");
        options.Add("AddInjectStreamUrl");
        options.Add("RemoveInjectStreamUrl");
        options.Add("EnableSoundPositionIndication");
        options.Add("CreateDataStream");
        options.Add("SendStreamMessage");
        options.Add("SetVideoQualityParameters");
        options.Add("SetSpeakerphoneVolume");
        options.Add("StartEchoTest");
        options.Add("StopEchoTest");
        options.Add("StartLastmileProbeTest");
        options.Add("StopLastmileProbeTest");
        options.Add("SetMixedAudioFrameParameters");
        options.Add("SetAudioMixingPosition");
        options.Add("StartAudioMixing");
        options.Add("StopAudioMixing");
        options.Add("GetAudioMixingPlayoutVolume");
        options.Add("GetAudioMixingPublishVolume");
        options.Add("GetAudioMixingDuration");
        options.Add("PauseAudioMixing");
        options.Add("ResumeAudioMixing");
        options.Add("AdjustAudioMixingVolume");
        options.Add("AdjustAudioMixingPlayoutVolume");
        options.Add("AdjustAudioMixingPublishVolume");
        options.Add("GetAudioMixingCurrentPosition");
        options.Add("StartAudioRecording");
        options.Add("StartAudioRecording2");
        options.Add("StopAudioRecording");
        options.Add("EnableLastmileTest");
        options.Add("DisableLastmileTest");
        options.Add("GetConnectionState");
        options.Add("SetVideoEncoderConfiguration");
        options.Add("SetVolumeOfEffect");
        options.Add("SetRecordingAudioFrameParameters");
        options.Add("SetPlaybackAudioFrameParameters");
        options.Add("SetLocalPublishFallbackOption");
        options.Add("SetRemoteSubscribeFallbackOption");
        options.Add("SetRemoteDefaultVideoStreamType");
        options.Add("SetExternalVideoSource");
        options.Add("SetExternalAudioSource");
        options.Add("PushAudioFrame");
        options.Add("PushAudioFrame2");
        options.Add("EnableSoundPositionIndication");
        options.Add("SetLocalVoiceChanger");
        options.Add("SetLocalVoiceReverbPreset");
        options.Add("SetLocalVoicePitch");
        options.Add("SetLocalVoiceEqualization");
        options.Add("SetLocalVoiceReverb");
        options.Add("SetCameraCapturerConfiguration");
        options.Add("SetRemoteUserPriority");
        options.Add("SetLogFileSize");
        options.Add("SetExternalAudioSink");
        options.Add("RegisterLocalUserAccount");
        options.Add("JoinChannelWithUserAccount");
        options.Add("GetUserInfoByUserAccount");
        options.Add("GetUserInfoByUid");
        options.Add("StartScreenCaptureByDisplayId");
        options.Add("StartScreenCaptureByScreenRect");
        options.Add("SetScreenCaptureContentHint");
        options.Add("UpdateScreenCaptureParameters");
        options.Add("UpdateScreenCaptureRegion");
        options.Add("StopScreenCapture");
        options.Add("EnableLoopbackRecording");
        options.Add("SetAudioSessionOperationRestriction");
        options.Add("StartChannelMediaRelay");
        options.Add("updateChannelMediaRelay");
        options.Add("StopChannelMediaRelay");
        options.Add("SwitchChannel");
        options.Add("SetMirrorApplied");
        options.Add("SetInEarMonitoringVolume");
        options.Add("StartScreenCaptureByWindowId");
        options.Add("EnableInEarMonitoring");
        options.Add("RegisterVideoRawDataObserver");
        options.Add("UnRegisterVideoRawDataObserver");
        options.Add("RegisterAudioRawDataObserver");
        options.Add("UnRegisterAudioRawDataObserver");
        options.Add("PullAudioFrame");
        options.Add("CreatAAudioPlaybackDeviceManager");
        options.Add("ReleaseAAudioPlaybackDeviceManager");
        options.Add("GetAudioPlaybackDeviceCount");
        options.Add("GetAudioPlaybackDevice");
        options.Add("GetCurrentPlaybackDevice");
        options.Add("SetAudioPlaybackDevice");
        options.Add("SetAudioPlaybackDeviceVolume");
        options.Add("GetAudioPlaybackDeviceVolume");
        options.Add("SetAudioPlaybackDeviceMute");
        options.Add("IsAudioPlaybackDeviceMute");
        options.Add("StartAudioPlaybackDeviceTest");
        options.Add("StopAudioPlaybackDeviceTest");
        options.Add("CreatAAudioRecordingDeviceManager");
        options.Add("ReleaseAAudioRecordingDeviceManager");
        options.Add("GetAudioRecordingDeviceCount");
        options.Add("GetAudioRecordingDevice");
        options.Add("GetAudioRecordingDeviceVolume");
        options.Add("SetAudioRecordingDeviceVolume");
        options.Add("IsAudioRecordingDeviceMute");
        options.Add("SetAudioRecordingDeviceMute");
        options.Add("GetCurrentRecordingDevice");
        options.Add("SetAudioRecordingDevice");
        options.Add("StartAudioRecordingDeviceTest");
        options.Add("StopAudioRecordingDeviceTest");
        options.Add("CreateAVideoDeviceManager");
        options.Add("ReleaseAVideoDeviceManager");
        options.Add("StartVideoDeviceTest");
        options.Add("StopVideoDeviceTest");
        options.Add("GetVideoDeviceCollectionCount");
        options.Add("GetVideoDeviceCollectionDevice");
        options.Add("GetCurrentVideoDevice");
        options.Add("SetVideoDeviceCollectionDevice");
        options.Add("RegisterMediaMetadataObserver");
        options.Add("UnRegisterMediaMetadataObserver");
        options.Add("RegisterPacketObserver");
        options.Add("UnRegisterPacketObserver");
        options.Add("RenewToken");
        options.Add("Rate");
        options.Add("Complain");
        options.Add("SetEncryptionMode");
        options.Add("SetEncryptionSecret");
        options.Add("SetVideoQualityParameters");
        options.Add("PushVideoFrame");
        options.Add("GetErrorDescription");
        options.Add("EnableWebSdkInteroperability");
        dd.AddOptions(options);
        go = GameObject.Find("VIDEOPROFILE");
        dd = go.GetComponent<Dropdown>();
        dd.ClearOptions();
        options = new List<string>();
        options.Add("-1 Invalid");
        options.Add("0 120P true (160x120)");
        options.Add("0 120P false (160x120)");
#if UNITY_IPHONE
		options.Add ("2 120P_3 true (120x120)");
		options.Add ("2 120P_3 false (120x120)");
		options.Add ("10 180P true (320x180)");
		options.Add ("10 180P false (320x180)");
		options.Add ("12 180P_3 true (180x180)");
		options.Add ("12 180P_3 false (180x180)");
		options.Add ("13 180P_4 true (240x180)");
		options.Add ("13 180P_4 false (240x180)");
#endif
        options.Add("20 240P true (320x240)");
        options.Add("20 240P false (320x240)");
#if UNITY_IPHONE
		options.Add ("22 240P_3 true (240x240)");
		options.Add ("22 240P_3 false (240x240)");
		options.Add ("23 240P_4 true (420x240)");
		options.Add ("23 240P_4 false (420x240)");
#endif
        options.Add("30 360P true (640x360)");
        options.Add("30 360P false (640x360)");
#if UNITY_IPHONE
		options.Add ("32 360P_3 true (360x360)");
		options.Add ("32 360P_3 false (360x360)");
#endif
        options.Add("33 360P_4 true (640x360)");
        options.Add("33 360P_4 false (640x360)");
        options.Add("35 360P_6 true (360x360)");
        options.Add("35 360P_6 false (360x360)");
        options.Add("36 360P_7 true (480x360)");
        options.Add("36 360P_7 false (480x360)");
        options.Add("37 360P_8 true (480x360)");
        options.Add("37 360P_8 false (480x360)");
        options.Add("38 360P_9 true (640x360)");
        options.Add("38 360P_9 false (640x360)");
        options.Add("39 360P_10 true (640x360)");
        options.Add("39 360P_10 false (640x360)");
        options.Add("100 360P_11 true (640x360)");
        options.Add("100 360P_11 false (640x360)");
        options.Add("40 480P true (640x480)");
        options.Add("40 480P false (640x480)");
#if UNITY_IPHONE
		options.Add ("42 480P_3 true (480x480)");
		options.Add ("42 480P_3 false (480x480)");
#endif
        options.Add("43 480P_4 true (640x480)");
        options.Add("43 480P_4 false (640x480)");
        options.Add("45 480P_6 true (480x480)");
        options.Add("45 480P_6 false (480x480)");
        options.Add("47 480P_8 true (840x480)");
        options.Add("47 480P_8 false (840x480)");
        options.Add("48 480P_9 true (840x480)");
        options.Add("48 480P_9 false (840x480)");
        options.Add("49 480P_10 true (640x480)");
        options.Add("49 480P_10 false (640x480)");
        options.Add("50 720P true (1280x720)");
        options.Add("50 720P false (1280x720)");
        options.Add("52 720P_3 true (1280x720)");
        options.Add("52 720P_3 false (1280x720)");
        options.Add("54 720P_5 true (960x720)");
        options.Add("54 720P_5 false (960x720)");
        options.Add("55 720P_6 true (960x720)");
        options.Add("55 720P_6 false (960x720)");
        dd.AddOptions(options);
    }

    private void CheckPermissions()
    {
        #if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
        foreach(string permission in permissionList)
        {
            if (!Permission.HasUserAuthorizedPermission(permission))
            {                 
                Permission.RequestUserPermission(permission);
            }
        }
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        CheckPermissions();
    }

    static exampleApp app = null;

    private void onJoinButtonClicked()
    {
        // get parameters (channel name, channel profile, etc.)
        GameObject go = GameObject.Find("ChannelName");
        InputField field = go.GetComponent<InputField>();

        // create app if nonexistent
        if (ReferenceEquals(app, null))
        {
            app = new exampleApp(); // create app
            app.loadEngine(); // load engine
        }

        // join channel and jump to next scene
        app.join(field.text);
        SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
        SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
    }

    private void onLeaveButtonClicked()
    {
        if (!ReferenceEquals(app, null))
        {
            app.leave(); // leave channel
            app = null; // delete app
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
    }


    private void setApiParam(int param, string txt)
    {
        string name;
        switch (param)
        {
            case 1:
                name = "FieldParam1";
                break;
            case 2:
                name = "FieldParam2";
                break;
            case 3:
                name = "FieldParam3";
                break;
            case 4:
            default:
                name = "FieldParam4";
                break;
        }

        GameObject go = GameObject.Find(name);
        InputField field = go.GetComponent<InputField>();
        field.text = txt;
    }

    private string getApiParam(int param)
    {
        string name;
        switch (param)
        {
            case 1:
                name = "FieldParam1";
                break;
            case 2:
                name = "FieldParam2";
                break;
            case 3:
                name = "FieldParam3";
                break;
            case 4:
            default:
                name = "FieldParam4";
                break;
        }

        GameObject go = GameObject.Find(name);
        InputField field = go.GetComponent<InputField>();
        string value = field.text;

        return value;
    }

    private int getApiParamInt(int param)
    {
        string sValue = getApiParam(param);
        return int.Parse(sValue);
    }

    private void setApiReturn(string v)
    {
        exampleApp.logAPICall(v);
        GameObject go = GameObject.Find("FieldResult");
        InputField field = go.GetComponent<InputField>();
        field.text = v;
    }

    private void onApiButtonClicked()
    {
        GameObject go = GameObject.Find("ApiList");
        Dropdown dd = go.GetComponent<Dropdown>();
        string api = dd.captionText.text;
        Debug.Log("onApiButtonClicked: " + api);

        if (ReferenceEquals(app, null))
        {
            app = new exampleApp();
            app.loadEngine();
        }
       
        // these APIs do not require engine being created
        if (api.CompareTo("GetSdkVersion") == 0)
        {
            string ret = agora_gaming_rtc.IRtcEngine.GetSdkVersion();
            setApiReturn("GetSdkVersion " + ret);
            return;
        }

        if (api.CompareTo("SetChannelProfile") == 0)
        {
            int num = getApiParamInt(1);

            agora_gaming_rtc.CHANNEL_PROFILE chProfile;
            switch (num)
            {
                case 0:
                    chProfile = agora_gaming_rtc.CHANNEL_PROFILE.CHANNEL_PROFILE_COMMUNICATION;
                    break;
                case 1:
                    chProfile = agora_gaming_rtc.CHANNEL_PROFILE.CHANNEL_PROFILE_LIVE_BROADCASTING;
                    break;
                default:
                    chProfile = agora_gaming_rtc.CHANNEL_PROFILE.CHANNEL_PROFILE_GAME;
                    break;
            }
            int r = app.mRtcEngine.SetChannelProfile(chProfile);
            setApiReturn("SetChannelProfile " + r.ToString());
        }
        else if (api.CompareTo("leaveChannel") == 0)
        {
            int r = app.mRtcEngine.LeaveChannel();
            setApiReturn("leaveChannel " + r.ToString());
        }
        else if (api.CompareTo("JoinChannel") == 0)
        {
            int r = app.mRtcEngine.JoinChannel(getApiParam(1), "", 0);
            setApiReturn("JoinChannel " + r.ToString());
        }
        else if (api.CompareTo("SetDefaultEngineSettings") == 0)
        {
            int r = app.mRtcEngine.SetDefaultEngineSettings();
            setApiReturn("SetDefaultEngineSettings " + r.ToString());
        }
        else if (api.CompareTo("SetClientRole") == 0)
        {
            int num = getApiParamInt(1);
            agora_gaming_rtc.CLIENT_ROLE role;
            switch (num)
            {
                case 1:
                    role = agora_gaming_rtc.CLIENT_ROLE.BROADCASTER;
                    break;
                case 2:
                default:
                    role = agora_gaming_rtc.CLIENT_ROLE.AUDIENCE;
                    break;
            }

            int r = app.mRtcEngine.SetClientRole(role);
            setApiReturn("SetClientRole " + r.ToString());
        }
        else if (api.CompareTo("Pause") == 0)
        {
            app.mRtcEngine.Pause();
        }
        else if (api.CompareTo("Resume") == 0)
        {
            app.mRtcEngine.Resume();
        }
        else if (api.CompareTo("GetCallId") == 0)
        {
            string ret = app.mRtcEngine.GetCallId();
            setApiReturn("GetCallId " + ret);
        }
        else if (api.CompareTo("SwitchCamera") == 0)
        {
            int r = app.mRtcEngine.SwitchCamera();
            setApiReturn("SwitchCamera " + r.ToString());
        }
        else if (api.CompareTo("SetVideoProfile") == 0)
        {
            GameObject go1 = GameObject.Find("VIDEOPROFILE");
            Dropdown dd1 = go1.GetComponent<Dropdown>();
            string s = dd1.captionText.text;
            Debug.Log("VideoProfile: " + s);
            string[] sArray = s.Split(' ');

            int profile = int.Parse(sArray[0]);//getApiParamInt (1);
            int swap = sArray[2].CompareTo("true") == 0 ? 1 : 0;//getApiParamInt (2);

            int r = app.mRtcEngine.SetVideoProfile((VIDEO_PROFILE_TYPE)profile, (swap != 0));
            setApiReturn("SetVideoProfile " + r.ToString());
        }
        else if (api.CompareTo("MuteLocalVideoStream") == 0)
        {
            int mute = getApiParamInt(1);

            int r = app.mRtcEngine.MuteLocalVideoStream(mute != 0);
            setApiReturn("MuteLocalVideoStream " + r.ToString());
        }
        else if (api.CompareTo("MuteAllRemoteVideoStreams") == 0)
        {
            int mute = getApiParamInt(1);

            int r = app.mRtcEngine.MuteAllRemoteVideoStreams(mute != 0);
            setApiReturn("MuteAllRemoteVideoStreams " + r.ToString());
        }
        else if (api.CompareTo("MuteRemoteVideoStream") == 0)
        {
            // auto fill in
            setApiParam(1, app.mRemotePeer.ToString());
            uint uid = app.mRemotePeer;// getApiParamInt (1);
            int mute = getApiParamInt(2);
            int r = app.mRtcEngine.MuteRemoteVideoStream(uid, (mute != 0));
            setApiReturn("MuteRemoteVideoStream " + r.ToString());
        }
        else if (api.CompareTo("EnableDualStreamMode") == 0)
        {
            int enabled = getApiParamInt(1);
            int r = app.mRtcEngine.EnableDualStreamMode(enabled != 0);
            setApiReturn("EnableDualStreamMode " + r.ToString());
        }
        else if (api.CompareTo("SetRemoteVideoStreamType") == 0)
        {
            setApiParam(1, app.mRemotePeer.ToString());
            uint uid = app.mRemotePeer;// getApiParamInt (1);
                                       //int uid = getApiParamInt (1);
            int streamType = getApiParamInt(2);
            int r = app.mRtcEngine.SetRemoteVideoStreamType(uid, (REMOTE_VIDEO_STREAM_TYPE)streamType);
            setApiReturn("SetRemoteVideoStreamType " + r.ToString());
        }
        else if (api.CompareTo("EnableVideo") == 0)
        {
            int r = app.mRtcEngine.EnableVideo();
            setApiReturn("EnableVideo " + r.ToString());
        }
        else if (api.CompareTo("DisableVideo") == 0)
        {
            int r = app.mRtcEngine.DisableVideo();
            setApiReturn("DisableVideo " + r.ToString());
        }
        else if (api.CompareTo("EnableLocalVideo") == 0)
        {
            int enabled = getApiParamInt(1);
            int r = app.mRtcEngine.EnableLocalVideo(enabled != 0);
            setApiReturn("EnableLocalVideo " + r.ToString());
        }
        else if (api.CompareTo("StartPreview") == 0)
        {
            int r = app.mRtcEngine.StartPreview();
            setApiReturn("StartPreview " + r.ToString());
        }
        else if (api.CompareTo("StopPreview") == 0)
        {
            int r = app.mRtcEngine.StopPreview();
            setApiReturn("StopPreview " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoicePitch") == 0)
        {
            string pitch = getApiParam(1);
            int r = app.mRtcEngine.SetLocalVoicePitch(double.Parse(pitch));
            setApiReturn("SetLocalVoicePitch " + r.ToString());
        }
        else if (api.CompareTo("SetRemoteVoicePosition") == 0)
        {
            double pan = double.Parse(getApiParam(2));
            double gain = double.Parse(getApiParam(3));
            //int r = app.mRtcEngine.SetRemoteVoicePosition(app.mRemotePeer, pan, gain);
            AudioEffectManagerImpl audioEffectManager = (AudioEffectManagerImpl)app.mRtcEngine.GetAudioEffectManager();
            int r = audioEffectManager.SetRemoteVoicePosition(app.mRemotePeer, pan, gain);
            setApiReturn("SetRemoteVoicePosition " + r.ToString());
        }
        else if (api.CompareTo("SetVoiceOnlyMode") == 0)
        {
            // int enabled = int.Parse(getApiParam(1));
            // int r = app.mRtcEngine.SetVoiceOnlyMode(enabled != 0);
            //setApiReturn(r.ToString());
        }
        else if (api.CompareTo("EnableLocalAudio") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.EnableLocalAudio(enabled != 0);
            setApiReturn("EnableLocalAudio " + r.ToString());
        }
        else if (api.CompareTo("SetEnableSpeakerPhone") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetEnableSpeakerphone(enabled != 0);
            setApiReturn("SetEnableSpeakerPhone " + r.ToString());
        }
        else if (api.CompareTo("IsSpeakerPhoneEnabled") == 0)
        {
            bool r = app.mRtcEngine.IsSpeakerphoneEnabled();
            setApiReturn("IsSpeakerPhoneEnabled " + r.ToString());
        }
        else if (api.CompareTo("SetDefaultAudioRouteToSpeakerphone") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            Debug.Log("SetDefaultAudioRouteToSpeakerphone  enabled = " + (enabled != 0));
            int r = app.mRtcEngine.SetDefaultAudioRouteToSpeakerphone(enabled != 0);
            setApiReturn("SetDefaultAudioRouteToSpeakerphone " + r.ToString());
        }
        else if (api.CompareTo("EnableSoundPositionIndication") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.EnableSoundPositionIndication(enabled != 0);
            setApiReturn("EnableSoundPositionIndication " + r.ToString());
        }
        else if (api.CompareTo("EnableAudioVolumeIndication") == 0)
        {
            int interval = int.Parse(getApiParam(1));
            int smooth = int.Parse(getApiParam(2));
            int report_vad = int.Parse(getApiParam(3));
            int r = app.mRtcEngine.EnableAudioVolumeIndication(interval, smooth, report_vad != 0);
            setApiReturn("EnableAudioVolumeIndication " + r.ToString());
        }
        else if (api.CompareTo("MuteLocalAudioStream") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.MuteLocalAudioStream(enabled != 0);
            setApiReturn("MuteLocalAudioStream " + r.ToString());
        }
        else if (api.CompareTo("MuteAllRemoteAudioStreams") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.MuteAllRemoteAudioStreams(enabled != 0);
            setApiReturn("MuteAllRemoteAudioStreams " + r.ToString());
        }
        else if (api.CompareTo("MuteRemoteAudioStream") == 0)
        {
            int muted = int.Parse(getApiParam(2));
            int r = app.mRtcEngine.MuteRemoteAudioStream(app.mRemotePeer, muted != 0);
            setApiReturn("MuteRemoteAudioStream " + r.ToString());
        }
        else if (api.CompareTo("AdjustRecordingSignalVolume") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.AdjustRecordingSignalVolume(volume);
            setApiReturn("AdjustRecordingSignalVolume " + r.ToString());
        }
        else if (api.CompareTo("AdjustPlaybackSignalVolume") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.AdjustPlaybackSignalVolume(volume);
            setApiReturn("AdjustPlaybackSignalVolume " + r.ToString());
        }
        else if (api.CompareTo("EnableVideoObserver") == 0)
        {
            int r = app.mRtcEngine.EnableVideoObserver();
            setApiReturn("EnableVideoObserver " + r.ToString());
        }
        else if (api.CompareTo("DisableVideoObserver") == 0)
        {
            int r = app.mRtcEngine.DisableVideoObserver();
            setApiReturn("DisableVideoObserver " + r.ToString());
        }
        else if (api.CompareTo("SetDefaultMuteAllRemoteAudioStreams") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetDefaultMuteAllRemoteAudioStreams(volume != 0);
            setApiReturn("SetDefaultMuteAllRemoteAudioStreams " + r.ToString());
        }
        else if (api.CompareTo("SetDefaultMuteAllRemoteVideoStreams") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetDefaultMuteAllRemoteVideoStreams(volume != 0);
            setApiReturn("SetDefaultMuteAllRemoteVideoStreams " + r.ToString());
        }
        else if (api.CompareTo("EnableAudio") == 0)
        {
            int r = app.mRtcEngine.EnableAudio();
            setApiReturn("EnableAudio " + r.ToString());
        }
        else if (api.CompareTo("DisableAudio") == 0)
        {
            int r = app.mRtcEngine.DisableAudio();
            setApiReturn("DisableAudio " + r.ToString());
        }
        else if (api.CompareTo("SetLiveTranscoding") == 0)
        {
            LiveTranscoding liveTranscoding = new LiveTranscoding();
            liveTranscoding.width = 360;
            liveTranscoding.height = 640;
            liveTranscoding.videoBitrate = 400;
            liveTranscoding.videoFramerate = 30;
            liveTranscoding.lowLatency = true;
            liveTranscoding.videoGop = 30;
            liveTranscoding.videoCodecProfile = VIDEO_CODEC_PROFILE_TYPE.VIDEO_CODEC_PROFILE_HIGH;
            liveTranscoding.backgroundColor = 192192192;
            liveTranscoding.userCount = 1;
            liveTranscoding.transcodingExtraInfo = "";
            liveTranscoding.metadata = "hehe";
            int r = app.mRtcEngine.SetLiveTranscoding(liveTranscoding);
            setApiReturn("SetLiveTranscoding " + r.ToString());
        }
        else if (api.CompareTo("AddPublishStreamUrl") == 0)
        {
            int r = app.mRtcEngine.AddPublishStreamUrl("http://www.baidu.com/", true);
            setApiReturn("AddPublishStreamUrl " + r.ToString());
        }
        else if (api.CompareTo("RemovePublishStreamUrl") == 0)
        {
            int r = app.mRtcEngine.RemovePublishStreamUrl("http://www.baidu.com/");
            setApiReturn("RemovePublishStreamUrl " + r.ToString());
        }
        else if (api.CompareTo("ConfigPublisher") == 0)
        {
            // PublisherConfiguration publisherConfiguration = new PublisherConfiguration();
            // int r = app.mRtcEngine.ConfigPublisher(publisherConfiguration);
            // setApiReturn(r.ToString());
        }
        else if (api.CompareTo("SetVideoCompositingLayout") == 0)
        {
           
        }
        else if (api.CompareTo("AddVideoWatermark") == 0)
        {
            RtcImage rtcImage = new RtcImage();
            rtcImage.url = "http://pic16.nipic.com/20111006/6239936_092702973000_2.jpg";
            int r = app.mRtcEngine.AddVideoWatermark(rtcImage);
            setApiReturn("AddVideoWatermark " + r.ToString());
        }
        else if (api.CompareTo("ClearVideoWatermarks") == 0)
        {
            int r = app.mRtcEngine.ClearVideoWatermarks();
            setApiReturn("ClearVideoWatermarks " + r.ToString());
        }
        else if (api.CompareTo("SetBeautyEffectOptions") == 0)
        {
            BeautyOptions beautyOptions = new BeautyOptions();
            beautyOptions.lighteningContrastLevel = BeautyOptions.LIGHTENING_CONTRAST_LEVEL.LIGHTENING_CONTRAST_HIGH;
            beautyOptions.lighteningLevel = 0.5f;
            beautyOptions.rednessLevel = 0.5f;
            beautyOptions.smoothnessLevel = 0.5f;
            int r = app.mRtcEngine.SetBeautyEffectOptions(true, beautyOptions);
            setApiReturn("SetBeautyEffectOptions " + r.ToString());
        }
        else if (api.CompareTo("AddInjectStreamUrl") == 0)
        {
            InjectStreamConfig injectStreamConfig = new InjectStreamConfig();
            int r = app.mRtcEngine.AddInjectStreamUrl("http://www.baidu.com/", injectStreamConfig);
            setApiReturn("AddInjectStreamUrl " + r.ToString());
        }
        else if (api.CompareTo("RemoveInjectStreamUrl") == 0)
        {
            int r = app.mRtcEngine.RemoveInjectStreamUrl("http://www.baidu.com/");
            setApiReturn("RemoveInjectStreamUrl " + r.ToString());
        }
        else if (api.CompareTo("CreateDataStream") == 0)
        {
            int reliable = int.Parse(getApiParam(1));
            int order = int.Parse(getApiParam(2));
            int r = app.mRtcEngine.CreateDataStream(reliable != 0, order != 0);
            setApiReturn("CreateDataStream " + r.ToString());
        }
        else if (api.CompareTo("SendStreamMessage") == 0)
        {
            int streamId = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SendStreamMessage(streamId, getApiParam(2));
            setApiReturn("SendStreamMessage " + r.ToString());
        }
        else if (api.CompareTo("SetSpeakerphoneVolume") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetSpeakerphoneVolume(volume);
            setApiReturn("SetSpeakerphoneVolume " + r.ToString());
        }
        else if (api.CompareTo("SetVideoQualityParameters") == 0)
        {
            int preferFrameRateOverImageQuality = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetVideoQualityParameters(preferFrameRateOverImageQuality != 0);
            setApiReturn("SetVideoQualityParameters " + r.ToString());
        }
        else if (api.CompareTo("StartEchoTest") == 0)
        {
            int r = app.mRtcEngine.StartEchoTest();
            setApiReturn("StartEchoTest " + r.ToString());
        }
        else if (api.CompareTo("StopEchoTest") == 0)
        {
            int r = app.mRtcEngine.StopEchoTest();
            setApiReturn("StopEchoTest " + r.ToString());
        }
        else if (api.CompareTo("StartLastmileProbeTest") == 0)
        {
            LastmileProbeConfig lastmileProbeConfig = new LastmileProbeConfig();
            lastmileProbeConfig.probeUplink = int.Parse(getApiParam(1)) != 0;
            lastmileProbeConfig.probeDownlink = int.Parse(getApiParam(2)) != 0;
            lastmileProbeConfig.expectedUplinkBitrate = uint.Parse(getApiParam(3));
            lastmileProbeConfig.expectedDownlinkBitrate = uint.Parse(getApiParam(4));
            int r = app.mRtcEngine.StartLastmileProbeTest(lastmileProbeConfig);
            setApiReturn("StartLastmileProbeTest " + r.ToString());
        }
        else if (api.CompareTo("StopLastmileProbeTest") == 0)
        {
            int r = app.mRtcEngine.StopLastmileProbeTest();
            setApiReturn("StopLastmileProbeTest " + r.ToString());
        }
        else if (api.CompareTo("SetMixedAudioFrameParameters") == 0)
        {
            int r = app.mRtcEngine.SetMixedAudioFrameParameters(int.Parse(getApiParam(1)), int.Parse(getApiParam(2)));
            setApiReturn("SetMixedAudioFrameParameters " + r.ToString());
        }
        else if (api.CompareTo("SetAudioMixingPosition") == 0)
        {
            int r = app.mRtcEngine.SetAudioMixingPosition(int.Parse(getApiParam(1)));
            setApiReturn("SetAudioMixingPosition " + r.ToString());
        }
        else if (api.CompareTo("StartAudioMixing") == 0)
        {
            int r = app.mRtcEngine.StartAudioMixing(getApiParam(1), true, true, 1);
            setApiReturn("StartAudioMixing " + r.ToString());
        }
        else if (api.CompareTo("StopAudioMixing") == 0)
        {
            int r = app.mRtcEngine.StopAudioMixing();
            setApiReturn("StopAudioMixing " + r.ToString());
        }
        else if (api.CompareTo("PauseAudioMixing") == 0)
        {
            int r = app.mRtcEngine.PauseAudioMixing();
            setApiReturn("PauseAudioMixing " + r.ToString());
        }
        else if (api.CompareTo("ResumeAudioMixing") == 0)
        {
            int r = app.mRtcEngine.ResumeAudioMixing();
            setApiReturn("ResumeAudioMixing " + r.ToString());
        }
        else if (api.CompareTo("AdjustAudioMixingVolume") == 0)
        {
            int r = app.mRtcEngine.AdjustAudioMixingVolume(int.Parse(getApiParam(1)));
            setApiReturn("AdjustAudioMixingVolume " + r.ToString());
        }
        else if (api.CompareTo("GetAudioMixingDuration") == 0)
        {
            int r = app.mRtcEngine.GetAudioMixingDuration();
            setApiReturn("GetAudioMixingDuration " + r.ToString());
        }
        else if (api.CompareTo("GetAudioMixingCurrentPosition") == 0)
        {
            int r = app.mRtcEngine.GetAudioMixingCurrentPosition();
            setApiReturn("GetAudioMixingCurrentPosition " + r.ToString());
        }
        else if (api.CompareTo("StartAudioRecording") == 0)
        {
            int r = app.mRtcEngine.StartAudioRecording("/sdcard/test.wav", AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_HIGH);
            setApiReturn("StartAudioRecording " + r.ToString());
        }
        else if (api.CompareTo("StartAudioRecording2") == 0)
        {
//            int r = app.mRtcEngine.StartAudioRecording("/sdcard/test.wav", 16000, AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_HIGH);
        }
        else if (api.CompareTo("StopAudioRecording") == 0)
        {
            int r = app.mRtcEngine.StopAudioRecording();
            setApiReturn("StopAudioRecording " + r.ToString());
        }
        else if (api.CompareTo("EnableLastmileTest") == 0)
        {
            int r = app.mRtcEngine.EnableLastmileTest();
            setApiReturn("EnableLastmileTest " + r.ToString());
        }
        else if (api.CompareTo("DisableLastmileTest") == 0)
        {
            int r = app.mRtcEngine.DisableLastmileTest();
            setApiReturn("DisableLastmileTest " + r.ToString());
        }
        else if (api.CompareTo("GetConnectionState") == 0)
        {
            int r = (int)app.mRtcEngine.GetConnectionState();
            setApiReturn("GetConnectionState " + r.ToString());
        }
        else if (api.CompareTo("SetAudioProfile") == 0)
        {
            int r = app.mRtcEngine.SetAudioProfile((AUDIO_PROFILE_TYPE)int.Parse(getApiParam(1)), (AUDIO_SCENARIO_TYPE)int.Parse(getApiParam(2)));
            setApiReturn("SetAudioProfile " + r.ToString());
        }
        else if (api.CompareTo("SetVideoEncoderConfiguration") == 0)
        {
            VideoEncoderConfiguration videoEncoder = new VideoEncoderConfiguration();
            VideoDimensions videoDimensions = new VideoDimensions();
            videoDimensions.width = 640;
            videoDimensions.height = 360;
            videoEncoder.dimensions = videoDimensions;
            videoEncoder.frameRate = FRAME_RATE.FRAME_RATE_FPS_15;
            videoEncoder.minFrameRate = 10;
            videoEncoder.bitrate = 350;
            videoEncoder.minBitrate = 100;
            videoEncoder.orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_FIXED_LANDSCAPE;
            videoEncoder.degradationPreference = DEGRADATION_PREFERENCE.MAINTAIN_BALANCED;
            int r = app.mRtcEngine.SetVideoEncoderConfiguration(videoEncoder);
            setApiReturn("SetVideoEncoderConfiguration " + r.ToString());
        }
        else if (api.CompareTo("AdjustAudioMixingPlayoutVolume") == 0)
        {
            int r = app.mRtcEngine.AdjustAudioMixingPlayoutVolume(int.Parse(getApiParam(1)));
            setApiReturn("AdjustAudioMixingPlayoutVolume " + r.ToString());
        }
        else if (api.CompareTo("AdjustAudioMixingPublishVolume") == 0)
        {
            int r = app.mRtcEngine.AdjustAudioMixingPublishVolume(int.Parse(getApiParam(1)));
            setApiReturn("AdjustAudioMixingPublishVolume " + r.ToString());
        }
        else if (api.CompareTo("SetVolumeOfEffect") == 0)
        {
            int r = app.mRtcEngine.SetVolumeOfEffect(int.Parse(getApiParam(1)), int.Parse(getApiParam(2)));
            setApiReturn("SetVolumeOfEffect " + r.ToString());
        }
        else if (api.CompareTo("SetRecordingAudioFrameParameters") == 0)
        {
            int r = app.mRtcEngine.SetRecordingAudioFrameParameters(int.Parse(getApiParam(1)), int.Parse(getApiParam(2)), (RAW_AUDIO_FRAME_OP_MODE_TYPE)int.Parse(getApiParam(3)), int.Parse(getApiParam(4)));
            setApiReturn("SetRecordingAudioFrameParameters " + r.ToString());
        }
        else if (api.CompareTo("SetPlaybackAudioFrameParameters") == 0)
        {
            int r = app.mRtcEngine.SetPlaybackAudioFrameParameters(int.Parse(getApiParam(1)), int.Parse(getApiParam(2)), (RAW_AUDIO_FRAME_OP_MODE_TYPE)int.Parse(getApiParam(3)), int.Parse(getApiParam(4)));
            setApiReturn("SetPlaybackAudioFrameParameters " + r.ToString());
        }
        else if (api.CompareTo("SetLocalPublishFallbackOption") == 0)
        {
            int r = app.mRtcEngine.SetLocalPublishFallbackOption((STREAM_FALLBACK_OPTIONS)int.Parse(getApiParam(1)));
            setApiReturn("SetLocalPublishFallbackOption " + r.ToString());
        }
        else if (api.CompareTo("SetRemoteSubscribeFallbackOption") == 0)
        {
            int r = app.mRtcEngine.SetRemoteSubscribeFallbackOption((STREAM_FALLBACK_OPTIONS)int.Parse(getApiParam(1)));
            setApiReturn("SetRemoteSubscribeFallbackOption " + r.ToString());
        }
        else if (api.CompareTo("SetRemoteDefaultVideoStreamType") == 0)
        {
            int r = app.mRtcEngine.SetRemoteDefaultVideoStreamType((REMOTE_VIDEO_STREAM_TYPE)int.Parse(getApiParam(1)));
            setApiReturn("SetRemoteDefaultVideoStreamType " + r.ToString());
        }
        else if (api.CompareTo("GetErrorDescription") == 0)
        {
            string r = IRtcEngine.GetErrorDescription(int.Parse(getApiParam(1)));
            setApiReturn("GetErrorDescription " + r.ToString());
        }
        else if (api.CompareTo("EnableWebSdkInteroperability") == 0)
        {
            int r = app.mRtcEngine.EnableWebSdkInteroperability(int.Parse(getApiParam(1)) != 0);
            setApiReturn("EnableWebSdkInteroperability " + r.ToString());
        }
        else if (api.CompareTo("SetExternalVideoSource") == 0)
        {
            int r = app.mRtcEngine.SetExternalVideoSource(int.Parse(getApiParam(1))!=0 , int.Parse(getApiParam(2))!=0);
            setApiReturn("SetExternalVideoSource " + r.ToString());
        }
        else if (api.CompareTo("SetExternalAudioSource") == 0)
        {
            int r = app.mRtcEngine.SetExternalAudioSource(int.Parse(getApiParam(1))!=0, int.Parse(getApiParam(2)), int.Parse(getApiParam(3)));
            setApiReturn("SetExternalAudioSource " + r.ToString());
        }
        else if (api.CompareTo("PushAudioFrame") == 0)
        {
            int r = app.mRtcEngine.PushAudioFrame(new AudioFrame());
            setApiReturn("PushAudioFrame " + r.ToString());
        }
        else if (api.CompareTo("PushAudioFrame2") == 0)
        {
            // AudioFrame audioFrame = new AudioFrame();
            // int r = app.mRtcEngine.PushAudioFrame2(MEDIA_SOURCE_TYPE.AUDIO_PLAYOUT_SOURCE, audioFrame, true);
            // setApiReturn("PushAudioFrame2 " + r.ToString());
        }
        else if (api.CompareTo("GetAudioMixingPlayoutVolume") == 0)
        {
            int r = app.mRtcEngine.GetAudioMixingPlayoutVolume();
            setApiReturn("GetAudioMixingPlayoutVolume " + r.ToString());
        }
        else if (api.CompareTo("GetAudioMixingPublishVolume") == 0)
        {
            int r = app.mRtcEngine.GetAudioMixingPublishVolume();
            setApiReturn("GetAudioMixingPublishVolume  r = " + r);
        }
        else if (api.CompareTo("EnableSoundPositionIndication") == 0)
        {
            int r = app.mRtcEngine.EnableSoundPositionIndication(int.Parse(getApiParam(1)) != 0);
            setApiReturn("EnableSoundPositionIndication " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoiceChanger") == 0)
        {
            int r = app.mRtcEngine.SetLocalVoiceChanger((VOICE_CHANGER_PRESET)int.Parse(getApiParam(1)));
            setApiReturn("SetLocalVoiceChanger " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoiceReverbPreset") == 0)
        {
            int r = app.mRtcEngine.SetLocalVoiceReverbPreset((AUDIO_REVERB_PRESET)int.Parse(getApiParam(1)));
            setApiReturn("SetLocalVoiceReverbPreset " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoicePitch") == 0)
        {
            int r = app.mRtcEngine.SetLocalVoicePitch(double.Parse(getApiParam(1)));
            setApiReturn("SetLocalVoicePitch " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoiceEqualization") == 0)
        {
            int r = app.mRtcEngine.SetLocalVoiceEqualization((AUDIO_EQUALIZATION_BAND_FREQUENCY)int.Parse(getApiParam(1)), int.Parse(getApiParam(2)));
            setApiReturn("SetLocalVoiceEqualization " + r.ToString());
        }
        else if (api.CompareTo("SetLocalVoiceReverb") == 0)
        {
            int r = app.mRtcEngine.SetLocalVoiceReverb((AUDIO_REVERB_TYPE)int.Parse(getApiParam(1)), int.Parse(getApiParam(2)));
            setApiReturn("SetLocalVoiceReverb " + r.ToString());
        }
        else if (api.CompareTo("SetCameraCapturerConfiguration") == 0)
        {
            CameraCapturerConfiguration cameraCapturerConfiguration = new CameraCapturerConfiguration();
            cameraCapturerConfiguration.preference = (CAPTURER_OUTPUT_PREFERENCE)int.Parse(getApiParam(1));
            cameraCapturerConfiguration.cameraDirection = (CAMERA_DIRECTION)int.Parse(getApiParam(2));
            int r = app.mRtcEngine.SetCameraCapturerConfiguration(cameraCapturerConfiguration);
            setApiReturn("SetCameraCapturerConfiguration " + r.ToString());
        }
        else if (api.CompareTo("SetRemoteUserPriority") == 0)
        {
            int r = app.mRtcEngine.SetRemoteUserPriority(uint.Parse(getApiParam(1)), (PRIORITY_TYPE)int.Parse(getApiParam(2)));
            setApiReturn("SetRemoteUserPriority " + r.ToString());
        }
        else if (api.CompareTo("SetLogFileSize") == 0)
        {
            int r = app.mRtcEngine.SetLogFileSize(uint.Parse(getApiParam(1)));
            setApiReturn("SetLogFileSize " + r.ToString());
        }
        else if (api.CompareTo("SetExternalAudioSink") == 0)
        {
            int r = app.mRtcEngine.SetExternalAudioSink(int.Parse(getApiParam(1))!=0, int.Parse(getApiParam(2)), int.Parse(getApiParam(3)));
            // if (app.audioBuffer != IntPtr.Zero)
            // {
            //     Marshal.FreeHGlobal(app.audioBuffer);
            //     app.audioBuffer = IntPtr.Zero; 
            // }
            // app.audioBuffer = Marshal.AllocHGlobal(int.Parse(getApiParam(2)) * 2 * int.Parse(getApiParam(3)) * 1000/100 * sizeof(Byte));
            app.sampleRate = int.Parse(getApiParam(2));
            app.channels = int.Parse(getApiParam(3));
            setApiReturn("SetExternalAudioSink " + int.Parse(getApiParam(2)) * 2 * int.Parse(getApiParam(3)) * 1000/100 * sizeof(Byte) + "     audiobuffer = " + (app.audioBuffer == IntPtr.Zero));
        }
        else if (api.CompareTo("RegisterLocalUserAccount") == 0)
        {
            int r = app.mRtcEngine.RegisterLocalUserAccount(exampleApp.mVendorKey, getApiParam(1));
            setApiReturn("RegisterLocalUserAccount " + r.ToString());
        }
        else if (api.CompareTo("JoinChannelWithUserAccount") == 0)
        {
            int r = app.mRtcEngine.JoinChannelWithUserAccount("", getApiParam(1), getApiParam(2));
            setApiReturn("JoinChannelWithUserAccount " + r.ToString());
        }
        else if (api.CompareTo("GetUserInfoByUserAccount") == 0)
        {
            UserInfo r = app.mRtcEngine.GetUserInfoByUserAccount(getApiParam(1));
            setApiReturn("GetUserInfoByUserAccount " + "userInfo userAccount = " + r.userAccount + "  ,uid = " + r.uid);
        }
        else if (api.CompareTo("GetUserInfoByUid") == 0)
        {
            UserInfo r = app.mRtcEngine.GetUserInfoByUid(uint.Parse(getApiParam(1)));
            setApiReturn("GetUserInfoByUid " + "userInfo userAccount = " + r.userAccount + "  ,uid = " + r.uid);
        }
        else if (api.CompareTo("StartScreenCaptureByDisplayId") == 0)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.x = 100;
            rectangle.y = 100;
            rectangle.width = 500;
            rectangle.height = 500;
            int r = app.mRtcEngine.StartScreenCaptureByDisplayId(0, rectangle, new ScreenCaptureParameters());
            setApiReturn("StartScreenCaptureByDisplayId " + r.ToString());
        }
        else if (api.CompareTo("StartScreenCaptureByScreenRect") == 0)
        {
            int r = app.mRtcEngine.StartScreenCaptureByScreenRect(new Rectangle(), new Rectangle(), new ScreenCaptureParameters());
            setApiReturn("StartScreenCaptureByScreenRect " + r.ToString());
        }
        else if (api.CompareTo("SetScreenCaptureContentHint") == 0)
        {
            int r = app.mRtcEngine.SetScreenCaptureContentHint((VideoContentHint)int.Parse(getApiParam(1)));
            setApiReturn("SetScreenCaptureContentHint " + r.ToString());
        }
        else if (api.CompareTo("UpdateScreenCaptureParameters") == 0)
        {
            int r = app.mRtcEngine.UpdateScreenCaptureParameters(new ScreenCaptureParameters());
            setApiReturn("UpdateScreenCaptureParameters " + r.ToString());
        }
        else if (api.CompareTo("UpdateScreenCaptureRegion") == 0)
        {
            int r = app.mRtcEngine.UpdateScreenCaptureRegion(new Rectangle());
            setApiReturn("UpdateScreenCaptureRegion " + r.ToString());
        }
        else if (api.CompareTo("StopScreenCapture") == 0)
        {
            int r = app.mRtcEngine.StopScreenCapture();
            setApiReturn("StopScreenCapture " + r.ToString());
        }
        else if (api.CompareTo("EnableLoopbackRecording") == 0)
        {
            int r = app.mRtcEngine.EnableLoopbackRecording(int.Parse(getApiParam(1)) != 0, getApiParam(2));
            setApiReturn("EnableLoopbackRecording " + r.ToString());
        }   
        else if (api.CompareTo("SetAudioSessionOperationRestriction") == 0)
        {
            int r = app.mRtcEngine.SetAudioSessionOperationRestriction((AUDIO_SESSION_OPERATION_RESTRICTION)int.Parse(getApiParam(1)));
            setApiReturn("SetAudioSessionOperationRestriction " + r.ToString());
        }
        else if (api.CompareTo("StartChannelMediaRelay") == 0)
        {
            ChannelMediaInfo src = new ChannelMediaInfo();
            src.channelName = "23";
            src.token = null;
            src.uid = 100;

            ChannelMediaInfo dest = new ChannelMediaInfo();
            dest.channelName = "23";
            dest.token = null;
            dest.uid = 100;

            ChannelMediaRelayConfiguration channelMediaRelayConfiguration = new ChannelMediaRelayConfiguration();
            channelMediaRelayConfiguration.srcInfo = src;
            channelMediaRelayConfiguration.destInfos = dest;
            channelMediaRelayConfiguration.destCount = 1;
            int r = app.mRtcEngine.StartChannelMediaRelay(channelMediaRelayConfiguration);
            setApiReturn("StartChannelMediaRelay " + r.ToString());
        }
        else if (api.CompareTo("updateChannelMediaRelay") == 0)
        {
            ChannelMediaInfo src = new ChannelMediaInfo();
            src.channelName = "23";
            src.token = null;
            src.uid = 100;

            ChannelMediaInfo dest = new ChannelMediaInfo();
            dest.channelName = "23";
            dest.token = null;
            dest.uid = 100;

            ChannelMediaRelayConfiguration channelMediaRelayConfiguration = new ChannelMediaRelayConfiguration();
            channelMediaRelayConfiguration.srcInfo = src;
            channelMediaRelayConfiguration.destInfos = dest;
            channelMediaRelayConfiguration.destCount = 1;
            int r = app.mRtcEngine.UpdateChannelMediaRelay(channelMediaRelayConfiguration);
            setApiReturn("updateChannelMediaRelay " + r.ToString());
        }
        else if (api.CompareTo("StopChannelMediaRelay") == 0)
        {
            int r = app.mRtcEngine.StopChannelMediaRelay();
            setApiReturn("StopChannelMediaRelay " + r.ToString());
        }
        else if (api.CompareTo("SwitchChannel") == 0)
        {
            int r = app.mRtcEngine.SwitchChannel("", getApiParam(1));
            setApiReturn("SwitchChannel " + r.ToString());
        }
        else if (api.CompareTo("SetMirrorApplied") == 0)
        {
            int r = app.mRtcEngine.SetMirrorApplied(int.Parse(getApiParam(1)) != 0);
            setApiReturn("SetMirrorApplied " + r.ToString());
        }
        else if (api.CompareTo("SetInEarMonitoringVolume") == 0)
        {
            int r = app.mRtcEngine.SetInEarMonitoringVolume(int.Parse(getApiParam(1)));
            setApiReturn("SetInEarMonitoringVolume " + r.ToString());
        }
        else if (api.CompareTo("StartScreenCaptureByWindowId") == 0)
        {
            int r = app.mRtcEngine.StartScreenCaptureByDisplayId(0, new Rectangle(), new ScreenCaptureParameters());
            setApiReturn("StartScreenCaptureByWindowId " + r.ToString());
        }
        else if (api.CompareTo("EnableInEarMonitoring") == 0)
        {
            int r = app.mRtcEngine.EnableInEarMonitoring(int.Parse(getApiParam(1)) != 0);
            setApiReturn("EnableInEarMonitoring " + r.ToString());
        }
        else if (api.CompareTo("RegisterVideoRawDataObserver") == 0)
        {
            int r = app.videoRawDataManager.RegisterVideoRawDataObserver();
            setApiReturn("RegisterVideoRawDataObserver " + r.ToString());
        }
        else if (api.CompareTo("UnRegisterVideoRawDataObserver") == 0)
        {
            int r = app.videoRawDataManager.UnRegisterVideoRawDataObserver();
            setApiReturn("UnRegisterVideoRawDataObserver " + r.ToString());
        }
        else if (api.CompareTo("RegisterAudioRawDataObserver") == 0)
        {
            int r = app.audioRawDataManager.RegisterAudioRawDataObserver();
            setApiReturn("RegisterAudioRawDataObserver  " + r.ToString());
        }
        else if (api.CompareTo("UnRegisterAudioRawDataObserver") == 0)
        {
            int r = app.audioRawDataManager.UnRegisterAudioRawDataObserver();
            setApiReturn("UnRegisterAudioRawDataObserver  " + r.ToString());
        }
        else if (api.CompareTo("PullAudioFrame") == 0)
        { 
            int r = 100;
            if (app.audioBuffer != IntPtr.Zero)
            {
                r = app.audioRawDataManager.PullAudioFrame(app.audioBuffer, 0, app.sampleRate, 2, app.channels, 2000, 18928393, 0);
            }  
            setApiReturn("PullAudioFrame  " + r.ToString());
        }
        else if (api.CompareTo("CreatAAudioPlaybackDeviceManager") == 0)
        {
            bool r = app.audioPlaybackDeviceManager.CreateAAudioPlaybackDeviceManager();
            setApiReturn("CreatAAudioPlaybackDeviceManager " + r.ToString());
        }
        else if (api.CompareTo("ReleaseAAudioPlaybackDeviceManager") == 0)
        {
            int r = app.audioPlaybackDeviceManager.ReleaseAAudioPlaybackDeviceManager();
            setApiReturn("ReleaseAAudioPlaybackDeviceManager " + r.ToString());
        }
        else if (api.CompareTo("GetAudioPlaybackDeviceCount") == 0)
        {
            int r = app.audioPlaybackDeviceManager.GetAudioPlaybackDeviceCount();
            setApiReturn("GetAudioPlaybackDeviceCount " + r.ToString());
        }
        else if (api.CompareTo("GetAudioPlaybackDevice") == 0)
        {
            int r = app.audioPlaybackDeviceManager.GetAudioPlaybackDevice(int.Parse(getApiParam(1)), ref deviceName, ref deviceID);
            setApiReturn("GetAudioPlaybackDevice " + r.ToString());
        }
        else if (api.CompareTo("SetAudioPlaybackDevice") == 0)
        {
            int r = app.audioPlaybackDeviceManager.SetAudioPlaybackDevice(deviceID);
            setApiReturn("SetAudioPlaybackDevice  r = " + r.ToString() + "  , devcieId = " + deviceID);
        }
        else if (api.CompareTo("SetAudioPlaybackDeviceVolume") == 0)
        {
            int r = app.audioPlaybackDeviceManager.SetAudioPlaybackDeviceVolume(int.Parse(getApiParam(1)));
            setApiReturn("SetAudioPlaybackDeviceVolume  " + r.ToString());
        }
        else if (api.CompareTo("GetAudioPlaybackDeviceVolume") == 0)
        {
            int r = app.audioPlaybackDeviceManager.GetAudioPlaybackDeviceVolume();
            setApiReturn("GetAudioPlaybackDeviceVolume  " + r.ToString());
        }
        else if (api.CompareTo("SetAudioPlaybackDeviceMute") == 0)
        {
            int r = app.audioPlaybackDeviceManager.SetAudioPlaybackDeviceMute(int.Parse(getApiParam(1))!=0);
            setApiReturn("SetAudioPlaybackDeviceMute  " + r.ToString());
        }
        else if (api.CompareTo("IsAudioPlaybackDeviceMute") == 0)
        {
            bool r = app.audioPlaybackDeviceManager.IsAudioPlaybackDeviceMute();
            setApiReturn("IsAudioPlaybackDeviceMute  " + r.ToString());
        }
        else if (api.CompareTo("GetCurrentPlaybackDevice") == 0)
        {
            string deviceId = "";
            int r = app.audioPlaybackDeviceManager.GetCurrentPlaybackDevice(ref deviceId);
            setApiReturn("GetCurrentPlaybackDevice  deviceId = " + deviceId);
        }
        else if (api.CompareTo("StartAudioPlaybackDeviceTest") == 0)
        {
            int r = app.audioPlaybackDeviceManager.StartAudioPlaybackDeviceTest(getApiParam(1));
            setApiReturn("StartAudioPlaybackDeviceTest  " + r.ToString());
        }
        else if (api.CompareTo("StopAudioPlaybackDeviceTest") == 0)
        {
            int r = app.audioPlaybackDeviceManager.StopAudioPlaybackDeviceTest();
            setApiReturn("StopAudioPlaybackDeviceTest  " + r.ToString());
        }
        else if (api.CompareTo("CreatAAudioRecordingDeviceManager") == 0)
        {
            bool r = app.audioRecordingoDeviceManager.CreateAAudioRecordingDeviceManager();
            setApiReturn("CreatAAudioRecordingDeviceManager  " + r.ToString());
        }
        else if (api.CompareTo("ReleaseAAudioRecordingDeviceManager") == 0)
        {
            int r = app.audioRecordingoDeviceManager.ReleaseAAudioRecordingDeviceManager();
            setApiReturn("ReleaseAAudioRecordingDeviceManager  " + r.ToString());
        }
        else if (api.CompareTo("GetAudioRecordingDeviceCount") == 0)
        {
            int r = app.audioRecordingoDeviceManager.GetAudioRecordingDeviceCount();
            setApiReturn("GetAudioRecordingDeviceCount  " + r.ToString());
        }
        else if (api.CompareTo("GetAudioRecordingDevice") == 0)
        {
            int r = app.audioRecordingoDeviceManager.GetAudioRecordingDevice(int.Parse(getApiParam(1)), ref deviceName, ref deviceID);
            setApiReturn("GetAudioRecordingDevice  " + r.ToString());
        }
        else if (api.CompareTo("SetAudioRecordingDevice") == 0)
        {
            int r = app.audioRecordingoDeviceManager.SetAudioRecordingDevice(deviceID);
            setApiReturn("SetAudioRecordingDevice  r = " + r.ToString() + "  , deviceID = " + deviceID);
        }
        else if (api.CompareTo("StartAudioRecordingDeviceTest") == 0)
        {
            int r = app.audioRecordingoDeviceManager.StartAudioRecordingDeviceTest(int.Parse(getApiParam(1)));
            setApiReturn("SetAudioRecordingDevice  " + r.ToString());
        }
        else if (api.CompareTo("GetCurrentRecordingDevice") == 0)
        {
            string deviceId = "";
            int r = app.audioRecordingoDeviceManager.GetCurrentRecordingDevice(ref deviceId);
            setApiReturn("GetCurrentRecordingDevice devieId = " + deviceId);
        }
        else if (api.CompareTo("GetAudioRecordingDeviceVolume") == 0)
        {
            int r = app.audioRecordingoDeviceManager.GetAudioRecordingDeviceVolume();
            setApiReturn("GetAudioRecordingDeviceVolume volume = " + r);
        }
        else if (api.CompareTo("SetAudioRecordingDeviceVolume") == 0)
        {
            int r = app.audioRecordingoDeviceManager.SetAudioRecordingDeviceVolume(int.Parse(getApiParam(1)));
            setApiReturn("SetAudioRecordingDeviceVolume r = " + r);
        }
        else if (api.CompareTo("IsAudioRecordingDeviceMute") == 0)
        {
            bool r = app.audioRecordingoDeviceManager.IsAudioRecordingDeviceMute();
            setApiReturn("IsAudioRecordingDeviceMute r = " + r);
        }
        else if (api.CompareTo("SetAudioRecordingDeviceMute") == 0)
        {
            int r = app.audioRecordingoDeviceManager.SetAudioRecordingDeviceMute(int.Parse(getApiParam(1))!=0);
        }
        else if (api.CompareTo("StopAudioRecordingDeviceTest") == 0)
        {
            int r = app.audioRecordingoDeviceManager.StopAudioRecordingDeviceTest();
            setApiReturn("StopAudioRecordingDeviceTest  " + r.ToString());
        }
        else if (api.CompareTo("CreateAVideoDeviceManager") == 0)
        {
            bool r = app.videoDeviceManager.CreateAVideoDeviceManager();
            setApiReturn("CreateAVideoDeviceManager  r = " + r);
        }
        else if (api.CompareTo("ReleaseAVideoDeviceManager") == 0)
        {
            int r = app.videoDeviceManager.ReleaseAVideoDeviceManager();
            setApiReturn("ReleaseAVideoDeviceManager r = " + r );
        }
        else if (api.CompareTo("StartVideoDeviceTest") == 0)
        {
            int r = app.videoDeviceManager.StartVideoDeviceTest(new System.IntPtr(1));
            setApiReturn("StartVideoDeviceTest  " + r.ToString());
        }
        else if (api.CompareTo("StopVideoDeviceTest") == 0)
        {
            int r = app.videoDeviceManager.StopVideoDeviceTest();
            setApiReturn("StopVideoDeviceTest  " + r.ToString());
        }
        else if (api.CompareTo("GetVideoDeviceCollectionCount") == 0)
        {
            int r = app.videoDeviceManager.GetVideoDeviceCount();
            setApiReturn("GetVideoDeviceCollectionCount  " + r.ToString());
        }
        else if (api.CompareTo("GetVideoDeviceCollectionDevice") == 0)
        {
            int r = app.videoDeviceManager.GetVideoDevice(int.Parse(getApiParam(1)), ref deviceName, ref deviceID);
            setApiReturn("GetVideoDeviceCollectionDevice deviceName = " + deviceName + " ,deviceId  = " + deviceID + r.ToString());
        }
        else if (api.CompareTo("GetCurrentVideoDevice") == 0)
        {
            string deviceId = "";
            int r = app.videoDeviceManager.GetCurrentVideoDevice(ref deviceId);
            setApiReturn("GetCurrentVideoDevice  deviceId = " + deviceId);
        }
        else if (api.CompareTo("SetVideoDeviceCollectionDevice") == 0)
        {
            int r = app.videoDeviceManager.SetVideoDevice(deviceID);
            setApiReturn("SetVideoDeviceCollectionDevice  " + r.ToString());
        }
        else if (api.CompareTo("RegisterMediaMetadataObserver") == 0)
        {
            int r = app.metaDataObserver.RegisterMediaMetadataObserver((METADATA_TYPE)int.Parse(getApiParam(1)));
            setApiReturn("RegisterMediaMetadataObserver  " + r.ToString());
        }
        
        else if (api.CompareTo("UnRegisterMediaMetadataObserver") == 0)
        {
            int r = app.metaDataObserver.UnRegisterMediaMetadataObserver();
            setApiReturn("UnRegisterMediaMetadataObserver  " + r.ToString());
        }
        else if (api.CompareTo("SendMetadata") == 0)
        {
            // string ss= "hello world!";
            // byte[] byteArray = System.Text.Encoding.Default.GetBytes (ss);

            // Metadata metadata = new Metadata();
            // metadata.buffer = byteArray;
            // metadata.size = (uint)byteArray.Length;
            // int r = app.metaDataObserver.SendMetadata(metadata);
           // setApiReturn("SendMetadata  " + r.ToString());
        }
        else if (api.CompareTo("SetMaxMetadataSize") == 0)
        {
            // int r = app.metaDataObserver.SetMaxMetadataSize(1024);
            // setApiReturn("SetMaxMetadataSize  " + r.ToString());
        }
        else if (api.CompareTo("SendAudioPacket") == 0)
        {

        }
        else if (api.CompareTo("SendVideoPacket") == 0)
        {

        }
        else if (api.CompareTo("RegisterPacketObserver") == 0)
        {
            int r = app.packetObserver.RegisterPacketObserver();
            setApiReturn("RegisterPacketObserver  " + r.ToString());
        }
        else if (api.CompareTo("UnRegisterPacketObserver") == 0)
        {
            int r = app.packetObserver.UnRegisterPacketObserver();
            setApiReturn("UnRegisterPacketObserver  " + r.ToString());
        }
        else if (api.CompareTo("RenewToken") == 0)
        {
            int r = app.mRtcEngine.RenewToken(getApiParam(1));
            setApiReturn("RenewToken  " + r.ToString());
        }
        else if (api.CompareTo("Rate") == 0)
        {
            int r = app.mRtcEngine.Rate(getApiParam(1), int.Parse(getApiParam(2)), getApiParam(3));
            setApiReturn("Rate " + r.ToString());
        }
        else if (api.CompareTo("Complain") == 0)
        {
            int r = app.mRtcEngine.Complain(getApiParam(1), getApiParam(2));
            setApiReturn("Complain " + r.ToString());
        }
        else if (api.CompareTo("SetEncryptionMode") == 0)
        {
            int r = app.mRtcEngine.SetEncryptionMode(getApiParam(1));
            setApiReturn("SetEncryptionMode " + r.ToString());
        }
        else if (api.CompareTo("SetEncryptionSecret") == 0)
        {
            int r = app.mRtcEngine.SetEncryptionSecret(getApiParam(1));
            setApiReturn("SetEncryptionSecret  " + r.ToString());
        }
        else if (api.CompareTo("SetVideoQualityParameters") == 0)
        {
            int r = app.mRtcEngine.SetVideoQualityParameters(int.Parse(getApiParam(1)) !=0);
            setApiReturn("SetVideoQualityParameters " + r.ToString());
        }
        else if (api.CompareTo("SetVideoQualityParameters") == 0)
        {
            int r = app.mRtcEngine.SetVideoQualityParameters(int.Parse(getApiParam(1)) !=0);
            setApiReturn("SetVideoQualityParameters " + r.ToString());
        }
         else if (api.CompareTo("PushVideoFrame") == 0)
        {
            VideoFrame videoFrame = new VideoFrame();
            ExternalVideoFrame externalVideo = new ExternalVideoFrame();
            externalVideo.format = ExternalVideoFrame.VIDEO_PIXEL_FORMAT.VIDEO_PIXEL_I420;
            externalVideo.type = ExternalVideoFrame.VIDEO_BUFFER_TYPE.VIDEO_BUFFER_RAW_DATA;
            externalVideo.buffer = new byte[1024];
            
            int r = app.mRtcEngine.PushVideoFrame(externalVideo);
            setApiReturn("SetVideoQualityParameters " + r.ToString());
        }
        else if (api.CompareTo("createEngine") == 0)
        {
            app.loadEngine();
            setApiReturn("createEngine");
        }
        else if (api.CompareTo("destroyEngine") == 0)
        {
            app.unloadEngine();
            setApiReturn("destroyEngine");
        }
        else if (api.CompareTo("SetLogFile") == 0)
        {   
            //string file = createFile();
            app.mRtcEngine.SetLogFile(getApiParam(1));
            setApiReturn("setLogFile  file = " + getApiParam(1));
        }
        else if (api.CompareTo("GetErrorDescription") == 0)
        {
             string rc = IRtcEngine.GetErrorDescription(int.Parse(getApiParam(1)));
             setApiReturn("GetErrorDescription rc = " + rc);

        }
        else
        {
            Debug.Log("onApiButtonClicked: unsupported API!");
        }
    }

    public void onButtonClicked()
    {
        // which GameObject?
        if (name.CompareTo("JoinButton") == 0)
        {
            onJoinButtonClicked();
        }
        else if (name.CompareTo("LeaveButton") == 0)
        {
            onLeaveButtonClicked();
        }
        else if (name.CompareTo("Submit") == 0)
        {
            onApiButtonClicked();
        }
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.CompareTo("Scene1") == 0)
        {
            if (!ReferenceEquals(app, null))
            {
                app.onScene1Loaded(); // call this after scene is loaded
            }
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }
    }

    void OnApplicationPause(bool paused)
	{
		if (paused)
		{
			if(IRtcEngine.QueryEngine() != null)
			{
				IRtcEngine.QueryEngine().DisableVideo();
			}
		}
		else
		{
			if(IRtcEngine.QueryEngine() != null)
			{
				IRtcEngine.QueryEngine().EnableVideo();
			}
		}
	}

    void OnApplicationQuit()
    {
        IRtcEngine.Destroy();
    }
}
