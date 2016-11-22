using UnityEngine;
using System.Collections;

public class HitBox : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "box" && collider.relativeVelocity.magnitude >= 1.0f) {
			collider.gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
