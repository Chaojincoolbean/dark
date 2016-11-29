using UnityEngine;
using System.Collections;

public class CrackGen : MonoBehaviour {
	public float angle;
	public int index;

	private GameObject root;

	void Start()
	{
		root = transform.FindChild ("Root_Black").gameObject;
	}

	void Update()
	{
//		Debug.Log (transform.localEulerAngles.z);
	}

	public void breakIt()
	{
		if (!root.GetComponent<SpriteRenderer> ().enabled) {
//			if (index == 0) {
//				angle = 90.0f;
//			}
//			if (index == 1) {
//				angle = -90.0f;
//			}
//			if (index == 2) {
//				angle = 180.0f;
//			}
//			if (index == 3) {
//				angle = 0.0f;
//			}
//			
//			Debug.Log (transform.eulerAngles.z);
			root.GetComponent<SpriteRenderer> ().enabled = true;
			root.transform.localRotation = Quaternion.Euler (0, 0, angle);
		}
	}
}
