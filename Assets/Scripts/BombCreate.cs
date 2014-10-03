using UnityEngine;
using System.Collections;

public class BombCreate : MonoBehaviour
{

		public GameObject bomb;
		public System.Random random;

		// Use this for initialization
		void Start ()
		{
				random = new System.Random ();
				Instantiate (bomb, (new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21))), Quaternion.identity);
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
