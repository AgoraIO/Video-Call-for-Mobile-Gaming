using UnityEngine;
using System.Collections;

namespace agora_gaming_rtc
{
	public interface IAudioEffectManager
	{
		/**
		 * get audio effect volume in the range of [0.0..100.0]
		 *
		 * @return return effect volume
		 */
		double GetEffectsVolume();

		/**
		 * set audio effect volume
		 *
		 * @param [in] volume
		 *        in the range of [0..100]
		 * @return return 0 if success or an error code
		 */
		int SetEffectsVolume(double volume);

		/**
		 * start playing local audio effect specified by file path and other parameters
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @param [in] filePath
		 *        specify the path and file name of the effect audio file to be played
		 * @param [in] loop
		 *        whether to loop the effect playing or not, default value is false
		 * @param [in] pitch
		 *        frequency, in the range of [0.5..2.0], default value is 1.0
		 * @param [in] pan
		 *        stereo effect, in the range of [-1..1] where -1 enables only left channel, default value is 0.0
		 * @param [in] gain
		 *        volume, in the range of [0..100], default value is 100
		 * @return return 0 if success or an error code
		 */
		int PlayEffect (int soundId, string filePath,
			bool loop = false,
			double pitch = 1.0D,
			double pan = 0.0D,
			double gain = 100.0D
		);

		/**
		 * stop playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int StopEffect(int soundId);

		/**
		 * stop all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int StopAllEffects();

		/**
		 * preload a compressed audio effect file specified by file path for later playing
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @param [in] filePath
		 *        specify the path and file name of the effect audio file to be preloaded
		 * @return return 0 if success or an error code
		 */
		int PreloadEffect(int soundId, string filePath);

		/**
		 * unload specified audio effect file from SDK
		 *
		 * @return return 0 if success or an error code
		 */
		int UnloadEffect(int soundId);

		/**
		 * pause playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int PauseEffect(int soundId);

		/**
		 * pausing all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int PauseAllEffects();

		/**
		 * resume playing specified audio effect
		 *
		 * @param [in] soundId
		 *        specify the unique sound id
		 * @return return 0 if success or an error code
		 */
		int ResumeEffect(int soundId);

		/**
		 * resume all playing audio effects
		 *
		 * @return return 0 if success or an error code
		 */
		int ResumeAllEffects();

		/**
		 * set voice only mode(e.g. keyboard strokes sound will be eliminated)
		 *
		 * @param [in] enable
		 *        true for enable, false for disable
		 * @return return 0 if success or an error code
		 */
		int SetVoiceOnlyMode(bool enable);

		/**
		 * place specified speaker's voice with pan and gain
		 *
		 * @param [in] uid
		 *        speaker's uid
		 * @param [in] pan
		 *        stereo effect, in the range of [-1..1] where -1 enables only left channel, default value is 0.0
		 * @param [in] gain
		 *        volume, in the range of [0..100], default value is 100
		 * @return return 0 if success or an error code
		 */
		int SetRemoteVoicePosition(uint uid, double pan, double gain);

		/**
		 * change the pitch of local speaker's voice
		 *
		 * @param [in] pitch
		 *        frequency, in the range of [0.5..2.0], default value is 1.0
		 * @return return 0 if success or an error code
		 */
		int SetLocalVoicePitch (double pitch);
	}

	class AudioEffectManagerImpl : IAudioEffectManager
	{
		private IRtcEngine mEngine;

		public AudioEffectManagerImpl (IRtcEngine rtcEngine)
		{
			mEngine = rtcEngine;
		}

		// used internally
		public void SetEngine(IRtcEngine engine)
		{
			mEngine = engine;
		}

		public double GetEffectsVolume ()
		{
			if (mEngine == null)
				return 0.0;
			return mEngine.GetParameter ("che.audio.game_get_effects_volume");
		}

		public int SetEffectsVolume (double volume)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_set_effects_volume", volume);
		}

		public int PlayEffect (int soundId, string filePath,
			bool loop = false,
			double pitch = 1.0D,
			double pan = 0.0D,
			double gain = 100.0D)
		{
			if (mEngine == null)
				return 0;
			string loopValue = loop ? "true" : "false";
			string fmt = "{{\"che.audio.game_play_effect\": {{\"soundId\":{0},\"filePath\":\"{1}\",\"loop\":{2},\"pitch\":{3:0.00},\"pan\":{4:0.00},\"gain\":{5:0.00}}}}}";
			string parameters = mEngine.doFormat (fmt, soundId, filePath, loopValue, pitch, pan, gain);
			return mEngine.SetParameters (parameters);
		}

		public int StopEffect (int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_stop_effect", soundId);
		}

		public int StopAllEffects ()
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_stop_all_effects", true);
		}

		public int PreloadEffect (int soundId, string filePath)
		{
			if (mEngine == null)
				return 0;
			string fmt = "{{\"che.audio.game_preload_effect\": {{\"soundId\":{0},\"filePath\":\"{1}}}}}";
			string parameters = mEngine.doFormat (fmt, soundId, filePath);
			return mEngine.SetParameters (parameters);
		}

		public int UnloadEffect(int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_unload_effect", soundId);
		}

		public int PauseEffect(int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_pause_effect", soundId);
		}

		public int PauseAllEffects()
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_pause_all_effects", true);
		}

		public int ResumeEffect(int soundId)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_resume_effect", soundId);
		}

		public int ResumeAllEffects()
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_resume_all_effects", true);
		}

		public int SetVoiceOnlyMode(bool enable)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_voice_over_mode", enable);
		}

		public int SetRemoteVoicePosition(uint uid, double pan, double gain)
		{
			if (mEngine == null)
				return 0;
			string fmt = "{{\"che.audio.game_place_sound_position\": {{\"uid\":{0},\"pan\":{1:0.00},\"gain\":{2:0.00}}}}}";
			string parameters = mEngine.doFormat (fmt, uid, pan, gain);
			return mEngine.SetParameters (parameters);
		}

		public int SetLocalVoicePitch (double pitch)
		{
			if (mEngine == null)
				return 0;
			return mEngine.SetParameter ("che.audio.game_local_pitch_shift", pitch * 100);
		}
	}
}
