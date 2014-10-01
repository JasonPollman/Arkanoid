using UnityEngine;
using System.Collections;

public class LevelIndicator : MonoBehaviour {

	UILabel level;
	
	// Use this for initialization
	void Start () {
		level = GameObject.Find("Level").GetComponent<UILabel>();
		level.text = (GameVars.level >= 10) ? GameVars.level.ToString () : "0" + GameVars.level.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		level = GameObject.Find("Level").GetComponent<UILabel>();
		level.text = (GameVars.level >= 10) ? GameVars.level.ToString () : "0" + GameVars.level.ToString ();
	}
}
