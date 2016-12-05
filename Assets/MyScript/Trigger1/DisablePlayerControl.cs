using UnityEngine;
using System.Collections;

public class DisablePlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public IEnumerator DisableControl(float t){
		
		GetComponent<Control> ().controlOff = true;
		StartCoroutine(GetComponent<Control>().CloseEye());

		while (t >= 0) {
			t -= Time.deltaTime;
			yield return null;
		}
		GetComponent<Control> ().controlOff = false;
	}
}
