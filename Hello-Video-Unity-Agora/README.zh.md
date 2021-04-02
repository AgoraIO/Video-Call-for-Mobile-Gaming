
## Hello Video Unity Agora
### 在Unity应用程序中运行视频聊天

Read this in other languages:  [English](README.md)

该演示演示了如何使用Agora IO的Video SDK配置和运行Unity应用程序。该SDK支持Unity上的iOS，Android，MacOS和Windows平台。

## 先决条件

-Unity编辑器（2017年LTS或更高版本）
    
-一个带有Agora.io的[开发者帐户](https://sso.agora.io/cn/v3/signup)
    

## 入门
您无需克隆该项目即可试用该演示。该演示本身捆绑在Agora Video SDK中。您可以通过以下两种方法之一下载SDK：

 1.  [Asset Store](https://assetstore.unity.com/packages/tools/video/agora-video-sdk-for-unity-134502): 导入软件包后，您应该在Assets / AgoraEngine / Demo下找到该演示。
 2. [Agora网站下载页面](https://docs.agora.io/en/Video/downloads?platform=Unity): 您将获得一个zip文件。解压缩后，在samples目录中打开项目。该演示位于上述位置。

## 添加您的AppID

在构建和运行项目之前，您需要将AppID添加到配置中。转到您的 [开发者帐户的项目控制台](https://console.agora.io/projects)，创建一个新的AppId或从现有项目中复制该AppId。

请注意，对于准备投入生产的项目，务必始终使用启用了证书的AppId，这一点很重要。但是，在这个简单的快速入门演示中，我们将跳过这一部分。因此，应为测试模式创建AppId。
![enter image description here](https://user-images.githubusercontent.com/1261195/110023464-11eb0480-7ce2-11eb-99d6-031af60715ab.png)

## 运行演示

执行以下步骤：

1.打开Assets / Demo / SceneHome场景，
2.从Unity编辑器的“层次结构”面板中选择GameController。
3. GameController游戏对象具有属性App ID，您可以在其中添加Agora App ID
![enter image description here](https://user-images.githubusercontent.com/1261195/113456235-88525380-93c1-11eb-9426-f76f7882cccb.png)
 4.确保已将SceneHome和SceneHelloVideo添加到构建设置中。
 5.从“编辑器”中单击“运行”，或者在设备上构建并运行。
 6.最佳地，您应该运行该演示的两个实例以测试视频聊天。
 7.点击“加入”，您应该看到类似于此视图的下一个场景：![enter image description here](https://user-images.githubusercontent.com/1261195/113455947-c602ac80-93c0-11eb-8fb5-275ae2544387.png)


## 资源

  - 完整的API文档可在[文档中心](https://docs.agora.io/cn)获得
  - 您可以在[此处](https://github.com/AgoraIO/Hello-Video-Unity-Agora/issues) 提交有关此示例的错误。
  - 要查看更多示例Unity项目，请参见 https://github.com/AgoraIO/Agora-Unity-Quickstart
  - 由开发人员社区管理的存储库可在[Agora社区](https://github.com/AgoraIO-Community)中找到




## 代码许可

该软件受MIT许可证（MIT）约束。[查看许可](LICENSE.md).
