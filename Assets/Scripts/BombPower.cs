using UnityEngine;
using System.Collections;

public class BombPower : MonoBehaviour
{
		public JamoDrum jod;
		private bool bombenable;
		public GameObject spaceship;
		GameObject[] meteors;

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				meteors = GameObject.FindGameObjectsWithTag ("Meteor");
				if ( bombenable == true) {
						bombenable = false;
						Debug.Log ("EXploDe");
						for (int i=0; i<5; i++) {
								Destroy (meteors [i].gameObject);
						}
				}
		}

		void OnTriggerEnter (Collider other)
		{
				Debug.Log ("Acquiring bomb");
				if (other.gameObject.tag == "Player") {
						bombenable = true;
						renderer.enabled = false;
				}
						
		}
}
