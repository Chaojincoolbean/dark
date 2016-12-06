using UnityEngine;
using System.Collections;

public class LeafBehaviour : MonoBehaviour {

	bool activated = false;
	float offset;
	float scale;
	// Use this for initialization
	void Start () {
		scale = transform.localScale.x;
		offset = Random.Range(0.0f, 2 * Mathf.PI);
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			transform.localScale = new Vector3 (Mathf.Sin (Time.time + offset * 10) * scale, scale, scale);
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Mathf.Sin (Time.deltaTime), 0));
		}
	}

	public void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			gameObject.layer = 11;
			GetComponent<Collider2D> ().isTrigger = false;
			activated = true;
		}
	}
}
