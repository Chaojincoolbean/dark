using UnityEngine;
using System.Collections;

public class TriggerFree : MonoBehaviour {
	public GameObject player;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "box") {
//			player.GetComponent<Control> ().moveSpeed = 10.0f;
			Destroy (collider.gameObject);
		}
	}
}
