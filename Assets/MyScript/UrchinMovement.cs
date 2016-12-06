using UnityEngine;
using System.Collections;

public class UrchinMovement : MonoBehaviour {

	private Collider2D target;
	public float force;
	Rigidbody2D r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
//		Move ();
		if (GetComponent<SpringJoint2D> () != null) {
			GetComponent<LineRenderer> ().SetVertexCount (2);
			GetComponent<LineRenderer> ().SetPosition (0, target.transform.position);
			GetComponent<LineRenderer> ().SetPosition (1, transform.position);
		} else {
			GetComponent<LineRenderer> ().SetVertexCount (0);
		}
	}

	void Move(){
		if ((r.velocity.normalized * force).magnitude < r.velocity.magnitude) {
			Vector2 ForceToAdd = ((target.transform.position - transform.position)).normalized * force;
			r.AddForce (ForceToAdd);	
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.GetComponent<Control> ().cracked) {
				SpringJoint2D s = gameObject.AddComponent<SpringJoint2D> ();
				s.connectedBody = col.collider.attachedRigidbody;
				s.breakForce = 100;
				r.gravityScale = 1;
			}
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.layer == 0) {
			if ( r.velocity.magnitude <= (r.velocity.normalized * force).magnitude) {
				Vector2 ForceToAdd = ((target.transform.position - transform.position)).normalized * force;
				r.AddForce (ForceToAdd);	
				r.gravityScale = 0;
			}
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.layer == 0) {
			r.gravityScale = 1;
		}
	}

//	public void OnTriggerExit2D(Collider2D col){
//			r.gravityScale = 1;
//	}
}
