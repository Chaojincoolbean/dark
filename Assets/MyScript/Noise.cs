using UnityEngine;
using System.Collections;

public class Noise : MonoBehaviour
{
	// un-optimized version of a noise generator
	private System.Random RandomNumber = new System.Random();
	public float offset = 0;

	public float basicFreq = 0.0f;
	public float frequency = 440;
	public float frequency2 = 660;
	public float gain = 0.05f;
	public GameObject playerBox;

	private float increment;
	private float increment2;
	private float phase;
	private float phase2;
	private float sampling_frequency = 44100;
	private TriggerTree tree;
	private AudioSource audio;

	void Start() {
		basicFreq = 0.0f;
		tree = GetComponent<TriggerTree> ();
	}

	void FixedUpdate() {
		//frequency = Random.Range (basicFreq+1, basicFreq+10);
		frequency = playerBox.GetComponent<Rigidbody2D> ().velocity.x * 3;
	}

	void OnAudioFilterRead(float[] data, int channels)
	{

		for (int i = 0; i < data.Length; i=i+channels) {

			phase = phase + increment;
			// this is where we copy audio data to make them “available” to Unity
			data[i] =  (float)(gain*Mathf.Sin(phase));
			// if we have stereo, we copy the mono data to each channel
			if (channels == 2) data[i + 1] = data[i];
			if (phase > 2 * Mathf.PI) phase = 0;

		}

		for (int i = 0; i < data.Length; i=i+channels) {

			phase2 = phase2 + increment2;
			// this is where we copy audio data to make them “available” to Unity
			data[i] *=  (float)(gain*Mathf.Sin(phase2)) + 1;
			// if we have stereo, we copy the mono data to each channel
			if (channels == 2) data[i + 1] = data[i];
			if (phase > 2 * Mathf.PI) phase = 0;

		}

		for (int i = 0; i < data.Length; i++)
		{
			data[i] *=  offset + (float)RandomNumber.NextDouble()*2.0f;
			
		}

		// update increment in case frequency has changed
		increment = frequency * 2 * Mathf.PI / sampling_frequency;
		increment2 = frequency2 * 2 * Mathf.PI / sampling_frequency;

		//add a sine am?

	}
}