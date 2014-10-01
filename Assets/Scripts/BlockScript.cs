using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BlockScript : MonoBehaviour {
	
	public int hitsToKill;
	public int points;
	public string color;
	public string upgrade;
	private int numberOfHits;

	public AudioClip collideSound;

	// Use this for initialization
	void Start () {
		numberOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {		
	}

	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball"){
			numberOfHits++;
			AudioSource.PlayClipAtPoint(collideSound, transform.position);
			
			if (numberOfHits == hitsToKill){
				GameVars.score += points;

				if(color != "Purple" && color != "Gray") {
					GameVars.bricksLeft--;
				}

				Destroy(this.gameObject);

				if(GameVars.LevelWon ()) {
				}
			}
		}
	}
}
