using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class BallScriptGO : MonoBehaviour {

	private bool    ballIsActive;
	private Vector2 ballInitialForce;

	public GameObject playerObject;
	// Use this for initialization
	void Start () {
		// create the force
		ballInitialForce = new Vector3 (400, 400, 100);
		
		// set to inactive
		ballIsActive = false;
	}
	
	// Update is called once per frame
	void Update () {

		// check if is the first play
		if (!ballIsActive){
			// reset the force
			rigidbody2D.isKinematic = false;
			
			// add a force
			rigidbody2D.AddForce(ballInitialForce);
			
			// set ball active
			ballIsActive = !ballIsActive;
		}
		
	}
}
