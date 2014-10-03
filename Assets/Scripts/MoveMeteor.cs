using UnityEngine;
using System.Collections;

public class MoveMeteor : MonoBehaviour
{
		public System.Random random;
		public float smoother;
		Vector3 randpos;

		// Use this for initialization
		void Start ()
		{
				random = new System.Random ();
				randpos = new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21));
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.position = Vector3.Lerp (transform.position, randpos, Time.deltaTime * smoother);
				if (Mathf.Abs ((transform.position.x) - (randpos.x)) < 5) {
						ChangePos ();
				}
				
	
		}

		void ChangePos ()
		{
				randpos = new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21));
		}
}
