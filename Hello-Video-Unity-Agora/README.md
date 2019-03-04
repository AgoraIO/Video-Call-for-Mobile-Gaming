# Hello Video Agora for Unity

*Read this in other languages: [中文](README.zh.md)*

This tutorial enables you to quickly get started with using a sample app to develop requests to the Agora Gaming SDK in [Unity 3D](https://unity3d.com).

This sample app demonstrates the basic Agora SDK feature:

- [Join a Channel](#create-the-join-method)
- [Leave a Channel](#create-the-leave-method)


## Prerequisites
- Agora.io Developer Account
- Unity 3D 5.5+


## Quick Start
This section shows you how to prepare and build the Agora React Native wrapper for the sample app.

### Create an Account and Obtain an App ID
To build and run the sample application you must obtain an App ID:

1. Create a developer account at [agora.io](https://dashboard.agora.io/signin/). Once you finish the signup process, you will be redirected to the Dashboard.
2. Navigate in the Dashboard tree on the left to **Projects** > **Project List**.
3. Copy the App ID that you obtained from the Dashboard into a text file. You will use this when you launch the app.

### Update and Run the Sample Application

1. Edit the [`Assets/HelloUnityVideo.cs`](Assets/HelloUnityVideo.cs) file. In the `HelloUnityVideo` class declaration, update `#YOUR APP ID#` with your App ID.

	`private static string appId = #YOUR APP ID#;`

2. Download the [Agora Gaming SDK](https://www.agora.io/en/download/) for Unity 3D.

	![download.jpg](images/download.jpg)

3. Unzip the downloaded SDK package and copy the files from the following SDK folders into the associated sample application folders.

SDK Folder|Application Folder
---|---
`libs/Android/`|`Assets/Plugins/Android/`
`libs/iOS/`|`Assets/Plugins/iOS/`
`libs/Scripts/AgoraGamingSDK/`|`Assets/Scripts/AgoraGamingSDK/`

4. Open the project in Unity and run the sample application.


## Resources
- A detailed code walkthrough for this sample is available in [Steps to Create this Sample](./guide.md).
- Complete API documentation is available at the [Document Center](https://docs.agora.io/en/).
- You can file bugs about this sample [here](https://github.com/AgoraIO/Hello-Video-Unity-Agora/issues).

## License
This software is under the MIT License (MIT). [View the license](LICENSE.md).
