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
				randpos = new Vector3 ((float)random.Next (-28, 28), 1, (float)random.Next (-28, 28));
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.position = Vector3.Lerp (transform.position, randpos, Time.deltaTime * smoother);
				if (Mathf.Abs ((transform.position.x) - (randpos.x)) < 6) {
						ChangePos ();
				}
				if (Mathf.Abs ((transform.position.z) - (randpos.z)) < 6) {
						ChangePos ();
				}

			
				transform.localScale += new Vector3 (0.0002f, 0, 0.0002f);
	
		}

		void ChangePos ()
		{
				randpos = new Vector3 ((float)random.Next (-28, 28), 1, (float)random.Next (-28, 28));
		}
}
