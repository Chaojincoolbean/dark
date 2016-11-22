using UnityEngine;
using System.Collections;

public class Wall_AniamtionEvent : MonoBehaviour {

	public void DeactiveTrigger()
	{
		GetComponent<Animator> ().SetBool ("Trigger", false);
	}
}
