using UnityEngine;
using System.Collections;

public class EyeFollow : MonoBehaviour {

	private Transform target;
	private Transform pupil;
	Vector3 originalPosition;
	Collider2D eyeCol;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		pupil = transform.GetChild(0);

		eyeCol = pupil.GetComponent<Collider2D> ();
		originalPosition = pupil.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		SetEyePos ();
	}

	void SetEyePos(){

		// first, find the distance from the center of the eye to the target var distanceToTarget : Vector3 = target.transform.position - eye.transform.position;

		Vector3 distance = target.position - pupil.transform.position;
		// clamp the distance so it never exceeds the size of the eyeball distanceToTarget = Vector3.ClampMagnitude( distanceToTarget, eyeRadius );

		distance = Vector3.ClampMagnitude(distance, GetComponent<Collider2D>().bounds.extents.x - eyeCol.bounds.extents.x);
		// place the pupil at the desired position relative to the eyeball var finalPupilPosition : Vector3 = eye.transform.position + distanceToTarget; pupil.transform.position = finalPupilPosition; 

		Vector3 finalPos =  originalPosition + distance; 
		pupil.position = finalPos;
	}
}
