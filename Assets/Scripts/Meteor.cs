using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public bool firstTime = true;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		transform.LookAt(transform.position+rigidbody.velocity);
		if (collision.collider.tag == "Bound") {
			if(firstTime){
				firstTime = false;
				return;
			}
			gameObject.SetActive(false);
		} 
	}
	
}
