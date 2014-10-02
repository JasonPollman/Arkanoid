using UnityEngine;
using System.Collections;

public class YellowBrickUpgrade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		GameObject ball = GameObject.Find ("Ball");
		ball.rigidbody2D.AddForce(new Vector3 (5000, 5000, 5000));
	}
}
