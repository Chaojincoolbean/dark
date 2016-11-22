using UnityEngine;
using System.Collections;

public class ClockPulse : MonoBehaviour {
	public bool ifPulse;
	public GameObject tree;

	public AudioClip audio;
	public GameObject tickColck;

	public void SendPulse()
	{
		tree.SendMessage ("Grow");
	}

	public void Tick()
	{
		tickColck.GetComponent<AudioSource> ().PlayOneShot (audio);
	}
}
