using UnityEngine;
using System.Collections;

public class MusicDestroy : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private MusicController musicController;
	
	void Start()
	{
		GameObject musicControllerObject = GameObject.FindWithTag ("MusicController");
		if (musicControllerObject != null) {
			musicController = musicControllerObject.GetComponent <MusicController>();
			
		}
		if (musicController == null) {
			Debug.Log ("Cannot find 'MusicController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			musicController.GameOver ();
		}
		musicController.AddScore (scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}