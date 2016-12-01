using UnityEngine;
using System.Collections;

public class RotateWithPlayer : MonoBehaviour {
	public GameObject playerBox;

	private Quaternion OriginRotation;
	// Use this for initialization
	void Start () {
		OriginRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler(OriginRotation.eulerAngles + playerBox.transform.rotation.eulerAngles);

		if (transform.eulerAngles.z >= 360.0f)
			transform.rotation = Quaternion.Euler(transform.eulerAngles - Vector3.forward * 360.0f);
		if (transform.eulerAngles.z <= 0.0f)
			transform.rotation = Quaternion.Euler(transform.eulerAngles + Vector3.forward * 360.0f);

		if (transform.rotation.eulerAngles.z <= 0.0f + 1.0f || transform.rotation.eulerAngles.z >= 360.0f - 1.0f) {
		}
	}
}
