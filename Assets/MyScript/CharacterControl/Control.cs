using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {
    public float moveSpeed;
    public float BackOff;
	public bool controlOff;
	public GameObject Egg;
	public Collider2D EggCollider;
	private Collider2D c;
    private Rigidbody2D r;
    private Vector2 MoveDirct;
	private bool outsideBounds;
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider2D> ();
        r = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
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

    public void Move()
    {
		controlOff = false;

		if (Egg.GetComponent<Rigidbody2D>().velocity.y < -2) {
			controlOff = true;
		}

		//Finds the furthest point away from the center of the egg on the player eyeball
		Vector3 positiontoEgg= transform.position - EggCollider.bounds.center;
		Vector3 otherSide = transform.position + positiontoEgg;
		Vector3 furthestPoint = c.bounds.ClosestPoint(otherSide);

		//if the Egg trigger does not contain this point it moves the egg towards the player
		if (!EggCollider.bounds.Contains (furthestPoint)) {
		
			MoveDirct = (furthestPoint - EggCollider.bounds.center) * BackOff;
			Egg.GetComponent<Rigidbody2D> ().AddForce (MoveDirct * moveSpeed);
			StartCoroutine(Blink());
		}

		//let the player move the eye if the egg is not falling and no point of the eye is outside the egg
		if (!controlOff) {
			transform.position = Vector3.Lerp (transform.position,
				new Vector3 (
					Mathf.Clamp (transform.position.x + Input.GetAxis ("Horizontal"), EggCollider.bounds.center.x - (EggCollider.bounds.extents.x - c.bounds.extents.x), EggCollider.bounds.center.x + (EggCollider.bounds.extents.x - c.bounds.extents.x)), 
					Mathf.Clamp (transform.position.y + Input.GetAxis ("Vertical"), EggCollider.bounds.center.y - (EggCollider.bounds.extents.y - c.bounds.extents.y), EggCollider.bounds.center.y + (EggCollider.bounds.extents.y - c.bounds.extents.y)), 0),
				Time.deltaTime * 10);

			Egg.GetComponent<Rigidbody2D> ().AddForceAtPosition (new Vector2(Input.GetAxis("Horizontal"), 0) * moveSpeed, transform.position);
			Egg.GetComponent<Rigidbody2D> ().AddForce(new Vector2(0, Input.GetAxis("Vertical") * moveSpeed * 2));
		}else{
			//if Control is off recenter the eye in the egg
			transform.position = Vector3.Lerp (transform.position, EggCollider.bounds.center - c.bounds.extents, Time.deltaTime * 50);
		}
    }

	IEnumerator Blink(){
		float t = 0;

		while (t <= Mathf.PI) {
			float size = Mathf.Cos (t);
			transform.localScale = new Vector3 (1, size, 1);
			t += Time.deltaTime * 15;
			yield return null;
		}
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
