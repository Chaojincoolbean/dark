using UnityEngine;
using System.Collections;

public class EyeOpen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.GetChild(0).localScale = new Vector3 (1, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			StartCoroutine (Open ());
		}
	}

	IEnumerator Open(){
		float t = 0;

		while (t <= 1) {
			t += Time.deltaTime * 10;
			transform.GetChild(0).localScale = new Vector3 (1, Mathf.SmoothStep(0, 1, t), 1);
			yield return null;
		}
	}

	public void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			StartCoroutine (Close ());
		}
	}

	IEnumerator Close(){
		float t = 0;

		while (t <= 1) {
			t += Time.deltaTime * 10;
			transform.GetChild(0).localScale = new Vector3 (1, Mathf.SmoothStep(1, 0, t), 1);
			yield return null;
		}
	}
}
