using UnityEngine;
using System.Collections;

public class TriggerTree : MonoBehaviour {
	public bool ifReady;
	public bool ifComplete;
	public GameObject playerBox;
	public Sprite[] treesCollection; 
	public Vector3[] treePos;

	public GameObject bigClock;
	public float velCheck;
	public int treeState;

	private Vector3 originPos;
	// Use this for initialization
	void Start () {
		treeState = 0;
		ifReady = false;
		ifComplete = false;
		originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerBox.transform.position.x <= transform.position.x + 0.1f &&
			playerBox.transform.position.x >= transform.position.x - 0.1f) {
			ifReady = true;
		} else
			ifReady = false;
	}

	public void Grow()
	{
		if (ifComplete) 
		{
			if (playerBox.GetComponent<Rigidbody2D> ().velocity.x > velCheck && treeState < treesCollection.Length-1) 
			{
				treeState++;
				GetComponent<SpriteRenderer> ().sprite = treesCollection [treeState];
				transform.position = originPos + treePos[treeState];
			}
			else if (playerBox.GetComponent<Rigidbody2D> ().velocity.x < -velCheck && treeState > 0)
			{
				treeState--;
				GetComponent<SpriteRenderer> ().sprite = treesCollection [treeState];
				transform.position = originPos + treePos[treeState];
			}	
		}
	}
}
