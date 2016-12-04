using UnityEngine;
using System.Collections;

public class BirdEye : MonoBehaviour {

	bool on = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
//			&& transform.parent.eulerAngles.z < 2 
			on = true;
			Debug.Log (on);
		}
	}
}
