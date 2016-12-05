using UnityEngine;
using System.Collections;

public class LeafBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			gameObject.layer = 12;
		}
	}
}
