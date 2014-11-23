using UnityEngine;
using System.IO;
using System.Collections;

public class streamer : MonoBehaviour {

	public string internetmusic = "http://grooveshark.com/#!/s/You+Suffer/6IDpiD?src=5";
	public string filemusic = "W:/Music/Childish Gambino/Because The Internet/01 The Library (Intro)";
	private WWW iMusic;
	private WWW fMusic;
	void Start () {
		iMusic = new WWW (internetmusic);
		fMusic = new WWW (filemusic);
	}
	void Update() {
		if (iMusic.isDone)
		
		{
			Debug.Log("iMusic.isDone");
			audio.clip = iMusic.GetAudioClip (false, true, AudioType.MPEG);
			this.enabled = false;
			audio.Play ();
	}

		if (fMusic.isDone)
			
		{
			Debug.Log("fMusic.isDone");
			audio.clip = fMusic.GetAudioClip (false, true, AudioType.MPEG);
			this.enabled = false;
			audio.Play ();
		}
	}
}
