using UnityEngine;
using System.Collections;

public class GameVars {

	public static int ballsLeft  = 3;
	public static int score 	 = 0;
	public static int level		 = 1;
	public static int bricksLeft = 0;

	public static int minimumBricks = 10;
	public static int maximumBricks = 80;
	public static int ballSpeedupOnLevel = 100;

	public static float paddleTiltMax = .10f;
	public static float paddleTiltSpeed = .5f;
	
	public static int maxBallVelocity {

		get { return ((level * 10 > 20) ? 20 : level * 10); }
	}

	public static Vector3 ballForce = new Vector3 (GameObject.Find("PlayerPaddle").transform.localRotation.z, 400.0f, 0);

	public static Vector3 getBallForce {
		get {
			ballForce = new Vector3 (GameObject.Find("PlayerPaddle").transform.localRotation.z * -4000, 400.0f, 0);
			return ballForce;
		}
	}


	private static GameObject rootUI = GameObject.Find("UI Root (2D)");
	private static AddBricks root = (AddBricks) rootUI.GetComponent(typeof(AddBricks));


	public static int GetBricksPerLevel() {

		switch (GameVars.level) {

			case (1): return minimumBricks;
			default: return ((GameVars.level * 2 + minimumBricks) > maximumBricks ? maximumBricks : (GameVars.level * 2 + minimumBricks));
		}
	}


	public static bool IsGameOver() {
		return (ballsLeft < 0 ? true : false);
	}
	 
	public static bool LevelWon() {
		Debug.Log (bricksLeft);
		return (bricksLeft <= 0 ? true : false);
	}

	public static void LevelUp () {

		ballForce.y += ((ballSpeedupOnLevel > maxBallVelocity) ? maxBallVelocity : ballSpeedupOnLevel);
		level++;
		root.init();

		GameObject ball = GameObject.Find ("Ball");
		BallScript bs = (BallScript) ball.GetComponent (typeof(BallScript));

		GameObject playerObject = GameObject.Find ("PlayerPaddle");
		bs.ballIsActive = false;
		ball.rigidbody2D.isKinematic = true;

		Vector3 ballPosition = ball.transform.position;
		ballPosition.x = playerObject.transform.position.x;
		ballPosition.y = playerObject.transform.position.y + .37f;
	}

	public static void ResetVars() {
		ballsLeft  = 3;
		score      = 0;
		level      = 1;
		bricksLeft = 0;
	}
}