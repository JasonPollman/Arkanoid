using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PaddleScript : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	public float acceleration;
	public float deceleration;

	private Vector3 paddlePos;
	public float xBound;

	// Use this for initialization
	void Start () {
		// Get the initial position of the paddle:
		paddlePos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (AddBricks.canPause == true && Input.GetKey("left") && gameObject.transform.rotation.z < GameVars.paddleTiltMax) {
			gameObject.transform.Rotate(0, 0, GameVars.paddleTiltSpeed);
		}

		if (AddBricks.canPause == true && Input.GetKey("right") && gameObject.transform.rotation.z > -GameVars.paddleTiltMax) {
			gameObject.transform.Rotate(0, 0, -GameVars.paddleTiltSpeed);
		}


		if (Input.GetKey("a") && speed < maxSpeed) {
			speed = speed - acceleration * Time.deltaTime;
		}
		else if (Input.GetKey("d") && speed > -maxSpeed) {
			 speed = speed + acceleration * Time.deltaTime;
		}
		else {
			if(speed > deceleration * Time.deltaTime) {
				speed = speed - deceleration * Time.deltaTime;
			}
			else if(speed < -deceleration * Time.deltaTime) {
				speed = speed + deceleration * Time.deltaTime;
			}
			else {
				speed = 0;
			}
		}

		paddlePos.x += speed * 4 * Time.deltaTime;

		if (paddlePos.x < -xBound) {
			paddlePos = new Vector3 (-xBound, paddlePos.y, paddlePos.z);
			speed = 0;
		} 
		if (paddlePos.x > xBound) {
			paddlePos = new Vector3(xBound, paddlePos.y, paddlePos.z);
			speed = 0;
		}

		transform.position = paddlePos;

	}

	void OnCollisionEnter2D(Collision2D collision){
		audio.Play ();
	}
}
