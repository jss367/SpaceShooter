using UnityEngine;
using System.Collections;

public class TestDel : MonoBehaviour {

	private bool btest;
	// Use this for initialization
	void Start () {
		Debug.Log (btest + "btest");
		//	btest = true;
		Debug.Log (btest + "btest");
		GaveOver();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (btest + "btest");
	}

	void GaveOver()
	{
		btest = true;
	}
}
