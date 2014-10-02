using UnityEngine;
using System.Collections;

public class AddBricks : MonoBehaviour {

	public GameObject[] bricks;
	public static bool canPause = true;

	// Use this for initialization
	void Start () {
		init ();
	}

	public void init() {

		// 0 - Gray
		// 1 - Purple
		// 2 - Yellow

		GameObject[] oldBricks = GameObject.FindGameObjectsWithTag("Brick");
		for(int i = 0; i < oldBricks.Length; i++) {
			Destroy(oldBricks[i]);
		}

		float posX = 0;
		float posY = 5.15f;

		GameVars.bricksLeft = 0;

		int yellowBricks = 0, grayBricks = 0, purpleBricks = 0, redBricks = 0, blueBricks = 0;

		bool flopX = false;
		int posSum = 0;
		for (float i = -4.75f; i < GameVars.GetBricksPerLevel(); i++) {

			int rand = Random.Range(0, bricks.Length);


			if(rand == 0 && grayBricks >= (GameVars.level * 2)) {
				rand = Random.Range(1, bricks.Length);
			}

			if(rand == 1 && purpleBricks >= 1) {
				rand = Random.Range(2, bricks.Length);
			}

			if(rand == 2 && yellowBricks >= (GameVars.level * 1)) {
				rand = Random.Range(3, bricks.Length);
			}

			if(rand == 3 && redBricks >= (GameVars.level * 2)) {
				rand = Random.Range(4, bricks.Length);
			}

			if(rand == 4 && blueBricks >= (GameVars.level * 3)) {
				rand = 5;
			}

			if(rand == 0) grayBricks++;
			if(rand == 1) purpleBricks++;
			if(rand == 2) yellowBricks++;
			if(rand == 3) redBricks++;
			if(rand == 4) blueBricks++;

			if(rand != 0 && rand != 1) {
				GameVars.bricksLeft++;
			}

			Instantiate(bricks[rand], new Vector3(posX, posY, 0), Quaternion.identity);

			posSum += 2;

			if(!flopX) {
				posX += -posSum;
				flopX = true;
			}
			else {
				posX += posSum;
				flopX = false;
			}


			if(posX >= 10 || posX <= -10) {
				posSum = 0;
				posX = 0;
				posY--;
			}
		

		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("return")) {
			if(canPause) {
				Time.timeScale = 0;
				canPause = false;
			}
			else {
				Time.timeScale = 1;
				canPause = true;
			}
		}
	}
}
