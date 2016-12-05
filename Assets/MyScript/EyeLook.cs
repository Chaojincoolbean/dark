using UnityEngine;
using System.Collections;

public class EyeLook : MonoBehaviour {

	public GameObject pupil;
	Collider2D eyeCol;
	Rigidbody2D r;
	Collider2D c;
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		c = GetComponent<Collider2D> ();
		eyeCol = pupil.GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		SetEyePos ();
	}

	void SetEyePos(){
		pupil.transform.localPosition = Vector3.Lerp(pupil.transform.localPosition, 
			new Vector3(
				Mathf.Clamp(Input.GetAxis("Horizontal"), -c.bounds.extents.x + eyeCol.bounds.extents.x, c.bounds.extents.x - eyeCol.bounds.extents.x), 
				Mathf.Clamp(-Input.GetAxis("Vertical"), -c.bounds.extents.y + eyeCol.bounds.extents.y, c.bounds.extents.y - eyeCol.bounds.extents.y), 0), 
				Time.deltaTime * 5);
	}
}
