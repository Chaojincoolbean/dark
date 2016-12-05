using UnityEngine;
using System.Collections;

public class BirdCollision : MonoBehaviour {
	public Color originalColor;


	void Update(){
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			
			collider.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
			StartCoroutine (BendOver ());
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player") {
			collider.gameObject.GetComponent<SpriteRenderer> ().color = originalColor;
		}
	}

	IEnumerator BendOver(){
		yield return null;
	}
}
