using UnityEngine;
using System.Collections;

public class LeafSpawner : MonoBehaviour {

	public GameObject leaf;
	public int amount;
	// Use this for initialization
	void Start () {
		SpawnLeaves ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnLeaves(){
		for(int i = 0; i < amount; i++){
			Vector2 range = Random.insideUnitCircle * GetComponent<Collider2D> ().bounds.extents.y;
			Vector3 pos = new Vector3 (transform.position.x + range.x, transform.position.y + range.y, 0);
			if(GetComponent<Collider2D>().OverlapPoint(pos)){
				GameObject newLeaf = (GameObject)Instantiate (leaf, pos, Quaternion.identity);
				newLeaf.transform.parent = transform;
				newLeaf.transform.Rotate (0, 0, Random.Range (-90, 90));
			}
		}
	}
}
