using UnityEngine;
using System.Collections;

public class CrackGen : MonoBehaviour {
	public float angle;
	public int index;
	public GameObject crack;
	public GameObject player;
	private int cracks;
	private bool broken = false;
	void Start(){
	}

	void Update(){
		if (broken) {
			int i = 0;
			foreach (SpringJoint2D s in GetComponents<SpringJoint2D>()) {
				GetComponent<LineRenderer> ().SetVertexCount (i + 2);
				GetComponent<LineRenderer> ().SetPosition (i, new Vector3(transform.position.x +  s.anchor.x, transform.position.y + s.anchor.y, 0));
				GetComponent<LineRenderer> ().SetPosition (i + 1, player.transform.position);
				i += 2;
			}

			if (i == 0) {
				Destroy (GetComponent<LineRenderer>());
			}
		}
	}
		

//	void OnCollisionExit2D(Collision2D col){
//		if (col.gameObject.tag == "wall") {
//			player.GetComponent<Control> ().controlOff = true;
//		}
//	}

	void OnCollisionEnter2D(Collision2D col){
		ContactPoint2D[] points = col.contacts;

//		if (col.gameObject.tag == "wall") {
//			player.GetComponent<Control> ().controlOff = false;
//		}

		if (col.relativeVelocity.y < -10 && col.gameObject.tag == "wall") {
			GameObject newCrack = (GameObject)Instantiate(crack, transform.position, transform.rotation); // Vector3.Angle (transform.position, player.transform.position));
			newCrack.transform.rotation = Quaternion.Euler(new Vector3 (0,0, -Vector3.Angle (transform.position, player.transform.position)));
			newCrack.transform.position = new Vector3 (points[0].point.x, points[0].point.y, 0);
			newCrack.transform.parent = transform;
			GetComponent<AudioSource> ().Play ();
			cracks++;

			if(!broken){
				CheckAmountofCracks ();
			}
		}
	}

	void CheckAmountofCracks(){
		player.GetComponent<Control> ().StartCoroutine ("CloseEye");

		if (cracks > 3) {
			broken = true;
			StartCoroutine (player.GetComponent<Control> ().StartFlying ());
			GetComponent<LineRenderer> ().SetPosition (0, player.transform.position); 

			int i = 0;

			foreach (SpringJoint2D s in GetComponents<SpringJoint2D>()) {
				i += 2;
				s.enabled = true;
				GetComponent<LineRenderer> ().SetVertexCount (i);
			}
		}
	}
}
