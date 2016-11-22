using UnityEngine;
using System.Collections;

public class MoveBridge : MonoBehaviour {
	public bool ifStart;
	public float Speed;
	// Use this for initialization
	void Start () {
		ifStart = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ifStart) {
			Move ();
			if (Vector3.Distance (transform.position, transform.parent.position) <= 0.01f) {
				transform.position = transform.parent.position;
				ifStart = false;
			}
		}
	}

	void Move ()
	{
		transform.localPosition = Vector3.Lerp (transform.localPosition, Vector3.zero, Time.deltaTime*Speed);
	}
}
