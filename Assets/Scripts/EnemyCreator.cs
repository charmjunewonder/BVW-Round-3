﻿using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
		public GameObject meteor;
		public System.Random random;
//		Vector3 randpos;

		// Use this for initialization
		void Start ()
		{
				random = new System.Random ();
				SpawnMeteor ();
		}
	
		// Update is called once per frame
		void Update ()
		{
//				randpos = new Vector3 (random.Next (-21, 21), 1, random.Next (-21, 21));
		}

		void SpawnMeteor ()
		{
				Instantiate (meteor, (new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21))), Quaternion.identity);
		}
}