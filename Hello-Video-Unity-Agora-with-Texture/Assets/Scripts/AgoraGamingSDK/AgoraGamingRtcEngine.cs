using UnityEngine;
using System;
using System.Globalization;
using System.Runtime.InteropServices;

/* class IRtcEngine provides c# API for Unity 3D
 * app. Use IRtcEngine to access underlying Agora
 * sdk.
 * 
 * Agora sdk only supports single instance by now. So here
 * provides GetEngine() and Destroy() to create/delete the
 * only instance.
 */

namespace agora_gaming_rtc
{
	#region Some types
	public struct RtcStats
	{
		public uint duration;
		public uint txBytes;
		public uint rxBytes;
		public ushort txKBitRate;
		public ushort rxKBitRate;
		public ushort txAudioKBitRate;
		public ushort rxAudioKBitRate;
		public uint lastmileQuality;
		public uint users;
		public double cpuAppUsage;
		public double cpuTotalUsage;
	};

	public enum USER_OFFLINE_REASON
	{
		QUIT = 0,
		DROPPED = 1,
		BECOME_AUDIENCE = 2,
	};

	public struct AudioVolumeInfo
	{
		public uint uid;
		public uint volume; // [0, 255]
	};

	public enum LOG_FILTER
	{
		OFF = 0,
		DEBUG = 0x80f,
		INFO = 0x0f,
		WARNING = 0x0e,
		ERROR = 0x0c,
		CRITICAL = 0x08,
	};

	public enum CHANNEL_PROFILE
	{
		COMMU_MODE = 0, // communication mode, unused for gaming
		LIVE_MODE = 1, // live broadcasting mode, unused for gaming
		GAME_FREE_MODE = 2,
		GAME_COMMAND_MODE = 3,
	};

	public enum CLIENT_ROLE
	{
		BROADCASTER = 1,
		AUDIENCE = 2,
	};

	public enum AUDIO_RECORDING_QUALITY_TYPE
	{
		AUDIO_RECORDING_QUALITY_LOW = 0,
		AUDIO_RECORDING_QUALITY_MEDIUM = 1,
		AUDIO_RECORDING_QUALITY_HIGH = 2,
	};

	public enum AUDIO_ROUTE
	{
		DEFAULT = -1,
		HEADSET = 0,
		EARPIECE = 1,
		SPEAKERPHONE = 3,
		BLUETOOTH = 5,
	};

	#endregion // Some types

	public class IRtcEngine
	{
		#region DllImport
		#if UNITY_STANDALONE_WIN || UNITY_EDITOR
		public const string MyLibName = "agoraSdkCWrapper";
		#else
		#if UNITY_IPHONE
		public const string MyLibName = "__Internal";
		#else
		public const string MyLibName = "agoraSdkCWrapper";
		#endif
		#endif

