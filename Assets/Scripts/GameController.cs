using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;

	private bool itsOver;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();

		Debug.Log (itsOver + "itsOver");
		//	btest = true;
		GameOver ();
		//GafeOver();


		//		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		Debug.Log (itsOver + "itsOver");
		//	Debug.Log ("You are updating");
	//	Debug.Log (restart);
		//Debug.Log (itsOver + " itsover");
	//	Debug.Log (gameOver + "go");
				if (restart) {
						Debug.Log ("You are in restart mode");
						{
								if (Input.touchCount != 0 || Input.GetKeyDown (KeyCode.R)) {
										Application.LoadLevel (Application.loadedLevel);
								}
						}
				}
}
/*
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		
		}
	}
*/	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	//	Debug.Log (gameOver);
//temp add
		restartText.text = "Touch anywhere to Restart or Press 'R'";
		restart = true;
		//itsOver = false;
		//yield return new WaitForSeconds (waveWait);
		//Application.LoadLevel (Application.loadedLevel);


	/*	if (Input.GetKeyDown (KeyCode.R))
		{
			Application.LoadLevel (Application.loadedLevel);
		}
*/
		//temp del
		itsOver = true;
		//GafeOver ();
	}

	void GafeOver()
	{
		itsOver = true;
	}

}