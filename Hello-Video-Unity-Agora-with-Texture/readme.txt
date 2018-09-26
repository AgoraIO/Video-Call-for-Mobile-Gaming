2017/05/12 Fri Zhenyong Chen

How to build for iOS

Config Unity build settings:
Select rendering API: OpenGLES2, remove metal

Fix created iOS project file:
Add libraries to the project:
libresolv.tbd
CoreTelephony.framework
VideoToolbox.framework
libAgoraRTCEngine.a
libmediasdk.a

Enable Bitcode: No

Fix info.plist
Add Privacy - Camera Usage Description
Add Privacy - Microphone Usage Description

Connect your iPhone/iPad to XCode
