using UnityEngine;
using System.Collections;
using AndroidMediaBrowser;

	public class SongPicker : MonoBehaviour
	{
		Audio _track = null;
//	Debug.Log("SongPicker has been called");
		void Start()
		{
		Debug.Log("SongPicker has started");
			AudioBrowser.OnPicked += OnPicked;
			AudioBrowser.Pick();
		}
		
		void OnPicked(Audio track)
		{
		Debug.Log("SongPicker has been picked");
			_track = track;
			StartCoroutine(_track.LoadAudioClip(false, false, AudioType.MPEG));
		}
		
		void LateUpdate()
		{
		Debug.Log("SongPicker has been updated");
			if (_track != null && _track.AudioClip != null && !audio.isPlaying)
			{
				audio.clip = _track.AudioClip;
				audio.Play();
			}
		}
	}