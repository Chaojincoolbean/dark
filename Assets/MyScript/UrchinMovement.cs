using UnityEngine;
using System.Collections;

public class UrchinMovement : MonoBehaviour {

	private Collider2D target;
	public float force;
	Rigidbody2D r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		Vector2 ForceToAdd = (((target.bounds.extents + target.transform.position) - transform.position)).normalized * force;
		r.AddForce (ForceToAdd);	
	}

	public void OnTriggerEnter2D(Collider2D col){
			r.gravityScale = 0;
	}

	public void OnTriggerExit2D(Collider2D col){
			r.gravityScale = 1;
	}
}
