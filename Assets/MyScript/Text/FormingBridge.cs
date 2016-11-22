using UnityEngine;
using System.Collections;

public class FormingBridge : MonoBehaviour {
	public float Box_posX;
	public GameObject playerBox;

	public GameObject BridgeNegative;
	public float triggerTime;

	public GameObject bridgeText;

	public AudioClip triggerSound;

	private bool ifDone;
	private float timer;
	// Use this for initialization
	void Start () {
		ifDone = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.GetChild(0).localPosition.x <= -6.0f + 0.5f && transform.GetChild(0).localPosition.x >= -6.0f - 0.5f &&
			transform.GetChild(2).localPosition.x <= 10.75f + 0.5f && transform.GetChild(2).localPosition.x >= 10.75f - 0.5f) 
		{
			timer += Time.deltaTime;
		} 
		else 
		{
			timer = 0.0f;
		}

		if (timer >= triggerTime && !ifDone) {
			GetComponent<Noise> ().gain = 0.0f;
			GetComponent<AudioSource> ().PlayOneShot (triggerSound);
			BridgeNegative.GetComponent<MoveBridge> ().ifStart = true;
			ifDone = true;
			bridgeText.GetComponent<FormingSysmbol> ().ifStart = true;

		}
	
	}
}
