using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {

void onMouseEnter()
	{
				renderer.material.color = Color.grey;
		}

	void onMouseExit()
	{
				renderer.material.color = Color.white;
		}


}
