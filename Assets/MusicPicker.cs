using UnityEngine;
using AndroidMediaBrowser;

public class MusicPicker : MonoBehaviour
{

	private string _audio = "";

	Audio _track = null;
	
	void Start()
	{


		
		AudioBrowser.OnPicked += (audio) =>
		{
			_audio = string.Format(
				"Id: {0}\nUri: {1}\nPath: {2}\nTitle: {3}\nArtist: {4}",
				audio.Id, audio.Uri, audio.Path, audio.Title, audio.Artist);
		};
		AudioBrowser.OnPickCanceled += () =>
		{
			_audio = "Audio pick canceled";
		};

	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, Screen.width - 20, Screen.height - 20));
		GUI.skin.button.fixedHeight = (Screen.height - 20) / 12;
		GUI.skin.button.fixedWidth = (Screen.width - 20) / 4;
		GUI.skin.textArea.fixedHeight = (Screen.height - 20) / 3 - 20 - GUI.skin.button.fixedHeight / 3;

		GUILayout.BeginHorizontal();
		{
			if (GUILayout.Button("Pick Audio"))
			{
				AudioBrowser.Pick();
			}
			GUILayout.TextArea(_audio);
		}
		GUILayout.EndHorizontal();
		GUILayout.Space(20);
		

		
		GUI.skin.button.fixedWidth = Screen.width - 20;
		if (GUILayout.Button("Exit"))
		{
			Application.Quit();
		}
		
		GUILayout.EndArea();
	}

	void OnPicked(Audio track)
	{
		_track = track;
		StartCoroutine(_track.LoadAudioClip(false, false, AudioType.MPEG));
	}

	void LateUpdate()
	{
		if (_track != null && _track.AudioClip != null && !audio.isPlaying)
		{
			audio.clip = _track.AudioClip;
			audio.Play();
		}
	}

}
