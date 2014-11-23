using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AndroidMediaBrowser;
namespace FMG
{
	public class Modified5Menu : MonoBehaviour {
		public GameObject mainMenu;
		public GameObject levelSelectMenu;
		public GameObject optionsMenu;
		public GameObject creditsMenu;
		
		public bool useLevelSelect = true;
		public bool useExitButton = true;
		
		public GameObject exitButton;

		private string _audio = "";

		public void Start()
		{
				AudioBrowser.OnPicked += (audio) =>
				{
						_audio = string.Format (
					"Id: {0}\nUri: {1}\nPath: {2}\nTitle: {3}\nArtist: {4}",
					audio.Id, audio.Uri, audio.Path, audio.Title, audio.Artist);
				};
				AudioBrowser.OnPickCanceled += () =>
				{
						_audio = "Audio pick canceled";
				};
		}

		public void Awake()
		{
			if(useExitButton==false)
			{
				exitButton.SetActive(false);
			}
		}
		
		public void onCommand(string str)
		{
			if(str.Equals("LevelSelect"))
			{
				if(useLevelSelect)
				{
					levelSelectMenu.SetActive(true);
					mainMenu.SetActive(false);
				}else{
					Application.LoadLevel(1);
				}
			}
			
			if(str.Equals("LevelSelectBack"))
			{
				mainMenu.SetActive(true);
				levelSelectMenu.SetActive(false);
			}
			if(str.Equals("Exit"))
			{
				Application.Quit();
			}
			if(str.Equals("Credits"))
			{
			//	creditsMenu.SetActive(true);
				mainMenu.SetActive(false);

			}
			if(str.Equals("CreditsBack"))
			{
				creditsMenu.SetActive(false);
				mainMenu.SetActive(true);
			}
			
			
			if(str.Equals("OptionsBack"))
			{
				optionsMenu.SetActive(false);
				mainMenu.SetActive(true);
			}
			if(str.Equals("Options"))
			{
				optionsMenu.SetActive(true);
				mainMenu.SetActive(false);
			}
			
			
		}
	}
}
