using UnityEngine;
using System.Collections;

public class PlayMusic : MonoBehaviour {

		
		void Start()
		{
			/*AudioBrowser.OnPicked += OnPicked;
			AudioBrowser.Pick();*/
		}
		
		/*void OnPicked(Audio track)
		{
			_track = track;
			StartCoroutine(_track.LoadAudioClip(false, false, AudioType.MPEG));
		}*/
		
		void LateUpdate()
		{
			/*if (_track != null && _track.AudioClip != null && !audio.isPlaying)
			{
				audio.clip = _track.AudioClip;
				audio.Play();
			}*/
		}
	}