using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public float moveSpeed;
    public float BackOff;

	private float touchedWalls;

    private Rigidbody2D m_rigidbody;
    private Vector2 MoveDirct;
	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }

	public void OnTriggerEnter(Collider col){
		if (col.tag == "wall") {
			touchedWalls ++;
		}
		if (touchedWalls > 1) {
			gameObject.layer = 10;
		}
	}

	public void OnTriggerExit(Collider col){
		if (col.tag == "wall") {
			touchedWalls --;
		}
		gameObject.layer = 8;
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
