using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This example script demonstrates how to attach
 * video content to a 3D object (chenzhenyong@agora.io)
 * 
 * Agora engine outputs one local preview video and some
 * remote user video. User ID (int) is used to identify
 * these video streams. 0 is used for local preview video
 * stream, and other value stands for remote user video
 * stream.
 */

public class VideoSurface : MonoBehaviour {
	// Use this for initialization
	void Start () {
		// do not set value here. not early enough
//		mUid = 0;
//		mEnable = true;
	}
	
	// Update is called once per frame
	void Update () {
		// process engine messages (TODO: put in some other place)
		agora_gaming_rtc.IRtcEngine engine = agora_gaming_rtc.IRtcEngine.QueryEngine();
		if (engine == null)
			return;

		while (engine.GetMessageCount() > 0)
			engine.Poll ();

		// render video
		Renderer rend = GetComponent<Renderer> ();

		#if UNITY_IOS || UNITY_ANDROID
		uint uid = mUid;
		if(mEnable) {
			// create texture if not existent
			if (rend.material.mainTexture == null) {
				System.IntPtr texPtr = (System.IntPtr)engine.GenerateNativeTexture ();
				Texture2D nativeTexture  = Texture2D.CreateExternalTexture(640, 360, TextureFormat.ARGB32, false, false, texPtr); // FIXME! texture size is subject to change
				rend.material.mainTexture = nativeTexture;
			}

			// update texture
			if (rend.material.mainTexture != null && rend.material.mainTexture is Texture2D) {
				Texture2D tex = rend.material.mainTexture as Texture2D;
				int texId = (int)tex.GetNativeTexturePtr ();

				// update texture (possible size changing)
				uint texWidth = 0;
				uint texHeight = 0;
				if(engine.UpdateTexture (texId, uid, ref texWidth, ref texHeight) == 0) {
					// TODO: process texture then render
				}
			}
		}
		else {
			if (rend.material.mainTexture != null && rend.material.mainTexture is Texture2D) {
				Texture2D tex = rend.material.mainTexture as Texture2D;
				int texId = (int)tex.GetNativeTexturePtr ();
				engine.DeleteTexture(texId);
				rend.material.mainTexture = null;
			}
		}
		#endif

		// add your extra effects
		if (mAdjustTransfrom != null) {
			Transform trans = rend.transform;
			mAdjustTransfrom (mUid, gameObject.name, ref trans);
		}
	}

	// call this to render video stream from uid on this game object
	public void SetForUser(uint uid) {
		mUid = uid;
		Debug.Log ("Set uid " + uid + " for " + gameObject.name);
	}

	public void SetEnable(bool enable) {
		mEnable = enable;
	}

	public delegate void SetTransformDelegate (uint uid, string objName, ref Transform transform);
	public SetTransformDelegate mAdjustTransfrom = null;

	private uint mUid = 0;
	private bool mEnable = true; // if disabled, then no rendering happens
}
