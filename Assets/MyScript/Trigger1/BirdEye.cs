using UnityEngine;
using System.Collections;

public class BirdEye : MonoBehaviour {

	bool on = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
//			&& transform.parent.eulerAngles.z < 2 
			StartCoroutine(Blink());

			if(col.OverlapPoint(transform.position)){
				StartCoroutine (FlyUp ());
			}
		}
	}

	IEnumerator Blink (){
		float t = 0;

		while (t <= Mathf.PI){
			float scale = Mathf.Abs (Mathf.Cos (t));
			transform.localScale = new Vector3(1, scale, scale);
			t += Time.deltaTime * 10;
			yield return null;
		}
	}

	IEnumerator FlyUp(){
		yield return null;
	}
}
