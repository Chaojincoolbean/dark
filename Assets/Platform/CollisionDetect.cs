using UnityEngine;
using System.Collections;

public class CollisionDetect : MonoBehaviour {
	public GameObject black_Root;
	public GameObject Bump;
	public bool iftriggered;
	public GameObject playerBox;
	public GameObject player;

	private bool ifBreak;
	// Use this for initialization
	void Start () {
		iftriggered = false;
		ifBreak = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject boxPlayer;

		if (!iftriggered) {
			iftriggered = true;
			ContactPoint2D[] points = collision.contacts;
			boxPlayer = (GameObject)Instantiate(Bump, points[0].point, transform.rotation);
			boxPlayer.GetComponent<Animator> ().SetBool ("Big_Trigger", true);
			playerBox.GetComponent<CrackGen> ().breakIt ();
			//playerBox.transform.FindChild ("Root_Black").GetComponent<SpriteRenderer> ().enabled = true;
			player.gameObject.GetComponent<Control> ().enabled = true;
			GetComponent<AudioSource> ().Play ();
		}
	}
}
