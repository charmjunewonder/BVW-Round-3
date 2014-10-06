using UnityEngine;
using System.Collections;

public class Blade : MonoBehaviour {
	public EnemyCreator enemyCreator;
	public SpaceShip spaceShip;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {
			if(spaceShip.isBladerWorking){
				collision.collider.gameObject.SetActive(false);
				enemyCreator.meteorcount--;
			} 
		} 
	}
}
