using UnityEngine;
using System.Collections;

public class Singing : MonoBehaviour {
	private TriggerTree tree;
	private AudioSource audio;
	public bool playing;

	public AudioClip sing;
	// Use this for initialization
	void Start () {
		tree = GetComponent<TriggerTree> ();
		audio = GetComponent<AudioSource> ();
		audio.clip = sing;
		audio.volume = 0.0f;
		playing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (tree.treeState == 4) {
			if (!audio.isPlaying) {
				audio.Play ();
				playing = true;
			}
		} 
		else 
		{
			if(audio.isPlaying)
			{
				playing = false;
				if(audio.volume >= 0.0f)
					audio.volume -= 0.5f * Time.deltaTime;
				if(audio.volume <= 0.0f)
					audio.Stop();
			}
		}

		if (playing && audio.volume <= 0.5f) {
			audio.volume += 0.6f * Time.deltaTime;
		}
	}
}
