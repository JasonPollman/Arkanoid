using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class BallScript : MonoBehaviour {

	public bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;
	public GameObject playerObject;

	// Use this for initialization
	void Start () {

		ballIsActive = false;
		ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown(KeyCode.S) == true) {

			if (!ballIsActive){

				rigidbody2D.isKinematic = false;
				rigidbody2D.AddForce(GameVars.getBallForce * rigidbody2D.mass);

				ballIsActive = !ballIsActive;
			}
		}
		
		if (!ballIsActive && playerObject != null){

			ballPosition.x = playerObject.transform.position.x;
			transform.position = ballPosition;
		}
		
		// Check if ball falls
		if (ballIsActive && transform.position.y < -7.43) {
			ballIsActive = !ballIsActive;
			ballPosition.x = playerObject.transform.position.x;
			ballPosition.y = playerObject.transform.position.y + .37f;
			transform.position = ballPosition;			
			rigidbody2D.isKinematic = true;
			audio.Play();

			GameVars.ballsLeft--;
			if(GameVars.IsGameOver()) {
				Application.LoadLevel("GameOver");
			}
		}
		
	}
}
