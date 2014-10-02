using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		audio.Play ();
		GameObject ball = GameObject.Find ("Ball");

		if (ball.rigidbody2D.velocity.y > -GameVars.maxBallVelocity) {
			ball.rigidbody2D.AddForce (new Vector3 (0, -100, 100));
		}

	}
}
