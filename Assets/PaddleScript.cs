using UnityEngine;
using System.Collections;

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
		transform.position = paddlePos;

		if (paddlePos.x <= -xBound) {
			transform.position = new Vector3 (-xBound, paddlePos.y, paddlePos.z);
		} 
		if (paddlePos.x >= xBound) {
			transform.position = new Vector3(xBound, paddlePos.y, paddlePos.z);     
		}
	}
}
