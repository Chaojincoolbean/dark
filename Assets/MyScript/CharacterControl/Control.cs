using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {
    public float moveSpeed;
    public float BackOff;
	public bool controlOff = false;
	public GameObject Egg;
	public Collider2D EggCollider;
	private bool outsideBounds;
	public bool cracked = false;
	public GameObject wings;

	public float interval;

	public Animator wingFlapper;
	float timer;

	private Collider2D c;
	private Rigidbody2D r;
	private Vector2 MoveDirct;
	// Use this for initialization
	void Start () {
		timer = interval;
		c = GetComponent<Collider2D> ();
        r = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!cracked) {
			Move ();
		} else {
			Fly ();
		}
    }

//	public void OnTriggerEnter2D(Collider2D col){
//
//		if (col.tag == "wall") {
//
//			string sharedParentName = col.transform.parent.name;
//			bool sharedWallFromBox = false;
//
//			//make sure it's not another wall in the box the player is currently in
//			foreach (Collider2D c in collidedObjects) {
//				if (c.transform.parent.name == sharedParentName) {
//					sharedWallFromBox = true;
//				}
//			}
//			if (!sharedWallFromBox) {
//				collidedObjects.Add (col);
//				touchedWalls++;
//			}
//		}
//
//		if (touchedWalls > 1) {
//			foreach (Collider2D c in collidedObjects) {
//				c.gameObject.layer = 10;
//			}
//		}
//	}

//	public void OnTriggerExit2D(Collider2D  col){
//		
//		if (col.tag == "wall") {
//
//			if(collidedObjects.Contains(col)){
//				collidedObjects.Remove (col);
//				touchedWalls --;
//			}
//		}
//
//		col.gameObject.layer = 9;
//	}
//		

	public void Fly(){

		r.AddForce (new Vector2 (Input.GetAxis ("Horizontal") * moveSpeed * 3, Input.GetAxis("Vertical") * moveSpeed * 3));

		if (Input.GetButtonDown ("Fire") && timer < 0) {
			wingFlapper.SetTrigger ("ButtonPress");
			r.AddForce (new Vector2(0, moveSpeed * 50));
			timer = interval;
		} else {
			timer -= Time.deltaTime;
		}
	}
    
	public void Move()
    {

		if (Egg.GetComponent<Rigidbody2D>().velocity.y < -5 || controlOff) {
			transform.position = new Vector3 (EggCollider.bounds.center.x, EggCollider.bounds.center.y - c.bounds.extents.y/2, 0);
		}

		//Finds the furthest point away from the center of the egg on the player eyeball
		Vector3 positiontoEgg= transform.position - EggCollider.bounds.center;
		Vector3 otherSide = transform.position + positiontoEgg;
		Vector3 furthestPoint = c.bounds.ClosestPoint(otherSide);

		//if the Egg trigger does not contain this point it moves the egg towards the player
		if (!EggCollider.bounds.Contains (furthestPoint)) {
		
//			MoveDirct = (furthestPoint - EggCollider.bounds.center) * BackOff;
//			Egg.GetComponent<Rigidbody2D> ().AddForce (MoveDirct * moveSpeed);
			StartCoroutine(Blink());
		}

		//let the player move the eye if the egg is not falling and no point of the eye is outside the egg
		if (!controlOff) {
			transform.position = Vector3.Lerp (transform.position,
				new Vector3 (
					Mathf.Clamp (transform.position.x + Input.GetAxis ("Horizontal"), EggCollider.bounds.center.x - (EggCollider.bounds.extents.x - c.bounds.extents.x), EggCollider.bounds.center.x + (EggCollider.bounds.extents.x - c.bounds.extents.x)), 
					Mathf.Clamp (transform.position.y + Input.GetAxis ("Vertical"), EggCollider.bounds.center.y - (EggCollider.bounds.extents.y - c.bounds.extents.y), EggCollider.bounds.center.y + (EggCollider.bounds.extents.y - c.bounds.extents.y)), 0),
				Egg.GetComponent<Rigidbody2D> ().velocity.magnitude / 10);

			Egg.GetComponent<Rigidbody2D> ().AddForceAtPosition (new Vector2 (Input.GetAxis ("Horizontal"), 0) * moveSpeed, transform.position);
			Egg.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, Input.GetAxis ("Vertical") * moveSpeed * 2));
		}
    }

	public IEnumerator Blink(){
		float t = 0;

		while (t <= Mathf.PI) {
			float size = Mathf.Abs(Mathf.Cos (t));
			transform.localScale = new Vector3 (1, size, 1);
			t += Time.deltaTime * 15;

			yield return null;
		}
	}

	public IEnumerator CloseEye(){

		controlOff = true;

		transform.localScale = new Vector3 (0, 0, 0);
		yield return new WaitForSeconds (2);
		float t = 0;

		while (t <= Mathf.PI/2) {
			float size = Mathf.Sin (t);
			transform.localScale = new Vector3 (1, size, 1);
			t += Time.deltaTime * 5;
			yield return null;
		}

		controlOff = false;
	}

	public IEnumerator StartFlying(){


		float t = 0;
		yield return new WaitForSeconds (3);

		while (t < 1) {
			t += Time.deltaTime;
			yield return null;
		}
			
		cracked = true;
		GetComponent<TrailRenderer> ().enabled = true;
		r.isKinematic = false;
		wings.SetActive (true);
	}

//    void OnCollisionStay2D(Collision2D collision)
//    {
//        if (MoveDirct == Vector2.zero)
//        {
//            MoveDirct = -(transform.position - collision.transform.position) * BackOff;
//            m_rigidbody.AddForce(MoveDirct * moveSpeed);
//        }
//    }

//	void OnTriggerExit2D(Collider2D col){
//		if (col.name == "EggCollider") {
//			MoveDirct = -(transform.position - col.transform.position) * BackOff;
//			m_rigidbody.AddForce (MoveDirct * moveSpeed);
//			Egg.GetComponent<Rigidbody2D> ().AddForce (-MoveDirct * moveSpeed);
//		}
//	}
}
