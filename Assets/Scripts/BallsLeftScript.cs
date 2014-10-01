using UnityEngine;
using System.Collections;

public class BallsLeftScript : MonoBehaviour {

	UILabel ballsLeft;
	
	// Use this for initialization
	void Start () {
		ballsLeft = GameObject.Find("BallsLeft").GetComponent<UILabel>();
		ballsLeft.text = (GameVars.ballsLeft >= 10) ? GameVars.ballsLeft.ToString () : "0" + GameVars.ballsLeft.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		ballsLeft = GameObject.Find("BallsLeft").GetComponent<UILabel>();
		ballsLeft.text = (GameVars.ballsLeft >= 10) ? GameVars.ballsLeft.ToString () : "0" + GameVars.ballsLeft.ToString ();
	}

}
