using UnityEngine;
using System.Collections;

public class FormingSysmbol : MonoBehaviour {
	public bool ifStart;

	private float alpha;
	// Use this for initialization
	void Start () {
		alpha = 0.0f;
		ifStart = false;
		GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (ifStart) {
			alpha += 0.001f;
			GetComponent<SpriteRenderer> ().color += new Color (0, 0, 0, alpha);
		}
	}
}
