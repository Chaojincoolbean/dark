using UnityEngine;
using System.Collections;

public class BridgeAnim : MonoBehaviour {
	public bool ifStart;
	public GameObject player;
	public float movingSpeed;

	public float StarLocation;
	public float EndLocation;

	private float resetPoint;

	// Use this for initialization
	void Start () {
		ifStart = false;
		resetPoint = (StarLocation + EndLocation) / 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(ifStart)
		transform.position += Vector3.right * player.GetComponent<Rigidbody2D> ().velocity.x/50 * movingSpeed;

		if (transform.localPosition.x <= StarLocation || transform.localPosition.x >= EndLocation) {
			movingSpeed *= -1;	
		}

	}
}
