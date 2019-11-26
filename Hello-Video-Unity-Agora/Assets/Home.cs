using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
#if(UNITY_2018_3_OR_NEWER)
using UnityEngine.Android;
#endif

public class Home : MonoBehaviour {

 	private ArrayList permissionList = new ArrayList();
	void Start ()
	{         
		#if(UNITY_2018_3_OR_NEWER)
		permissionList.Add(Permission.Microphone);         
		permissionList.Add(Permission.Camera);               
		#endif     
	}
	
    private void CheckPermission()
    {
        #if(UNITY_2018_3_OR_NEWER)
        foreach(string permission in permissionList)
        {
            if (Permission.HasUserAuthorizedPermission(permission))
            {             

			}
            else
            {                 
				Permission.RequestUserPermission(permission);
			}
        }
        #endif
    }

    // Update is called once per frame
    void Update ()
	{         
		#if(UNITY_2018_3_OR_NEWER)
		CheckPermission();
		#endif     
	}

	static HelloUnityVideo app = null;

	private void onJoinButtonClicked() {
		// get parameters (channel name, channel profile, etc.)
		GameObject go = GameObject.Find ("ChannelName");
		InputField field = go.GetComponent<InputField>();

		// create app if nonexistent
		if (ReferenceEquals (app, null)) {
			app = new HelloUnityVideo (); // create app
			app.loadEngine (); // load engine
		}

		// join channel and jump to next scene
		app.join (field.text);
		SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
		SceneManager.LoadScene ("SceneHelloVideo", LoadSceneMode.Single);
	}

	private void onLeaveButtonClicked() {
		if (!ReferenceEquals (app, null)) {
			app.leave (); // leave channel
			app.unloadEngine (); // delete engine
			app = null; // delete app
			SceneManager.LoadScene ("SceneHome", LoadSceneMode.Single);
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
	}

	public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if (scene.name.CompareTo("SceneHelloVideo") == 0) {
			if (!ReferenceEquals (app, null)) {
				app.onSceneHelloVideoLoaded (); // call this after scene is loaded
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
		if(IRtcEngine.QueryEngine() != null)
		{
		 	IRtcEngine.Destroy();
		 }
	}
}
