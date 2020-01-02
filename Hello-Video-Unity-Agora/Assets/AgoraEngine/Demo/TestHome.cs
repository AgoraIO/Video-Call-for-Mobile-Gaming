﻿using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

#if(UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
using UnityEngine.Android;
#endif
using agora_gaming_rtc;

/// <summary>
///    TestHome serves a game controller object for this application.
/// </summary>
public class TestHome : MonoBehaviour
{

    // Use this for initialization
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
    private ArrayList permissionList = new ArrayList();
#endif
    static TestHelloUnityVideo app = null;

    private string HomeSceneName = "SceneHome";

    // Scenese to load. The order should match the toggle group in the TestHome scene
    private string[] PlaySceneNames = { "SceneHelloVideo", "SceneARVideoChat", "SceneScreenShare" };

    // PLEASE KEEP THIS App ID IN SAFE PLACE
    // Get your own App ID at https://dashboard.agora.io/
    [SerializeField]
    private string AppID = "your_appid";

    void Awake()
    {
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
		permissionList.Add(Permission.Microphone);         
		permissionList.Add(Permission.Camera);               
#endif

        // keep this alive across scenes
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        CheckAppId();
    }

    void Update()
    {
        CheckPermissions();
    }

    private void CheckAppId()
    {
        Debug.Assert(AppID.Length > 10, "Please fill in your AppId first on Game Controller object.");
        Debug.Log("Version full of the runtime: " + Application.unityVersion);
    }

    /// <summary>
    ///   Checks for platform dependent permissions.
    /// </summary>
    private void CheckPermissions()
    {
#if (UNITY_2018_3_OR_NEWER && UNITY_ANDROID)
        foreach(string permission in permissionList)
        {
            if (!Permission.HasUserAuthorizedPermission(permission))
            {                 
				Permission.RequestUserPermission(permission);
			}
        }
#endif
    }

    public void onJoinButtonClicked()
    {
        // get parameters (channel name, channel profile, etc.)
        GameObject go = GameObject.Find("ChannelName");
        InputField field = go.GetComponent<InputField>();


        int sceneId = GetSceneSelection();
        string PlaySceneName = PlaySceneNames[sceneId];

        // create app if nonexistent
        if (app == null)
        {
            switch (sceneId)
            {
                case 1:
                    // AR Foundation test
                    if (CheckUnityVersionForAR())
                    {
                        Debug.LogWarning("Will run ARFoundation test..");
                        app = new TestARfoundationController();
                    }
                    else
                    {
                        Debug.LogError("ARFoundation is expected to run on Unity Engine 2018 or later.");
                        return;
                    }
                    break;
                case 2:
                    // Screen share test
                    app = new ScreenShareAppController();
                    break;
                default:
                    // Video Chat
                    app = new TestHelloUnityVideo();
                    break;
            }
            app.loadEngine(AppID);
        }
        // join channel and jump to next scene
        app.join(field.text);

        SceneManager.sceneLoaded += OnLevelFinishedLoading; // configure GameObject after scene is loaded
        SceneManager.LoadScene(PlaySceneName, LoadSceneMode.Single);
    }

    public void onLeaveButtonClicked()
    {
        if (!ReferenceEquals(app, null))
        {
            app.leave(); // leave channel
            app.unloadEngine(); // delete engine
            app = null; // delete app
            SceneManager.LoadScene(HomeSceneName, LoadSceneMode.Single);
        }
        Destroy(gameObject);
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (!ReferenceEquals(app, null))
        {
            app.onSceneHelloVideoLoaded(); // call this after scene is loaded
        }
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnApplicationPause(bool paused)
    {
        if (!ReferenceEquals(app, null))
        {
            app.EnableVideo(paused);
        }
    }

    void OnApplicationQuit()
    {
        if (!ReferenceEquals(app, null))
        {
            app.unloadEngine();
        }
    }

    bool CheckUnityVersionForAR()
    {
        string version = Application.unityVersion;
        string first = Application.unityVersion.Split(new char[] { '.' }).FirstOrDefault();
        return (first.CompareTo("2018") >= 0);
    }


    int GetSceneSelection()
    {
        GameObject go = GameObject.Find("SceneToggleGroup");

        Toggle[] toggles = go.GetComponentsInChildren<Toggle>();

        int index = 0;
        while (index < toggles.Count())
        {
            if (toggles[index].isOn)
            {
                return index;
            }
            index++;
        }

        return index;
    }
}