using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Bound") {
			gameObject.SetActive(false);
		} 
	}
	
}