		// standard sdk api
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern void createEngine(string appId);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern void deleteEngine();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern IntPtr getSdkVersion(); // no need to free the returned char *
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern IntPtr getMediaEngineVersion(); // no need to free the returned char *
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int joinChannel(string channelKey, string channelName, string info, uint uid);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setLocalVoicePitch(double pitch);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setRemoteVoicePosition(uint uid, double pan, double gain);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setVoiceOnlyMode(bool enable);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int leaveChannel();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableLastmileTest();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int disableLastmileTest();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableVideo();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int disableVideo();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableLocalVideo(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int startPreview();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int stopPreview();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableAudio();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int disableAudio();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setParameters(string options);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern IntPtr getParameter(string parameter, string args); // caller free the returned char * (through freeObject)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern IntPtr getCallId(); // caller free the returned char * (through freeObject)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int rate(string callId, int rating, string desc);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int complain(string callId, string desc);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setEnableSpeakerphone(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int isSpeakerphoneEnabled();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int setDefaultAudioRoutetoSpeakerphone(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableAudioVolumeIndication(int interval, int smooth);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int startAudioRecording(string filePath, int quality);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int stopAudioRecording();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int startAudioMixing(string filePath, int loopBack, int replace, int cycle, int playTime);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int stopAudioMixing();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int pauseAudioMixing();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int resumeAudioMixing();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int adjustAudioMixingVolume(int volume);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int getAudioMixingDuration();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int getAudioMixingCurrentPosition();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int muteLocalAudioStream(int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int muteAllRemoteAudioStreams(int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int muteRemoteAudioStream(int uid, int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int switchCamera();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setVideoProfile(int profile, int swapWidthAndHeight);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int muteLocalVideoStream(int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int muteAllRemoteVideoStreams(int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int muteRemoteVideoStream(int uid, int mute);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setLogFile(string filePath);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int renewChannelKey(string channelKey);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setChannelProfile(int profile);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setClientRole(int role);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int enableDualStreamMode(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setEncryptionMode(string encryptionMode);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setEncryptionSecret(string secret);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int startRecordingService(string recordingKey);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int stopRecordingService(string recordingKey);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int refreshRecordingServiceStatus();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int createDataStream(int reliable, int ordered);
		// TODO! supports general data later. now only string is supported
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int sendStreamMessage(int streamId, string data);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setRecordingAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setPlaybackAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setSpeakerphoneVolume(int volume);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int adjustRecordingSignalVolume(int volume);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int adjustPlaybackSignalVolume(int volume);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setHighQualityAudioParametersWithFullband(int fullband, int stereo, int fullBitrate);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int enableInEarMonitoring(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int enableWebSdkInteroperability(int enabled);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setVideoQualityParameters(int preferFrameRateOverImageQuality);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int startEchoTest();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int stopEchoTest();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setRemoteVideoStreamType(int uid, int streamType);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setMixedAudioFrameParameters(int sampleRate, int samplesPerCall);
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setAudioMixingPosition(int pos);
        // setLogFilter: deprecated
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern  int setLogFilter(uint filter);


		// video texture stuff (extension for gaming)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int enableVideoObserver();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int disableVideoObserver();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int generateNativeTexture();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int updateTexture(int tex, uint uid); // return value: -1 for no update; otherwise (width << 16 | height)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern void deleteTexture(int tex);

		// message stuff (extension for gaming)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern int getMessageCount();
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern IntPtr getMessage(); // caller free the returned char * (through freeObject)
		[DllImport (MyLibName, CharSet = CharSet.Ansi)]
		private static extern void freeObject(IntPtr obj);
		#endregion // DllImport

		#region engine callbacks
		//------------------------------------------------------------------------------------------
		// define callbacks
		//------------------------------------------------------------------------------------------
		public delegate void JoinChannelSuccessHandler (string channelName, uint uid, int elapsed);
		public JoinChannelSuccessHandler OnJoinChannelSuccess;

		public delegate void ReJoinChannelSuccessHandler (string channelName, uint uid, int elapsed);
		public ReJoinChannelSuccessHandler OnReJoinChannelSuccess;

		public delegate void ConnectionLostHandler ();
		public ConnectionLostHandler OnConnectionLost;

		public delegate void ConnectionInterruptedHandler ();
		public ConnectionInterruptedHandler OnConnectionInterrupted;

		public delegate void RequestChannelKeyHandler ();
		public RequestChannelKeyHandler OnRequestChannelKey;

		public delegate void UserJoinedHandler (uint uid, int elapsed);
		public UserJoinedHandler OnUserJoined;


		public delegate void UserOfflineHandler (uint uid, USER_OFFLINE_REASON reason);
		public UserOfflineHandler OnUserOffline;

		public delegate void LeaveChannelHandler (RtcStats stats);
		public LeaveChannelHandler OnLeaveChannel;

		public delegate void VolumeIndicationHandler (AudioVolumeInfo[] speakers, int speakerNumber, int totalVolume);
		public VolumeIndicationHandler OnVolumeIndication;

		public delegate void UserMutedHandler (uint uid, bool muted);
		public UserMutedHandler OnUserMuted;

		public delegate void SDKWarningHandler (int warn, string msg);
		public SDKWarningHandler OnWarning;

		public delegate void SDKErrorHandler (int error, string msg);
		public SDKErrorHandler OnError;

		public delegate void RtcStatsHandler (RtcStats stats);
		public RtcStatsHandler OnRtcStats;

		public delegate void AudioMixingFinishedHandler ();
		public AudioMixingFinishedHandler OnAudioMixingFinished;

		public delegate void AudioRouteChangedHandler (AUDIO_ROUTE route);
		public AudioRouteChangedHandler OnAudioRouteChanged;

		public delegate void OnFirstRemoteVideoDecodedHandler (uint uid, int width, int height, int elapsed);
		public OnFirstRemoteVideoDecodedHandler OnFirstRemoteVideoDecoded;

		public delegate void OnVideoSizeChangedHandler (uint uid, int width, int height, int elapsed);
		public OnVideoSizeChangedHandler OnVideoSizeChanged;

		public delegate void OnClientRoleChangedHandler (int oldRole, int newRole);
		public OnClientRoleChangedHandler OnClientRoleChanged;

		public delegate void OnUserMuteVideoHandler (uint uid, bool muted);
		public OnUserMuteVideoHandler OnUserMuteVideo;
		#endregion // engine callbacks

		private readonly AudioEffectManagerImpl mAudioEffectM;

		private IRtcEngine(string appId)
		{
			createEngine (appId);
			mAudioEffectM = new AudioEffectManagerImpl (this);
		}

		public string doFormat (string format, params object[] args)
		{
			return string.Format (CultureInfo.InvariantCulture, format, args);
		}

		/**
		 * get the version information of the SDK
		 *
		 * @return return the version string
		 */
		public static string GetSdkVersion ()
		{
			return Marshal.PtrToStringAnsi (getSdkVersion ());
		}

        public static string GetMediaEngineVersion ()
        {
			return Marshal.PtrToStringAnsi (getMediaEngineVersion ());
        }

		/**
		 * get the error description from SDK (deprecated)
		 * @param [in] code
		 *        the error code
		 * @return return the error description string
		 */
		public static string GetErrorDescription (int code)
		{
			return "Unknown";
		}

		/**
		 * Set the channel profile: such as game free mode, game command mode
		 *
		 * @param profile the channel profile
		 * @return return 0 if success or an error code
		 */
		public int SetChannelProfile(CHANNEL_PROFILE profile)
		{
			return setChannelProfile ((int)profile);
		}

		/**
		 * Set the role of user: such as broadcaster, audience
		 *
		 * @param role the role of client
		 * @param permissionKey the permission key to apply the role
		 * @return return 0 if success or an error code
		 */
		public int SetClientRole(CLIENT_ROLE role)
		{
			return setClientRole ((int)role);
		}

		/**
		 * set the log information filter level
		 *
		 * @param [in] filter
		 *        the filter level
		 * @return return 0 if success or an error code
		 */
		public int SetLogFilter (LOG_FILTER filter)
		{
			string parameters = doFormat ("{{\"rtc.log_filter\": {0}}}", filter);
			return setParameters (parameters);
		}


		// about audio effects: use c interface instead of interface IAudioEffectManager


		/**
		 * set path to save the log file
		 *
		 * @param [in] filePath
		 *        the .log file path you want to saved
		 * @return return 0 if success or an error code
		 */
		public int SetLogFile (string filePath)
		{
			string parameters = doFormat ("{{\"rtc.log_file\": \"{0}\"}}", filePath);
			return setParameters (parameters);
		}

		/**
		 * join the channel, if the channel have not been created, it will been created automatically
		 *
		 * @param [in] channelName
		 *        the channel name
		 * @param [in] info
		 *        the additional information, it can be null here
		 * @param [in] uid
		 *        the uid of you, if 0 the system will automatically allocate one for you
		 * @return return 0 if success or an error code
		 */
		public int JoinChannel (string channelName, string info, uint uid)
		{
			return JoinChannelByKey(null, channelName, info, uid);
		}

		public int JoinChannelByKey (string channelKey, string channelName, string info, uint uid)
		{
			Debug.Log ("JoinChannelByKey");
			int r = joinChannel(channelKey, channelName, info, uid);
			return r;
		}

		public int RenewChannelKey (string channelKey)
		{
			Debug.Log ("RenewChannelKey");
			// save parameters
			return renewChannelKey (channelKey);
		}

		/**
		 * leave the current channel
		 *
		 * @return return 0 if success or an error code
		 */
		public int LeaveChannel ()
		{
			Debug.Log ("LeaveChannel");
			int r = leaveChannel (); // leave uncondionally
			return r;
		}

		public void Pause ()
		{
			Debug.Log ("Pause engine");
			DisableAudio ();
		}

		public void Resume ()
		{
			Debug.Log ("Resume engine");
			EnableAudio ();
		}

		// query message count
		public int GetMessageCount ()
		{
			return getMessageCount ();
		}

		// handle one message
		public void Poll ()
		{
			IntPtr msg = getMessage ();
			string str = Marshal.PtrToStringAnsi(msg);
			freeObject (msg);

			if (str.CompareTo ("") == 0)
				return;

			string[] sArray = str.Split ('\t');
			
			if (sArray [0].CompareTo ("onWarning") == 0) {
				if (OnWarning != null) {
					int warningCode = int.Parse (sArray [1]);
					OnWarning (warningCode, "");
				}
			} else if (sArray [0].CompareTo ("onError") == 0) {
				if (OnError != null) {
					int errCode = int.Parse (sArray [1]);
					OnError (errCode, "");
				}
			} else if (sArray [0].CompareTo ("onReportAudioVolumeIndications") == 0) {
				if (OnVolumeIndication != null) {
					int j = 1;
					AudioVolumeInfo[] infos = null;
					int spkCount = int.Parse(sArray [j++]);
					if (spkCount > 0)
						infos = new AudioVolumeInfo[spkCount];
					for (int i = 0; i < spkCount; i++) {
						uint uid = (uint)int.Parse (sArray [j++]);
						uint vol = (uint)int.Parse (sArray [j++]);
						infos [i].uid = uid;
						infos [i].volume = vol;
					}
					int totalVol = int.Parse (sArray [j++]);

					OnVolumeIndication (infos, spkCount, totalVol);
				}
			} else if (sArray [0].CompareTo ("onFirstLocalVideoFrame") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onFirstRemoteVideoFrameDecoded") == 0) {
				if (OnFirstRemoteVideoDecoded != null) {
					int uid = int.Parse (sArray [1]);
					int width = int.Parse (sArray [2]);
					int height = int.Parse (sArray [3]);
					int elapsed = int.Parse (sArray [4]);

					OnFirstRemoteVideoDecoded ((uint)uid, width, height, elapsed);
				}
			} else if (sArray [0].CompareTo ("onVideoSizeChanged") == 0) {
				if (OnVideoSizeChanged != null) {
					int uid = int.Parse (sArray [1]);
					int width = int.Parse (sArray [2]);
					int height = int.Parse (sArray [3]);
					int rotation = int.Parse (sArray [4]);

					OnVideoSizeChanged ((uint)uid, width, height, rotation);
				}
			} else if (sArray [0].CompareTo ("onFirstRemoteVideoFrameRendered") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onUserJoined") == 0) {
				if (OnUserJoined != null) {
					uint uid = (uint)int.Parse (sArray [1]);
					int elapsed = int.Parse (sArray [2]);
					OnUserJoined (uid, elapsed);
				}
			} else if (sArray [0].CompareTo ("onUserOffline") == 0) {
				if (OnUserOffline != null) {
					uint uid = (uint)int.Parse (sArray [1]);
					int reason = int.Parse (sArray [2]);
					OnUserOffline (uid, (USER_OFFLINE_REASON)reason);
				}
			} else if (sArray [0].CompareTo ("onAudioMutedByPeer") == 0) {
				if (OnUserMuted != null) {
					uint uid = (uint)int.Parse (sArray [1]);
					bool muted = int.Parse (sArray [2]) != 0;
					OnUserMuted (uid, muted);
				}
			} else if (sArray [0].CompareTo ("onVideoMutedByPeer") == 0) {
				if (OnUserMuteVideo != null) {
					uint uid = (uint)int.Parse (sArray [1]);
					bool muted = int.Parse (sArray [2]) != 0;
					OnUserMuteVideo (uid, muted);
				}
			} else if (sArray [0].CompareTo ("onAudioRouteChanged") == 0) {
				if (OnAudioRouteChanged != null) {
					int routing = int.Parse (sArray [1]);
					OnAudioRouteChanged ((AUDIO_ROUTE)routing);
				}
			} else if (sArray [0].CompareTo ("onVideoEnabledByPeer") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onLocalVideoStats") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onRemoteVideoStats") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onMediaEngineLoaded") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onMediaEngineStartCallSuccess") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onMediaEngineMixedAudio") == 0) {
				if (OnAudioMixingFinished != null) {
					OnAudioMixingFinished ();
				}
			} else if (sArray [0].CompareTo ("onCameraReady") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onVideoStopped") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onConnectionInterrupted") == 0) {
				if (OnConnectionInterrupted != null) {
					OnConnectionInterrupted ();
				}
			} else if (sArray [0].CompareTo ("onConnectionLost") == 0) {
				if (OnConnectionLost != null) {
					OnConnectionLost ();
				}
			} else if (sArray [0].CompareTo ("onJoinChannelSuccess") == 0) {
				if (OnJoinChannelSuccess != null) {
					uint uid = (uint)int.Parse (sArray [2]);
					int elapsed = int.Parse (sArray [3]);
					OnJoinChannelSuccess (sArray [1], uid, elapsed);
				}
			} else if (sArray [0].CompareTo ("onRejoinedChannel") == 0) {
				if (OnReJoinChannelSuccess != null) {
					uint uid = (uint)int.Parse (sArray [2]);
					int elapsed = int.Parse (sArray [3]);
					OnReJoinChannelSuccess (sArray [1], uid, elapsed);
				}
			} else if (sArray [0].CompareTo ("onReportRtcStats") == 0) {
				if (OnRtcStats != null) {
					int j = 1;
					int duration = int.Parse(sArray[j++]);
					int txBytes = int.Parse(sArray[j++]);
					int rxBytes = int.Parse(sArray[j++]);
					int txAudioKBitrate = int.Parse(sArray[j++]);
					int rxAudioKBitrate = int.Parse(sArray[j++]);
					int txVideoKBitrate = int.Parse(sArray[j++]);
					int rxVideoKBitrate = int.Parse(sArray[j++]);
					int users = int.Parse(sArray[j++]);

					RtcStats stats;
					stats.duration = (uint)duration;
					stats.txBytes = (uint)txBytes;
					stats.rxBytes = (uint)rxBytes;
					stats.txKBitRate = (ushort)(txAudioKBitrate + txVideoKBitrate);
					stats.rxKBitRate = (ushort)(rxAudioKBitrate + rxVideoKBitrate);
					stats.txAudioKBitRate = (ushort)txAudioKBitrate;
					stats.rxAudioKBitRate = (ushort)rxAudioKBitrate;
					stats.lastmileQuality = 0; // unknown
					stats.users = (uint)users;
					stats.cpuAppUsage = 0; // unknown
					stats.cpuTotalUsage = 0; // unknown

					OnRtcStats (stats);
				}

			} else if (sArray [0].CompareTo ("onLeftChannel") == 0) {
				if (OnLeaveChannel != null) {
					int duration = int.Parse (sArray [1]);
					int txBytes = int.Parse (sArray [2]);
					int rxBytes = int.Parse (sArray [3]);
					int txAudioKBitrate = int.Parse (sArray [4]);
					int rxAudioKBitrate = int.Parse (sArray [5]);
					int txVideoKBitrate = int.Parse (sArray [6]);
					int rxVideoKBitrate = int.Parse (sArray [7]);
					int users = int.Parse (sArray [8]);

					RtcStats stats;
					stats.duration = (uint)duration;
					stats.txBytes = (uint)txBytes;
					stats.rxBytes = (uint)rxBytes;
					stats.txKBitRate = (ushort)(txAudioKBitrate + txVideoKBitrate);
					stats.rxKBitRate = (ushort)(rxAudioKBitrate + rxVideoKBitrate);
					stats.txAudioKBitRate = (ushort)txAudioKBitrate;
					stats.rxAudioKBitRate = (ushort)rxAudioKBitrate;
					stats.lastmileQuality = 0; // unknown
					stats.users = (uint)users;
					stats.cpuAppUsage = 0; // unknown
					stats.cpuTotalUsage = 0; // unknown
					OnLeaveChannel (stats);
				}
			} else if (sArray [0].CompareTo ("onAudioQualityOfPeer") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onNetworkQualityOfPeer") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onLastMileQuality") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onApiExecuted") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onRecordingServiceStatus") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onStreamMessage") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onStreamMessageError") == 0) {
				// TODO:
			} else if (sArray [0].CompareTo ("onRequestChannelKey") == 0) {
				if (OnRequestChannelKey != null) {
					OnRequestChannelKey ();
				}
			} else if (sArray [0].CompareTo ("onClientRoleChanged") == 0) {
				if(OnClientRoleChanged != null) {
					int oldRole = int.Parse (sArray [1]);
					int newRole = int.Parse (sArray [2]);
					OnClientRoleChanged (oldRole, newRole);
				}
			} else {
			}
		}

		/**
		 * set parameters of the SDK
		 *
		 * @param [in] parameters
		 *        the parameters(in json format)
		 * @return return 0 if success or an error code
		 */
		public int SetParameters (string parameters)
		{
			return setParameters (parameters);
		}

		public int SetParameter (string parameter, int value)
		{
			string parameters = doFormat ("{{\"{0}\": {1}}}", parameter, value);
			return setParameters (parameters);
		}

		public int SetParameter (string parameter, double value)
		{
			string parameters = doFormat ("{{\"{0}\": {1}}}", parameter, value);
			return setParameters (parameters);
		}

		public int SetParameter (string parameter, bool value)
		{
			string boolValue = value ? "true" : "false";
			string parameters = doFormat ("{{\"{0}\": {1}}}", parameter, boolValue);
			return setParameters (parameters);
		}

		// deprecated. use GetParameterInt
		public int GetParameter(string parameter)
		{
			return GetParameterInt (parameter, null);
		}

		public int GetParameterInt(string parameter, string args)
		{
			string s = GetParameter (parameter, args);
			if (s != null)
				return int.Parse (s);
			else
				return 0;
		}

		public string GetParameter(string parameter, string args)
		{
			string s = null;
			IntPtr res = getParameter (parameter, args);
			if (res != IntPtr.Zero) {
				s = Marshal.PtrToStringAnsi (res);
				freeObject (res);
			}
			return s;
		}

		public string GetCallId()
		{
			string s = null;
			IntPtr res = getCallId ();
			if (res != IntPtr.Zero) {
				s = Marshal.PtrToStringAnsi (res);
				freeObject (res);
			}
			return s;
		}

		public int Rate(string callId, int rating, string desc)
		{
            return rate(callId, rating, desc);
		}

		public int Complain(string callId, string desc)
		{
            return complain(callId, desc);
		}


		/**
		 * enable audio function, which is enabled by deault.
		 *
		 * @return return 0 if success or an error code
		 */
		public int EnableAudio()
		{
			return enableAudio ();
		}

		/**
		 * disable audio function
		 *
		 * @return return 0 if success or an error code
		 */
		public int DisableAudio()
		{
			return disableAudio ();
		}

		/**
		 * mute/unmute the local audio stream capturing
		 *
		 * @param [in] mute
		 *       true: mute
		 *       false: unmute
		 * @return return 0 if success or an error code
		 */
		public int MuteLocalAudioStream (bool mute)
		{
			return muteLocalAudioStream (mute ? 1 : 0);
		}

		/**
		 * mute/unmute all the remote audio stream receiving
		 *
		 * @param [in] mute
		 *       true: mute
		 *       false: unmute
		 * @return return 0 if success or an error code
		 */
		public int MuteAllRemoteAudioStreams (bool mute)
		{
			return muteAllRemoteAudioStreams (mute ? 1 : 0);
		}

		/**
		 * mute/unmute specified remote audio stream receiving
		 *
		 * @param [in] uid
		 *        the uid of the remote user you want to mute/unmute
		 * @param [in] mute
		 *       true: mute
		 *       false: unmute
		 * @return return 0 if success or an error code
		 */
		public int MuteRemoteAudioStream (uint uid, bool mute)
		{
			return muteRemoteAudioStream ((int)uid, (mute ? 1 : 0));
		}

		public int SetEnableSpeakerphone (bool speakerphone)
		{
			return setEnableSpeakerphone (speakerphone ? 1 : 0);
		}

		public int SetDefaultAudioRouteToSpeakerphone(bool speakerphone)
		{
			return setDefaultAudioRoutetoSpeakerphone (speakerphone ? 1 : 0);
		}

        public bool IsSpeakerphoneEnabled()
        {
            return isSpeakerphoneEnabled() != 0;
        }

        public int SwitchCamera()
        {
            return switchCamera();
        }

        public int SetVideoProfile(int profile, bool swapWidthAndHeight)
        {
            return setVideoProfile(profile, (swapWidthAndHeight ? 1 : 0));
        }

        public int MuteLocalVideoStream(bool mute)
        {
            return muteLocalVideoStream(mute ? 1 : 0);
        }

        public int MuteAllRemoteVideoStreams(bool mute)
        {
            return muteAllRemoteVideoStreams(mute ? 1 : 0);
        }

        public int MuteRemoteVideoStream(uint uid, bool mute)
        {
			return muteRemoteVideoStream((int)uid, (mute ? 1 : 0));
        }

        public int EnableDualStreamMode(bool enabled)
        {
            return enableDualStreamMode(enabled ? 1 : 0);
        }

        public int SetEncryptionMode(string encryptionMode)
        {
            return setEncryptionMode(encryptionMode);
        }

        public int SetEncryptionSecret(string secret)
        {
            return setEncryptionSecret(secret);
        }

        public int StartRecordingService(string recordingKey)
        {
            return startRecordingService(recordingKey);
        }

        public int StopRecordingService(string recordingKey)
        {
            return stopRecordingService(recordingKey);
        }

        public int RefreshRecordingServiceStatus()
        {
            return refreshRecordingServiceStatus();
        }

		/*
        public int CreateDataStream(bool reliable, bool ordered)
        {
            return createDataStream((reliable ? 1 : 0), (ordered ? 1 : 0));
        }

        public int SendStreamMessage(int streamId, string data)
        {
            return sendStreamMessage(streamId, data);
        }
        */

        public int SetRecordingAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall)
        {
            return setRecordingAudioFrameParametersWithSampleRate(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetPlaybackAudioFrameParametersWithSampleRate(int sampleRate, int channel, int mode, int samplesPerCall)
        {
            return setPlaybackAudioFrameParametersWithSampleRate(sampleRate, channel, mode, samplesPerCall);
        }

        public int SetSpeakerphoneVolume(int volume)
        {
            return setSpeakerphoneVolume(volume);
        }

		/*
        public int SetHighQualityAudioParametersWithFullband(bool fullband, bool stereo, bool fullBitrate)
        {
            return setHighQualityAudioParametersWithFullband((fullband ? 1 : 0), (stereo ? 1 : 0), (fullBitrate ? 1 : 0));
        }

        public int EnableInEarMonitoring(bool enabled)
        {
            return enableInEarMonitoring((enabled ? 1 : 0));
        }

        public int EnableWebSdkInteroperability(bool enabled)
        {
            return enableWebSdkInteroperability((enabled ? 1 : 0));
        }
        */

        public int SetVideoQualityParameters(bool preferFrameRateOverImageQuality)
        {
            return setVideoQualityParameters((preferFrameRateOverImageQuality ? 1 : 0));
        }

        public int StartEchoTest()
        {
            return startEchoTest();
        }

        public int StopEchoTest()
        {
            return stopEchoTest();
        }

        public int SetRemoteVideoStreamType(uint uid, int streamType)
        {
            return setRemoteVideoStreamType((int)uid, streamType);
        }

        public int SetMixedAudioFrameParameters(int sampleRate, int samplesPerCall)
        {
			return setMixedAudioFrameParameters(sampleRate, samplesPerCall);
        }

        public int SetAudioMixingPosition(int pos)
        {
			return setAudioMixingPosition(pos);
        }

		/**
		 * enable or disable the audio volume indication
		 *
		 * @param [in] interval
		 *        the period of the callback cycle, in ms
		 *        interval <= 0: disable
		 *        interval >  0: enable
		 * @param [in] smooth
		 *        the smooth parameter
		 * @return return 0 if success or an error code
		 */
		public int EnableAudioVolumeIndication (int interval, int smooth)
		{
			return enableAudioVolumeIndication (interval, smooth);
		}

		/**
		 * adjust recording signal volume
		 *
		 * @param [in] volume range from 0 to 400
		 * @return return 0 if success or an error code
		 */
		public int AdjustRecordingSignalVolume (int volume)
		{
			return adjustRecordingSignalVolume (volume);
		}

		/**
		 * adjust playback signal volume
		 *
		 * @param [in] volume range from 0 to 400
		 * @return return 0 if success or an error code
		 */
		public int AdjustPlaybackSignalVolume (int volume)
		{
			return adjustPlaybackSignalVolume (volume);
		}

		/**
		 * mix microphone and local audio file into the audio stream
		 *
		 * @param [in] filePath
		 *        specify the path and file name of the audio file to be played
		 * @param [in] loopback
		 *        specify if local and remote participant can hear the audio file.
		 *        false (default): both local and remote party can hear the the audio file
		 *        true: only the local party can hear the audio file
		 * @param [in] replace
		 *        false (default): mix the local microphone captured voice with the audio file
		 *        true: replace the microphone captured voice with the audio file
		 * @param [in] cycle
		 *        specify the number of cycles to play
		 *        -1, infinite loop playback
		 * @param [in] playTime (not support)
		 *        specify the start time(ms) of the audio file to play
		 *        0, from the start
		 * @return return 0 if success or an error code
		 */
		public int StartAudioMixing (string filePath, bool loopback, bool replace, int cycle, int playTime = 0)
		{
			return startAudioMixing (filePath, (loopback ? 1 : 0), (replace ? 1 : 0), cycle, playTime);
		}

		/**
		 * stop mixing the local audio stream
		 *
		 * @return return 0 if success or an error code
		 */
		public int StopAudioMixing()
		{
			return stopAudioMixing ();
		}

		/**
		 * pause mixing the local audio stream
		 *
		 * @return return 0 if success or an error code
		 */
		public int PauseAudioMixing()
		{
			return pauseAudioMixing ();
		}

		/**
		 * resume mixing the local audio stream
		 *
		 * @return return 0 if success or an error code
		 */
		public int ResumeAudioMixing()
		{
			return resumeAudioMixing ();
		}

		/**
		 * adjust mixing audio file volume
		 *
		 * @param [in] volume range from 0 to 100
		 * @return return 0 if success or an error code
		 */
		public int AdjustAudioMixingVolume (int volume)
		{
			return adjustAudioMixingVolume (volume);
		}

		/**
		 * get the duration of the specified mixing audio file
		 *
		 * @return return duration(ms)
		 */
		public int GetAudioMixingDuration()
		{
			return getAudioMixingDuration ();
		}

		/**
		 * get the current playing position of the specified mixing audio file
		 *
		 * @return return the current playing(ms)
		 */
		public int GetAudioMixingCurrentPosition()
		{
			return getAudioMixingCurrentPosition ();
		}

		/**
		 * start recording audio streaming to file specified by the file path
		 *
		 * @param filePath file path to save recorded audio streaming
		 * @return return 0 if success or an error code
		 * Deprecated. Use int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
		 */
		public int StartAudioRecording(string filePath)
		{
			return StartAudioRecording (filePath, AUDIO_RECORDING_QUALITY_TYPE.AUDIO_RECORDING_QUALITY_MEDIUM);
		}

		public int StartAudioRecording(string filePath, AUDIO_RECORDING_QUALITY_TYPE quality)
		{
			return startAudioRecording (filePath, (int)quality);
		}

		/**
		 * stop audio streaming recording
		 *
		 * @return return 0 if success or an error code
		 */
		public int StopAudioRecording()
		{
			return stopAudioRecording ();
		}

		public IAudioEffectManager GetAudioEffectManager ()
		{
			return mAudioEffectM;
		}

		public int EnableVideo ()
		{
			return enableVideo ();
		}

		public int DisableVideo ()
		{
			return disableVideo ();
		}

		public int EnableLocalVideo (bool enabled)
		{
			return enableLocalVideo (enabled ? 1 : 0);
		}

		public int StartPreview ()
		{
			return startPreview ();
		}

		public int StopPreview ()
		{
			return stopPreview ();
		}

		public int EnableVideoObserver ()
		{
			return enableVideoObserver ();
		}

		public int DisableVideoObserver ()
		{
			return disableVideoObserver ();
		}

		// load data to texture
		// return value:
		public int UpdateTexture (int tex, uint uid, ref uint width, ref uint height)
		{
			int rc = updateTexture (tex, uid);
			if (rc == -1)
				return -1;
			width = (uint)rc >> 16;
			height = (uint)(rc & 0xffff);
			return 0;
		}

		public int GenerateNativeTexture ()
		{
			return generateNativeTexture ();
		}

		public void DeleteTexture(int tex)
		{
			deleteTexture(tex);
		}

		public int SetLocalVoicePitch (double pitch)
		{
			return setLocalVoicePitch (pitch);
		}

		public int SetRemoteVoicePosition (uint uid, double pan, double gain)
		{
			return setRemoteVoicePosition (uid, pan, gain);
		}

		public int SetVoiceOnlyMode (bool enable)
		{
			return setVoiceOnlyMode (enable);
		}

		public static IRtcEngine GetEngine (string appId)
		{
			if (instance == null) {
				instance = new IRtcEngine (appId);
			}
			return instance;
		}

		// depricated. use GetEngine instead
		public static IRtcEngine getEngine (string appId)
		{
			return GetEngine (appId);
		}

		public static void Destroy()
		{
			if (instance == null)
				return;

			// break the connection with mAudioEffectM
			AudioEffectManagerImpl am = (AudioEffectManagerImpl)instance.GetAudioEffectManager ();
			am.SetEngine (null);

			deleteEngine ();
			instance = null;
		}

		// only query, do not create
		public static IRtcEngine QueryEngine()
		{
			return instance;
		}

		private static IRtcEngine instance = null;
	}
}
