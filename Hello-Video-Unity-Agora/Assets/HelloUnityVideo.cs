using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using UnityEngine.UI;

// this is an example of using Agora Unity SDK
// It demonstrates:
// How to enable video
// How to join/leave channel
// 
public class HelloUnityVideo : MonoBehaviour {

	// PLEASE KEEP THIS App ID IN SAFE PLACE
	// Get your own App ID at https://dashboard.agora.io/
	// After you entered the App ID, remove ## outside of Your App ID
	private static string appId = #YOUR APP ID#;

	// load agora engine
	public void loadEngine()
	{
		// start sdk
		Debug.Log ("initializeEngine");

		if (mRtcEngine != null) {
			Debug.Log ("Engine exists. Please unload it first!");
			return;
		}

		// init engine
		mRtcEngine = IRtcEngine.getEngine (appId);

		// enable log
		mRtcEngine.SetLogFilter (LOG_FILTER.DEBUG | LOG_FILTER.INFO | LOG_FILTER.WARNING | LOG_FILTER.ERROR | LOG_FILTER.CRITICAL);
	}

	public void join(string channel)
	{
		Debug.Log ("calling join (channel = " + channel + ")");

		if (mRtcEngine == null)
			return;

		// set callbacks (optional)
		mRtcEngine.OnJoinChannelSuccess = onJoinChannelSuccess;
		mRtcEngine.OnUserJoined = onUserJoined;
		mRtcEngine.OnUserOffline = onUserOffline;

		// enable video
		mRtcEngine.EnableVideo();

		// allow camera output callback
		mRtcEngine.EnableVideoObserver();

		// join channel
		mRtcEngine.JoinChannel(channel, null, 0);

		Debug.Log ("initializeEngine done");
	}

	public string getSdkVersion () {
		return IRtcEngine.GetSdkVersion ();
	}

	public void leave()
	{
		Debug.Log ("calling leave");

		if (mRtcEngine == null)
			return;

		// leave channel
		mRtcEngine.LeaveChannel();
		// deregister video frame observers in native-c code
		mRtcEngine.DisableVideoObserver();
	}

	// unload agora engine
	public void unloadEngine()
	{
		Debug.Log ("calling unloadEngine");

		// delete
		if (mRtcEngine != null) {
			IRtcEngine.Destroy ();
			mRtcEngine = null;
		}
	}

	// accessing GameObject in Scnene1
	// set video transform delegate for statically created GameObject
	public void onSceneHelloVideoLoaded()
	{
		GameObject go = GameObject.Find ("Cylinder");
		if (ReferenceEquals (go, null)) {
			Debug.Log ("BBBB: failed to find Cylinder");
			return;
		}
		VideoSurface o = go.GetComponent<VideoSurface> ();
		o.mAdjustTransfrom += onTransformDelegate;
	}

	// instance of agora engine
	public IRtcEngine mRtcEngine;

	// implement engine callbacks

	public uint mRemotePeer = 0; // insignificant. only record one peer

	private void onJoinChannelSuccess (string channelName, uint uid, int elapsed)
	{
		Debug.Log ("JoinChannelSuccessHandler: uid = " + uid);
		GameObject textVersionGameObject = GameObject.Find ("VersionText");
		textVersionGameObject.GetComponent<Text> ().text = "Version : " + getSdkVersion ();
	}

	// When a remote user joined, this delegate will be called. Typically
	// create a GameObject to render video on it
	private void onUserJoined(uint uid, int elapsed)
	{
		Debug.Log ("onUserJoined: uid = " + uid);
		// this is called in main thread

		// find a game object to render video stream from 'uid'
		GameObject go = GameObject.Find (uid.ToString ());
		if (!ReferenceEquals (go, null)) {
			return; // reuse
		}

		// create a GameObject and assigne to this new user
		go = GameObject.CreatePrimitive (PrimitiveType.Plane);
		if (!ReferenceEquals (go, null)) {
			go.name = uid.ToString ();

			// configure videoSurface
			VideoSurface o = go.AddComponent<VideoSurface> ();
			o.SetForUser (uid);
			o.mAdjustTransfrom += onTransformDelegate;
			o.SetEnable (true);
			o.transform.Rotate (-90.0f, 0.0f, 0.0f);
			float r = Random.Range (-5.0f, 5.0f);
			o.transform.position = new Vector3 (0f, r, 0f);
			o.transform.localScale = new Vector3 (0.5f, 0.5f, 1.0f);
		}

		mRemotePeer = uid;
	}

	// When remote user is offline, this delegate will be called. Typically
	// delete the GameObject for this user
	private void onUserOffline(uint uid, USER_OFFLINE_REASON reason)
	{
		// remove video stream
		Debug.Log ("onUserOffline: uid = " + uid);
		// this is called in main thread
		GameObject go = GameObject.Find (uid.ToString());
		if (!ReferenceEquals (go, null)) {
			Destroy (go);
		}
	}

	// delegate: adjust transfrom for game object 'objName' connected with user 'uid'
	// you could save information for 'uid' (e.g. which GameObject is attached)
	private void onTransformDelegate (uint uid, string objName, ref Transform transform)
	{
		if (uid == 0) {
			transform.position = new Vector3 (0f, 2f, 0f);
			transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
			transform.Rotate (0f, 1f, 0f);
		} else {
			transform.Rotate (0.0f, 1.0f, 0.0f);
		}
	}
}
