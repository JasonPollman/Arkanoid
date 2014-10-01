using UnityEngine;
using System.Collections;

public static class GameVars {

	public static int ballsLeft  = 3;
	public static int score 	 = 0;
	public static int level		 = 1;
	public static int bricksLeft = 0;

	public static Vector3 ballForce = new Vector2 (Random.Range (-400, 401),900.0f);


	public static AddBricks root;


	public static int GetBricksPerLevel() {

		switch (GameVars.level) {

			case (1): return 40;
			default: return ((GameVars.level * 2 + 40) > 80 ? 80 : (GameVars.level * 2 + 40));
		}
	}


	public static bool IsGameOver() {
		return (ballsLeft < 0 ? true : false);
	}

	public static bool LevelWon() {
		return (bricksLeft < 0 ? true : false);
	}

	public static void LevelUp () {
		ballForce.y += 50;
		level++;
		root.init();
	}


	public static void ResetVars() {
		ballsLeft  = 3;
		score      = 0;
		level      = 1;
		bricksLeft = 0;
	}
}