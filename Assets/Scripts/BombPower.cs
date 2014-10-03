using UnityEngine;
using System.Collections;

public class BombPower : MonoBehaviour
{
		public JamoDrum jod;
		public GameObject meteor;
		private bool bombenable;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (jod.hit [0] == true && jod.hit [1] == true && jod.hit [2] == true && jod.hit [3] == true && bombenable == true) {
						Destroy (meteor);
						Destroy (gameObject);
				}
		}

		void OntriggerEnter (Collider other)
		{
				if (other.gameObject.tag == "SpaceShip")
						bombenable = true;
		}
}
