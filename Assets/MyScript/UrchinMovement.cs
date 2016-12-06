using UnityEngine;
using System.Collections;

public class UrchinMovement : MonoBehaviour {

	private Collider2D target;
	public float force;
	Rigidbody2D r;
	float gravity;
	// Use this for initialization
	void Awake () {
		r = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
		gravity = r.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		if (GetComponent<SpringJoint2D> () != null) {
			GetComponent<LineRenderer> ().SetVertexCount (2);
			GetComponent<LineRenderer> ().SetPosition (0, target.transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, transform.position);
		} else {
			GetComponent<LineRenderer> ().SetVertexCount (0);
		}
	}

	void Move(){
		if (r.velocity.magnitude <= (r.velocity.normalized * force).magnitude) {
			Vector2 ForceToAdd = ((target.transform.position - transform.position)).normalized * force;
			r.AddForce(ForceToAdd);
		}
		if (transform.position.y > 25) {
			r.gravityScale = 5;
		} else {
			r.gravityScale = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Player") {
				SpringJoint2D s = gameObject.AddComponent<SpringJoint2D> ();
				s.connectedBody = col.collider.attachedRigidbody;
				s.breakForce = 50;
		}
	}

//	void OnCollisionStay2D(Collision2D col){
//		if (col.gameObject.tag == "Egg") {
//			r.gravityScale = 0;
//			force = 25;
//		}
//	}
//
//	void OnCollisionExit2D(Collision2D col){
//			r.gravityScale = gravity;
//	}
//		
}
