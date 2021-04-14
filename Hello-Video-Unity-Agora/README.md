## Hello Video Agora for Unity
 **Run Video Chat within Your Unity Application**
(Other languages:[中文](README.zh.md)）

## Prerequisites

-   Unity Editor (2017 LTS or above)
    
-   A [developer account](https://sso.agora.io/en/signup) with Agora.io
    

## Getting Started
You do not need to clone this project in order to try out the demo.  The demo itself is bundled in the Agora Video SDK.  You may download the SDK via one of the follow two methods:

 1. [Asset Store](https://assetstore.unity.com/packages/tools/video/agora-video-sdk-for-unity-134502).  After import the package, you should find the demo under Assets/AgoraEngine/Demo.
 2. [Agora Website Download Page.](https://docs.agora.io/en/Video/downloads?platform=Unity) You will obtain a zip file.  After unzipping, open the project in samples directory.  The Demo is in the location mentioned above.

**TO add the SDK from the downloaded zip file to a project**
 Unzip the downloaded SDK from Agora website and copy the files from the following SDK folders into the associated Unity application folders.

SDK Folder|Application Folder
---|---
libs/Android/|Assets/Plugins/Android/
libs/iOS/|Assets/Plugins/iOS/
libs/macOS/|Assets/Plugins/macOS/
libs/x86/|Assets/Plugins/x86/
libs/x86_64/|Assets/Plugins/x86_64/
libs/Scripts/AgoraGamingSDK/|Assets/Scripts/AgoraGamingSDK/

*If you download the SDK from Asset Store, then there is no need to do the copying*

### Add Your AppID

Before you can build and run the project, you will need to add your AppID to the configuration. Go to your [developer account’s project console](https://console.agora.io/projects), create a new AppId or copy the AppId from an existing project. 

Note it is important that for a production ready project, you should always use an AppId with certificate enabled.  However, in this simple quick start demo, we will skip this part.  So you AppId should be created for testing mode.
![enter image description here](https://user-images.githubusercontent.com/1261195/110023464-11eb0480-7ce2-11eb-99d6-031af60715ab.png)

### Running the Demo


Perform the following steps:

1.  Open the Assets/Demo/SceneHome scene,
2.  Select the GameController from the Unity Editor’s Hierarchy panel.   
3.  The GameController game object has a property App ID, this is where you will add your Agora App ID.
![HomeScene](https://user-images.githubusercontent.com/1261195/113456235-88525380-93c1-11eb-9426-f76f7882cccb.png)   
 4. Make sure you added SceneHome and SceneHelloVideo to your build settings.
 5. Hit run from the Editor or build and run on a device.
 6. Optimally you should run two instances of the demo in order to test video chat.
 7. Tap "Join" and you should see the next scene similar to this view: ![HelloVideoScene](https://user-images.githubusercontent.com/1261195/113455947-c602ac80-93c0-11eb-8fb5-275ae2544387.png)


## [](https://github.com/AgoraIO-Community/Unity-RTM#resources)Resources

  -   Complete API documentation is available at the  [Document Center](https://docs.agora.io/en/).
-   You can file bugs about this sample  [here](https://github.com/AgoraIO/Hello-Video-Unity-Agora/issues).

- For potential SDK issues, take a look at our  [FAQ](https://docs.agora.io/en/faq)  first

- To see more sample Unity projects, see https://github.com/AgoraIO/Agora-Unity-Quickstart

- Repositories managed by developer communities can be found at  [Agora Community](https://github.com/AgoraIO-Community)




## License

This software is under the MIT License (MIT). [View the license](LICENSE.md).

