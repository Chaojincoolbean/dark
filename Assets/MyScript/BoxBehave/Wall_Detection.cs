using UnityEngine;
using System.Collections;

public class Wall_Detection : MonoBehaviour {
	private Animator WallAnimation;
	private CrackGen crackGen;
	private AudioSource audioSource;

	public AudioClip audio;
	public int ind;
	// Use this for initialization
	void Start () {
		WallAnimation = transform.GetChild (0).GetComponent<Animator> ();
		crackGen = transform.GetComponentInParent<CrackGen> ();
		audioSource = GetComponent<AudioSource> ();
	}

	public void TriggerAnime()
	{
		WallAnimation.SetBool ("Trigger", true);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player" && collision.relativeVelocity.magnitude >= 1.0f) {
			WallAnimation.SetBool ("Trigger", true);
			audioSource.pitch = Random.Range (0.7f,1.3f);
			audioSource.PlayOneShot (audio);
		}
		if (collision.gameObject.tag == "SpecialFloor") {
			crackGen.index = ind;
		}
	}
}
