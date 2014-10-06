using UnityEngine;
using System.Collections;

public class Blade : MonoBehaviour {
	public EnemyCreator enemyCreator;
	public SpaceShip spaceShip;
	// Use this for initialization
	void Start () {
	
	}
	
//	void OnCollisionEnter(Collision collision) {
//		if (collision.collider.tag == "Meteor") {
//			Debug.Log("sdjfl");
//			if(spaceShip.isBladerWorking){
//				collision.collider.gameObject.SetActive(false);
//				enemyCreator.meteorcount--;
//			} 
//		} else if(collision.collider.tag == "Bound"){
//			Debug.Log("sjkdfhjksdafjksdha");
//
//		}
//	}
}
