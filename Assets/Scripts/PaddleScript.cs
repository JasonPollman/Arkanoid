using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PaddleScript : MonoBehaviour {

	public float paddleVelocity;
	private Vector3 paddlePos;
	public float xBound;

	// Use this for initialization
	void Start () {
		// Get the initial position of the paddle:
		paddlePos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		paddlePos.x += Input.GetAxis ("Horizontal") * paddleVelocity;

		if (paddlePos.x < -xBound) {
			paddlePos = new Vector3 (-xBound, paddlePos.y, paddlePos.z);
		} 
		if (paddlePos.x > xBound) {
			paddlePos = new Vector3(xBound, paddlePos.y, paddlePos.z);     
		}

		transform.position = paddlePos;

	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (GameVars.bricksLeft.ToString() + " BRICKS");
		audio.Play ();
	}
}
