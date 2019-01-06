# Hello Video Unity Agora

*其他语言版本： [简体中文](README.md)*

The Hello Video Unity Agora Sample App is an open-source demo that will help you get video chat integrated directly into your Unity game applications using the Agora Gaming SDK.

With this sample app, you can:

- Join / leave channel

## Running the App
First, create a developer account at [Agora.io](https://dashboard.agora.io/signin/), and obtain an App ID. Update "HelloUnityVideo.cs" with your App ID.

```
private static string appId = #YOUR APP ID#;
```

Next, download the **Agora Gaming SDK** from [Agora.io SDK](https://www.agora.io/en/download/). Unzip the downloaded SDK package and

- copy files from **libs/Android/** in SDK to **Assets/Plugins/Android/AgoraRtcEngineKit.plugin/libs/** in project
- copy files from **libs/iOS/** in SDK to **Assets/Plugins/iOS/** in project
- copy files from **libs/Scripts/AgoraGamingSDK/** in SDK to **Assets/Scripts/AgoraGamingSDK/** in project

Finally, Open project with Unity and run.

## Developer Environment Requirements
* Unity 5.5+

## Connect Us

- You can find full API document at [Document Center](https://docs.agora.io/en/)
- You can file bugs about this demo at [issue](https://github.com/AgoraIO/Video-Call-for-Mobile-Gaming/issues)

## License

The MIT License (MIT).
