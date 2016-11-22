using UnityEngine;
using System.Collections;

public class DisablePlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			collider.gameObject.GetComponent<Control> ().enabled = false;
		}
	}
}
