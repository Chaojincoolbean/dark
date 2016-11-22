using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    public float moveSpeed;
    public float BackOff;

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
