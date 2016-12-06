using UnityEngine;
using System.Collections;

public class LeafBehaviour : MonoBehaviour {

	bool activated = false;
	float offset;
	// Use this for initialization
	void Start () {
		offset = Random.Range(0.0f, 2 * Mathf.PI);
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			GetComponent<Rigidbody2D> ().AddTorque (Mathf.Cos (offset + Time.deltaTime * 100) * 5);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Sin (Time.deltaTime), 0));
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			gameObject.layer = 11;
		}
	}
}
