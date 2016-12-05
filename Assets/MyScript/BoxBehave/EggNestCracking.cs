using UnityEngine;
using System.Collections;

public class EggNestCracking : MonoBehaviour {
	public float angle;
	public int index;
	public GameObject crack;
	public GameObject player;
	void Start(){
	}

	void Update(){
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
			newCrack.transform.rotation = Quaternion.Euler(new Vector3 (0,0, -Vector3.Angle (transform.position, points[0].point)));
			newCrack.transform.position = new Vector3 (points[0].point.x, points[0].point.y, 0);
			newCrack.transform.parent = transform;
			GetComponent<AudioSource> ().Play ();
		}
	}

}
