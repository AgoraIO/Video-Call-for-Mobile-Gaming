## Hello Video Agora for Unity

**Run Video Chat within Your Unity Application**

(Other languages:[中文](README.zh.md)）



## Prerequisites



-  Unity Editor (2017 LTS or above)

- A [developer account]([https://sso.agora.io/en/signup](https://sso.agora.io/en/signup)) with Agora.io



## Getting Started

You do not need to clone this project in order to try out the demo.  The demo itself is bundled in the Agora Video SDK.  You may download the SDK via one of the follow two methods:



1.  [Asset Store]([https://assetstore.unity.com/packages/tools/video/agora-video-sdk-for-unity-134502](https://assetstore.unity.com/packages/tools/video/agora-video-sdk-for-unity-134502)). After  import the package, you should find the demo under Assets/AgoraEngine/Demo.

2. [Agora Website Download Page.]([https://docs.agora.io/en/Video/downloads?platform=Unity](https://docs.agora.io/en/Video/downloads?platform=Unity)) You will obtain a zip file.  After unzipping, open the project in samples directory.  The Demo is in the location mentioned above.



**To add the SDK from the downloaded zip file to a project**

Unzip the downloaded SDK from Agora website and copy the files from the following SDK folders into the associated Unity application folders.

SDK Folder|Application Folder|
---|---
|libs/Android/|Assets/Plugins/Android/|
|libs/iOS/|Assets/Plugins/iOS/|
|libs/macOS/|Assets/Plugins/macOS/
|libs/x86/|Assets/Plugins/x86/
|libs/x86_64/|Assets/Plugins/x86_64/
|libs/Scripts/AgoraGamingSDK/|Assets/Scripts/AgoraGamingSDK/



***If you download the SDK from Asset Store, then there is no need to do the copying***



### Add Your AppID



Before you can build and run the project, you will need to add your AppID to the configuration. Go to your [developer account’s project console]([https://console.agora.io/projects](https://console.agora.io/projects)), create a new AppId or copy the AppId from an existing project.



Note it is important that for a production ready project, you should always use an AppId with certificate enabled. However, in this simple quick start demo, we will skip this part.  So you AppId should be created for testing mode.
![enter image description here](https://user-images.githubusercontent.com/1261195/110023464-11eb0480-7ce2-11eb-99d6-031af60715ab.png)

### Running the Demo

Perform the following steps:


1.  Open the Assets/Demo/SceneHome scene,

2.  Select the GameController from the Unity Editor’s Hierarchy panel.

3.  The GameController game object has a property App ID, this is where you will add your Agora App ID.

![enter image description here](https://user-images.githubusercontent.com/1261195/113456235-88525380-93c1-11eb-9426-f76f7882cccb.png)
4. Make sure you added SceneHome and SceneHelloVideo to your build settings.
5. Hit run from the Editor or build and run on a device.
6. Optimally you should run two instances of the demo in order to test video chat.
7. Tap "Join" and you should see the next scene similar to this view: 
![Screen Shot 2022-04-28 at 1 47 19 PM](https://user-images.githubusercontent.com/1261195/165843046-1f152c0f-73ac-4a4f-aecc-109d52ee4940.png)







## Some Trouble Shooting FAQs

(Please also read the README file in the SDK..)

**Q:** There are only white cube and box on the demo screen after I join the channel.

**A:** There may be definite reasons for this. First recommendation is implementing the OnError and OnWarning callbacks to check on what errors are occuring. (Added in the Demo starting from v3.2.1.71). Here are the common causes:



1. You registered an AppId with Certificate enabled, but you didn’t include a secure token in your JoinChannel call. => **You should use an AppId without Certificate if you are new to the SDK.** Create a new AppId with Certificate after you tested the POC and feel comfortable to enforce token security.



2. The Application did not acquire the required OS level permission for Camera. => **Make sure you set those up in the PlayerSettings and Manifest if for Android.**



3. The agoraCWrapper library didn’t get loaded on run-time (usually happens on Standalone, not Editor). Make sure you have the correct Platform Settings flag selected, we recommend you to select **AnyCPU**. See examples in MacOS section for building the App above.







**Q:** I press the join button but the scene doesn't change (usually happens on Editor).

**A:** Make sure you have chosen both two scenes in Build Settings.







**Q:** When run the app, a pop-up window said agoraSdkCWrapper.bundle cannot be opened because the developer cannot be verified.(usually happens on MacOS).

**A:** Choose "allow" in Settings/security and privacy, rerun the app.



## Resources



-  Complete API documentation is available at the  [Document Center]([https://docs.agora.io/en/](https://docs.agora.io/en/)).

-  You can file bugs about this sample  [here]([https://github.com/AgoraIO/Hello-Video-Unity-Agora/issues](https://github.com/AgoraIO/Hello-Video-Unity-Agora/issues)).



- For potential SDK issues, take a look at our [FAQ]([https://docs.agora.io/en/faq](https://docs.agora.io/en/faq))  first



- To see more sample Unity projects, see https://github.com/AgoraIO/Agora-Unity-Quickstart



- Repositories managed by developer communities can be found at [Agora Community]([https://github.com/AgoraIO-Community](https://github.com/AgoraIO-Community))









## License



This software is under the MIT License (MIT). [View the license](LICENSE.md).