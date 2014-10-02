using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BlockScript : MonoBehaviour {
	
	public int hitsToKill;
	public int points;
	public string color;
	public string upgrade;
	public Sprite crackedSprite;
	public Sprite crackedSprite2;
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

	   SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
	   if(color != "Gray") spriteRenderer.sprite = crackedSprite;

		if (collision.gameObject.tag == "Ball"){

			GameObject ball = GameObject.Find ("Ball");
			if (ball.rigidbody2D.velocity.y > -GameVars.maxBallVelocity) {
				ball.rigidbody2D.AddForce (new Vector3 (0, -50, 50));
			}

			numberOfHits++;
			AudioSource.PlayClipAtPoint(collideSound, transform.position);

			if(numberOfHits >= 2 && color != "Gray") {
				spriteRenderer.sprite = crackedSprite2;
			}
			
			if (numberOfHits == hitsToKill){
				GameVars.score += points;

				if(color != "Purple" && color != "Gray") {
					GameVars.bricksLeft--;
				}

				if(GameVars.LevelWon ()) {
					GameVars.LevelUp();
				}
				else {
					Destroy(this.gameObject);
				}
			}
		}
	}
}
