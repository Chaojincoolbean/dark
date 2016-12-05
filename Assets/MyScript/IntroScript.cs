using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

	public GameObject cam;
	// Use this for initialization
	void Start () {
		StartCoroutine (Intro ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Intro(){
		cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
		yield return new WaitForSeconds (1);

		float t = 0;
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 originalPos = cam.transform.position;

		while (t <= Mathf.PI/2) {
			cam.transform.position = Vector3.Lerp(originalPos, new Vector3(player.position.x,player.position.y + cam.GetComponent<CmeraFollow>().bias.y, cam.transform.position.z), Mathf.Sin(t));
			t += Time.deltaTime/2;
			yield return null;
		}
		cam.GetComponent<CmeraFollow> ().enabled = true;
	}
}
