using UnityEngine;
using System.Collections;

public class ScoreScriptGO : MonoBehaviour {

	UILabel score;
	
	// Use this for initialization
	void Start () {
		score = GameObject.Find("Score").GetComponent<UILabel>();

		string pad = "";
		for (int i = 0; i < (14 - GameVars.score.ToString().Length); i++) {
			pad += "0";
		}
		
		score.text = pad + GameVars.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
