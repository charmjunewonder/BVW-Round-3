using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	public bool firstTime = true;
	public GameObject dieAnimation;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "SpaceShip") {
			if(collision.collider.gameObject.GetComponent<SpaceShip>().isBladerWorking){
				return;
			}
		} 
		transform.LookAt(transform.position+rigidbody.velocity);
		if (collision.collider.tag == "Bound") {
			if(firstTime){
				firstTime = false;
				return;
			}
			gameObject.SetActive(false);
		} 
	}

	public void DieWithAnimation(){
		StartCoroutine(die());
	}
	
	IEnumerator die(){
		renderer.enabled = false;
		collider.enabled = false;
		rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		dieAnimation.SetActive(true);
		yield return new WaitForSeconds(0.5f);
		dieAnimation.SetActive(false);
		collider.enabled = true;
		rigidbody.constraints = RigidbodyConstraints.FreezePositionY 
			| RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		//renderer.enabled = true;
		gameObject.SetActive(false);
	}
}
