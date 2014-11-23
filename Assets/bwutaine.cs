using UnityEngine;
using System.Collections;

public class bwutaine : MonoBehaviour {


	// Use this for initialization
	void Start () {


	}


	
	// Update is called once per frame
	void OnGUI () {

		if(GUI.Button(new Rect(Screen.width/2, Screen.height/2, 100, 25), "Start Game!"))
		{
			Application.LoadLevel("Cube");
		}

	}
}
