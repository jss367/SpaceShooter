using UnityEngine;
using System.Collections;


//[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	public Vector3 target;
	public float velocityLag = 1.0f;
	public float dampingRadius = 1.0f;

	void Update(){

		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}

		}
	void FixedUpdate ()
	{


		//Find whether the mouse button 0 was pressed or released this frame
//		bool b0Down = Input.GetMouseButtonDown (0);

		Vector3? touchPos = null;
		//Return whether the given mouse button is held down.
		//button values are 0 for left button, 1 for right button, 2 for the middle button.
		if (Input.mousePresent && Input.GetMouseButton (0)) 
		{
					touchPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0.0f);
			} 
		else if (Input.touchCount > 0)  //should i add an if to see if the phase is stationary?
		{
					touchPos = new Vector3 (Input.touches [0].position.x, Input.touches [0].position.y, 0.0f);
				}

			
		if (touchPos != null)
		{
			target = Camera.main.ScreenToWorldPoint(touchPos.Value);
			target.y = rigidbody.position.y;
		}
	 
		Vector3 offset = target - rigidbody.position;

		float magnitude = offset.magnitude;
			if(magnitude > dampingRadius)
		{
					magnitude = dampingRadius;
		}
		float dampening = magnitude / dampingRadius;

		Vector3 desiredVelocity = offset.normalized * speed * dampening;

		rigidbody.velocity += (desiredVelocity - rigidbody.velocity) * velocityLag;


	/*	rigidbody.position = new Vector3
		(
			Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
		    0.0f, 
			Mathf.Clamp (rigidbody.position.z, boundary.zMin, boundary.zMax)
		);
*/
		rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}
