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
		if (jod.hits [0] > 0 && jod.hits [1] > 0 && jod.hits [2] > 0 && jod.hits [3] > 0 && bombenable == true) {
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
