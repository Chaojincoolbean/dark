using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Control : MonoBehaviour {
    public float moveSpeed;
    public float BackOff;

	private List<Collider2D> collidedObjects;
	private float touchedWalls;
	private Collider2D c;
    private Rigidbody2D m_rigidbody;
    private Vector2 MoveDirct;

	// Use this for initialization
	void Start () {
		collidedObjects = new List<Collider2D> ();
		c = GetComponent<Collider2D> ();
        m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

	public void OnTriggerEnter2D(Collider2D col){

		if (col.tag == "wall") {

			string sharedParentName = col.transform.parent.name;
			bool sharedWallFromBox = false;

			//make sure it's not another wall in the box the player is currently in
			foreach (Collider2D c in collidedObjects) {
				if (c.transform.parent.name == sharedParentName) {
					sharedWallFromBox = true;
				}
			}
			if (!sharedWallFromBox) {
				collidedObjects.Add (col);
				touchedWalls++;
			}
		}

		if (touchedWalls > 1) {
			foreach (Collider2D c in collidedObjects) {
				c.gameObject.layer = 10;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D  col){
		
		if (col.tag == "wall") {

			if(collidedObjects.Contains(col)){
				collidedObjects.Remove (col);
				touchedWalls --;
			}
		}

		col.gameObject.layer = 9;
	}
		

    public void Move()
    {
        MoveDirct = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        MoveDirct.Normalize();

        m_rigidbody.AddForce(MoveDirct * moveSpeed);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (MoveDirct == Vector2.zero)
        {
            MoveDirct = -(transform.position - collision.transform.position) * BackOff;
            m_rigidbody.AddForce(MoveDirct * moveSpeed);
        }
    }
}
