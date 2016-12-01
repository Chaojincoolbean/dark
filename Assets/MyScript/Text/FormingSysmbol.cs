using UnityEngine;
using System.Collections;

public class FormingSysmbol : MonoBehaviour {
	public bool ifStart;

	private float alpha;
	private Vector3 destination, origin;
	// Use this for initialization
	void Start () {
		origin = transform.position;
		destination = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z);
		alpha = 0.0f;
		ifStart = false;
		GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (ifStart) {
			alpha += Time.deltaTime;
			GetComponent<SpriteRenderer> ().color += new Color ( Time.deltaTime, 0, 0, alpha);
			transform.position = Vector3.Lerp (origin, destination, alpha);
		}
	}
}
