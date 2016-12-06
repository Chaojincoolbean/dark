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
		if (GetComponent<SpringJoint2D> () != null) {
			GetComponent<LineRenderer> ().SetPosition (0, target.transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, transform.position);
		}
	}

	void Move(){
		Vector2 ForceToAdd = ((target.transform.position - transform.position)).normalized * force;
		r.AddForce (ForceToAdd);	
		r.velocity = r.velocity.normalized * 10;
	}

	public void OnTriggerEnter2D(Collider2D col){
		
		if (col.tag == "Player") {
			SpringJoint2D s = gameObject.AddComponent<SpringJoint2D> ();
			s.connectedBody = col.attachedRigidbody;
			s.breakForce = 50;
		}
	}

	public void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.layer == 0) {
			r.gravityScale = 0;
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.layer == 0) {
			r.gravityScale = 1;
		}
	}

//	public void OnTriggerExit2D(Collider2D col){
//			r.gravityScale = 1;
//	}
}
