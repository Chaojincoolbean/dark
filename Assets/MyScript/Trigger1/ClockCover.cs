using UnityEngine;
using System.Collections;

public class ClockCover : MonoBehaviour {
	public GameObject tree;
	public bool ifPulse;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player" && tree.GetComponent<TriggerTree>().ifReady) {
			tree.GetComponent<SpriteRenderer> ().enabled = true;
			tree.GetComponent<TriggerTree> ().ifComplete = true;
		}
	}
}
