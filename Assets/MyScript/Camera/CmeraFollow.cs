using UnityEngine;
using System.Collections;

public class CmeraFollow : MonoBehaviour {
	public GameObject player;
	public float followSpeed;

	public Vector2 bias;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		FollowPlayer ();
	}

	void FollowPlayer()
	{
		transform.position = Vector3.Lerp (transform.position, new Vector3(player.transform.position.x+bias.x, 
																			player.transform.position.y+bias.y, transform.position.z), 
																			Time.deltaTime * followSpeed);
	}
}
