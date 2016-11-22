using UnityEngine;
using System.Collections;

public class TriggerPoint : MonoBehaviour {
	public GameObject TextBar;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "box") {
			TextBar.GetComponent<BridgeMoveManager> ().ifstart = true;
		}
	}
}
