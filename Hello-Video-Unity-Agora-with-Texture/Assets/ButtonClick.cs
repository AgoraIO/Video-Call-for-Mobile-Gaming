using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        exampleApp.logD("ButtonClick Start is called!");
        GameObject go = GameObject.Find("ApiList");
        Dropdown dd = go.GetComponent<Dropdown>();
        dd.ClearOptions();
        List<string> options = new List<string>();
        options.Add("GetSdkVersion");
        options.Add("SetClientRole");
        options.Add("Pause");
        options.Add("Resume");
        options.Add("SetDefaultMuteAllRemoteAudioStreams");
        options.Add("EnableLocalAudio");
        options.Add("SetEnableSpeakerPhone");
        options.Add("IsSpeakerPhoneEnabled");
        options.Add("SetDefaultAudioRouteToSpeakerphone");
        options.Add("EnableAudioVolumeIndication");
        options.Add("MuteLocalAudioStream");
        options.Add("MuteAllRemoteAudioStreams");
        options.Add("MuteRemoteAudioStream");
        options.Add("EnableAudio");
        options.Add("DisableAudio");
        dd.AddOptions(options);
    }

    // Update is called once per frame
    void Update()
    {

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
            exampleApp.logD("zhangagora " + app);
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
            app.unloadEngine(); // delete engine
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
        app.mRtcEngine.SetParameters("{\"rtc.log_filter\": 65535}");
        // these APIs do not require engine being created
        if (api.CompareTo("GetSdkVersion") == 0)
        {
            string ret = agora_gaming_rtc.IRtcEngine.GetSdkVersion();
            setApiReturn(ret);
            return;
        }

        if (api.CompareTo("SetClientRole") == 0)
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
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("Pause") == 0)
        {
            app.mRtcEngine.Pause();
        }
        else if (api.CompareTo("Resume") == 0)
        {
            app.mRtcEngine.Resume();
        }
        else if (api.CompareTo("SetDefaultAudioRouteToSpeakerphone") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            Debug.Log("SetDefaultAudioRouteToSpeakerphone  enabled = " + (enabled != 0));
            int r = app.mRtcEngine.SetDefaultAudioRouteToSpeakerphone(enabled != 0);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("EnableAudioVolumeIndication") == 0)
        {
            int interval = int.Parse(getApiParam(1));
            int smooth = int.Parse(getApiParam(2));
            int r = app.mRtcEngine.EnableAudioVolumeIndication(interval, smooth);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("MuteLocalAudioStream") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.MuteLocalAudioStream(enabled != 0);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("MuteAllRemoteAudioStreams") == 0)
        {
            int enabled = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.MuteAllRemoteAudioStreams(enabled != 0);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("MuteRemoteAudioStream") == 0)
        {
            int muted = int.Parse(getApiParam(2));
            int r = app.mRtcEngine.MuteRemoteAudioStream(app.mRemotePeer, muted != 0);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("SetDefaultMuteAllRemoteAudioStreams") == 0)
        {
            int volume = int.Parse(getApiParam(1));
            int r = app.mRtcEngine.SetDefaultMuteAllRemoteAudioStreams(volume != 0);
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("EnableAudio") == 0)
        {
            int r = app.mRtcEngine.EnableAudio();
            setApiReturn(r.ToString());
        }
        else if (api.CompareTo("DisableAudio") == 0)
        {
            int r = app.mRtcEngine.DisableAudio();
            setApiReturn(r.ToString());
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
}
