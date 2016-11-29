using UnityEngine;
using System.Collections;

public class Wall_Detection : MonoBehaviour {

	public AudioClip audio;
	public int ind;
	// Use this for initialization
	void Start () {
	}
		

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player" && collision.relativeVelocity.magnitude >= 1.0f) {
		}
	}

	void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.tag == "wall") {
			gameObject.layer = 10;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		gameObject.layer = 8;
		}
}
