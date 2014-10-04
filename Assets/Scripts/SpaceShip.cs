using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {
			//explosion.SetActive(true);
			Debug.Log("Collide! Loss!");
		}
	}
}
