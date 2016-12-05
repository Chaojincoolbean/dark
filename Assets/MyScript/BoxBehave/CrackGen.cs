using UnityEngine;
using System.Collections;

public class CrackGen : MonoBehaviour {
	public float angle;
	public int index;
	public GameObject crack;
	public GameObject player;
	private int cracks;
	void Start(){
	}

	void Update(){
	}
		

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "wall") {
			player.GetComponent<Control> ().controlOff = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		ContactPoint2D[] points = col.contacts;

		if (col.gameObject.tag == "wall") {
			player.GetComponent<Control> ().controlOff = false;
		}

		if (col.relativeVelocity.y < -20 && col.gameObject.tag == "wall") {
			GameObject newCrack = (GameObject)Instantiate(crack, transform.position, transform.rotation); // Vector3.Angle (transform.position, player.transform.position));
			newCrack.transform.rotation = Quaternion.Euler(new Vector3 (0,0, -Vector3.Angle (transform.position, player.transform.position)));
			newCrack.transform.position = new Vector3 (points[0].point.x, points[0].point.y, 0);
			newCrack.transform.parent = transform;
			player.GetComponent<DisablePlayerControl> ().StartCoroutine ("DisableControl", 3);
//			GetComponent<AudioSource> ().Play ();
		}

		CheckAmountofCracks ();
	}

	void CheckAmountofCracks(){
		if (cracks > 2) {
			foreach (Transform t in transform.GetComponentsInChildren<Transform>()) {
				
			}
		}
	}
}
