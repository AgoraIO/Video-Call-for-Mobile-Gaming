using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		exampleApp.logD ("ButtonClick Start is called!");
		GameObject go = GameObject.Find ("ApiList");
		Dropdown dd = go.GetComponent<Dropdown> ();
		dd.ClearOptions ();
		List<string> options = new List<string>();
		options.Add ("GetSdkVersion");
		options.Add ("SetChannelProfile");
		options.Add ("SetClientRole");
		options.Add ("Pause");
		options.Add ("Resume");
		options.Add ("GetCallId");
		options.Add ("SwitchCamera");
		options.Add ("SetVideoProfile");
		options.Add ("MuteLocalVideoStream");
		options.Add ("MuteAllRemoteVideoStreams");
		options.Add ("MuteRemoteVideoStream");
		options.Add ("EnableDualStreamMode");
		options.Add ("SetRemoteVideoStreamType");
		options.Add ("EnableVideo");
		options.Add ("DisableVideo");
		options.Add ("EnableLocalVideo");
		options.Add ("StartPreview");
		options.Add ("StopPreview");
		dd.AddOptions(options);

		go = GameObject.Find ("VIDEOPROFILE");
		dd = go.GetComponent<Dropdown> ();
		dd.ClearOptions ();
		options = new List<string>();
		options.Add ("-1 Invalid");
		options.Add ("0 120P true (160x120)");
		options.Add ("0 120P false (160x120)");
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
		options.Add ("20 240P true (320x240)");
		options.Add ("20 240P false (320x240)");
		#if UNITY_IPHONE
		options.Add ("22 240P_3 true (240x240)");
		options.Add ("22 240P_3 false (240x240)");
		options.Add ("23 240P_4 true (420x240)");
		options.Add ("23 240P_4 false (420x240)");
		#endif
		options.Add ("30 360P true (640x360)");
		options.Add ("30 360P false (640x360)");
		#if UNITY_IPHONE
		options.Add ("32 360P_3 true (360x360)");
		options.Add ("32 360P_3 false (360x360)");
		#endif
		options.Add ("33 360P_4 true (640x360)");
		options.Add ("33 360P_4 false (640x360)");
		options.Add ("35 360P_6 true (360x360)");
		options.Add ("35 360P_6 false (360x360)");
		options.Add ("36 360P_7 true (480x360)");
		options.Add ("36 360P_7 false (480x360)");
		options.Add ("37 360P_8 true (480x360)");
		options.Add ("37 360P_8 false (480x360)");
		options.Add ("38 360P_9 true (640x360)");
		options.Add ("38 360P_9 false (640x360)");
		options.Add ("39 360P_10 true (640x360)");
		options.Add ("39 360P_10 false (640x360)");
		options.Add ("100 360P_11 true (640x360)");
		options.Add ("100 360P_11 false (640x360)");
		options.Add ("40 480P true (640x480)");
		options.Add ("40 480P false (640x480)");
		#if UNITY_IPHONE
		options.Add ("42 480P_3 true (480x480)");
		options.Add ("42 480P_3 false (480x480)");
		#endif
		options.Add ("43 480P_4 true (640x480)");
		options.Add ("43 480P_4 false (640x480)");
		options.Add ("45 480P_6 true (480x480)");
		options.Add ("45 480P_6 false (480x480)");
		options.Add ("47 480P_8 true (840x480)");
		options.Add ("47 480P_8 false (840x480)");
		options.Add ("48 480P_9 true (840x480)");
		options.Add ("48 480P_9 false (840x480)");
		options.Add ("49 480P_10 true (640x480)");
		options.Add ("49 480P_10 false (640x480)");
		options.Add ("50 720P true (1280x720)");
		options.Add ("50 720P false (1280x720)");
		options.Add ("52 720P_3 true (1280x720)");
		options.Add ("52 720P_3 false (1280x720)");
		options.Add ("54 720P_5 true (960x720)");
		options.Add ("54 720P_5 false (960x720)");
		options.Add ("55 720P_6 true (960x720)");
		options.Add ("55 720P_6 false (960x720)");


		dd.AddOptions(options);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static exampleApp app = null;

	private void onJoinButtonClicked() {
		// get parameters (channel name, channel profile, etc.)
		GameObject go = GameObject.Find ("ChannelName");
		InputField field = go.GetComponent<InputField>();

		// create app if nonexistent
		if (ReferenceEquals (app, null)) {
			app = new exampleApp (); // create app
			exampleApp.logD("zhangagora " + app);
			app.loadEngine (); // load engine
		}

		// join channel and jump to next scene
		app.join (field.text);
		SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
		SceneManager.LoadScene ("Scene1", LoadSceneMode.Single);
	}

	private void onLeaveButtonClicked() {
		if (!ReferenceEquals (app, null)) {
			app.leave (); // leave channel
			app.unloadEngine (); // delete engine
			app = null; // delete app
			SceneManager.LoadScene ("Scene0", LoadSceneMode.Single);
		}
	}

	private void setApiParam(int param, string txt) {
		string name;
		switch (param) {
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

		GameObject go = GameObject.Find (name);
		InputField field = go.GetComponent<InputField>();
		field.text = txt;
	}

	private string getApiParam(int param) {
		string name;
		switch (param) {
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

		GameObject go = GameObject.Find (name);
		InputField field = go.GetComponent<InputField>();
		string value = field.text;

		return value;
	}

	private int getApiParamInt(int param) {
		string sValue = getApiParam (param);
		return int.Parse (sValue);
	}

	private void setApiReturn(string v) {
		GameObject go = GameObject.Find ("FieldResult");
		InputField field = go.GetComponent<InputField>();
		field.text = v;
	}

	private void onApiButtonClicked() {
		GameObject go = GameObject.Find ("ApiList");
		Dropdown dd = go.GetComponent<Dropdown> ();
		string api = dd.captionText.text;
		Debug.Log ("onApiButtonClicked: " + api);

		if (ReferenceEquals (app, null)) {
			app = new exampleApp ();
			app.loadEngine ();
		}

		// these APIs do not require engine being created
		if (api.CompareTo ("GetSdkVersion") == 0) {
			string ret = agora_gaming_rtc.IRtcEngine.GetSdkVersion ();
			setApiReturn (ret);
			return;
		}

		if (api.CompareTo ("SetChannelProfile") == 0) {
			int num = getApiParamInt (1);

			agora_gaming_rtc.CHANNEL_PROFILE chProfile;
			switch (num) {
			case 2:
				chProfile = agora_gaming_rtc.CHANNEL_PROFILE.GAME_FREE_MODE;
				break;
			case 3:
			default:
				chProfile = agora_gaming_rtc.CHANNEL_PROFILE.GAME_COMMAND_MODE;
				break;
			}

			int r = app.mRtcEngine.SetChannelProfile (chProfile);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("SetClientRole") == 0) {
			int num = getApiParamInt (1);

			agora_gaming_rtc.CLIENT_ROLE role;
			switch (num) {
			case 1:
				role = agora_gaming_rtc.CLIENT_ROLE.BROADCASTER;
				break;
			case 2:
			default:
				role = agora_gaming_rtc.CLIENT_ROLE.AUDIENCE;
				break;
			}

			int r = app.mRtcEngine.SetClientRole (role);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("Pause") == 0) {
			app.mRtcEngine.Pause ();
		} else if (api.CompareTo ("Resume") == 0) {
			app.mRtcEngine.Resume ();
		} else if (api.CompareTo ("GetCallId") == 0) {
			string ret = app.mRtcEngine.GetCallId ();
			setApiReturn (ret);
		} else if (api.CompareTo ("SwitchCamera") == 0) {
			int r = app.mRtcEngine.SwitchCamera ();
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("SetVideoProfile") == 0) {
			GameObject go1 = GameObject.Find ("VIDEOPROFILE");
			Dropdown dd1 = go1.GetComponent<Dropdown> ();
			string s = dd1.captionText.text;
			Debug.Log ("VideoProfile: " + s);
			string[] sArray = s.Split (' ');

			int profile = int.Parse (sArray [0]);//getApiParamInt (1);
			int swap = sArray[2].CompareTo("true") == 0 ? 1 : 0;//getApiParamInt (2);

			int r = app.mRtcEngine.SetVideoProfile (profile, (swap != 0));
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("MuteLocalVideoStream") == 0) {
			int mute = getApiParamInt (1);

			int r = app.mRtcEngine.MuteLocalVideoStream (mute != 0);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("MuteAllRemoteVideoStreams") == 0) {
			int mute = getApiParamInt (1);

			int r = app.mRtcEngine.MuteAllRemoteVideoStreams (mute != 0);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("MuteRemoteVideoStream") == 0) {
			// auto fill in
			setApiParam(1, app.mRemotePeer.ToString());

			uint uid = app.mRemotePeer;// getApiParamInt (1);
			int mute = getApiParamInt (2);

			int r = app.mRtcEngine.MuteRemoteVideoStream (uid, (mute != 0));
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("EnableDualStreamMode") == 0) {
			int enabled = getApiParamInt (1);

			int r = app.mRtcEngine.EnableDualStreamMode (enabled != 0);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("SetRemoteVideoStreamType") == 0) {
			int uid = getApiParamInt (1);
			int streamType = getApiParamInt (2);

			int r = app.mRtcEngine.SetRemoteVideoStreamType ((uint)uid, streamType);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("EnableVideo") == 0) {
			int r = app.mRtcEngine.EnableVideo ();
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("DisableVideo") == 0) {
			int r = app.mRtcEngine.DisableVideo ();
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("EnableLocalVideo") == 0) {
			int enabled = getApiParamInt (1);

			int r = app.mRtcEngine.EnableLocalVideo (enabled != 0);
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("StartPreview") == 0) {
			int r = app.mRtcEngine.StartPreview ();
			setApiReturn (r.ToString ());
		} else if (api.CompareTo ("StopPreview") == 0) {
			int r = app.mRtcEngine.StopPreview ();
			setApiReturn (r.ToString ());
		}
		else {
			Debug.Log ("onApiButtonClicked: unsupported API!");
		}
	}

	public void onButtonClicked() {
		// which GameObject?
		if (name.CompareTo ("JoinButton") == 0) {
			onJoinButtonClicked ();
		}
		else if(name.CompareTo ("LeaveButton") == 0) {
			onLeaveButtonClicked ();
		}
		else if(name.CompareTo ("Submit") == 0) {
			onApiButtonClicked ();
		}
	}

	public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if (scene.name.CompareTo("Scene1") == 0) {
			if (!ReferenceEquals (app, null)) {
				app.onScene1Loaded (); // call this after scene is loaded
			}
			SceneManager.sceneLoaded -= OnLevelFinishedLoading;
		}
	}
}
