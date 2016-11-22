using UnityEngine;
using System.Collections;

public class BridgeMoveManager : MonoBehaviour {
	public GameObject[] Bridge;
	public float[] max_TravelDis;
	public float[] frequencies;

	public GameObject playerBox;
	public GameObject distCounter;

	public float[] initialBias;

	public bool ifstart;
	private float travelDistance;
	private Vector3[] originalPos;

	// Use this for initialization
	void Start () {
		//initialBias = new float[3];
		ifstart = false;
		originalPos = new Vector3[3];
		travelDistance = -1.0f;
		for (int i = 0; i < Bridge.Length; i++) {
			originalPos [i] = Bridge [i].transform.localPosition;
		}

		for (int i = 0; i < Bridge.Length; i++) {
			Bridge [i].transform.localPosition = originalPos[i] + Vector3.right * 
				Mathf.Sin (frequencies[i] * travelDistance + initialBias[i]) * 
				max_TravelDis[i];
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if (ifstart) {
			travelDistance = (playerBox.transform.position.x - distCounter.transform.position.x);
			GetComponent<Noise> ().enabled = true;

			for (int i = 0; i < Bridge.Length; i++) {
				Bridge [i].transform.localPosition = originalPos[i] + Vector3.right * 
					Mathf.Sin (frequencies[i] * travelDistance + initialBias[i]) * 
					max_TravelDis[i];
			}	
		}
	}
}
