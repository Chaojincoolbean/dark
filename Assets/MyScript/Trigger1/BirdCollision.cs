using UnityEngine;
using System.Collections;

public class BirdCollision : MonoBehaviour {
	public Color originalColor;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
		}
	}
}
