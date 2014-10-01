using UnityEngine;
using System.Collections;

public class AddBricks : MonoBehaviour {

	public GameObject[] bricks;

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

		GameObject startBrick = GameObject.Find("StartBrick");
		float posX = startBrick.transform.position.x;
		float posY = startBrick.transform.position.y;

		int yellowBricks = 0, grayBricks = 0, purpleBricks = 0, redBricks = 0, blueBricks = 0;

		GameVars.bricksLeft = 0;

		for (int i = 0; i < GameVars.GetBricksPerLevel(); i++) {

			int rand = Random.Range(0, bricks.Length);

			Debug.Log (GameVars.level.ToString() + " LEVEL");

			if(rand == 0) grayBricks++;
			if(rand == 1) purpleBricks++;
			if(rand == 2) yellowBricks++;
			if(rand == 3) redBricks++;
			if(rand == 4) blueBricks++;

			if(rand == 0 && grayBricks >= (GameVars.level * 2)) {
				rand = Random.Range(1, bricks.Length);
			}

			if(rand == 2 && purpleBricks >= 1) {
				rand = Random.Range(2, bricks.Length);
			}

			if(rand == 1 && yellowBricks >= (GameVars.level * 2)) {
				rand = Random.Range(3, bricks.Length);
			}

			if(rand == 3 && redBricks >= (GameVars.level * 3)) {
				rand = Random.Range(4, bricks.Length);
			}

			if(rand == 4 && blueBricks >= (GameVars.level * 6)) {
				rand = 5;
			}

			Debug.Log (rand);

			if(rand != 0 || rand != 1) {
				GameVars.bricksLeft++;
			}

			posX += 2;

			if(posX >= 10) {
				posX = startBrick.transform.position.x;
				posY--;
			}

			Instantiate(bricks[rand], new Vector3(posX, posY, 0), Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
