﻿using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour
{
	
		public JamoDrum jod;
	
		public GameObject[] spinners = new GameObject[4];
		public GameObject[] drums = new GameObject[4];
	
		public Material[] starMaterials = new Material[4];
		public GameObject star;
		public float[] degPerTick = new float[4];
		public float[] spinnerAngle = new float[4];
		public Texture[] normalDrumTexture;
		public Texture[] hittedDrumTexture;
		public GameObject spaceShip;
		private float[] initAngle = new float[4];
	
		private bool once;
		private Vector3[] direction;

		public static bool begin;
		// Use this for initialization
		void Start ()
		{
				direction = new Vector3[4];
				direction [0] = new Vector3 (-1, 0, 1);
				direction [1] = new Vector3 (1, 0, 1);
				direction [2] = new Vector3 (1, 0, -1);
				direction [3] = new Vector3 (-1, 0, -1);
		
				for (int i=0; i<4; i++) {
						initAngle [i] = spinners [i].transform.rotation.eulerAngles.y;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (!once) {
				once = true;
				jod.AddHitEvent (HitHandler);
				jod.AddSpinEvent (SpinHandler);
			}
			for (int i=0; i<4; i++) {
				//spin
				if (Mathf.Abs (jod.spinDelta [i]) > 0) {
					//				Debug.Log("EXAMPLE SPIN "+i);
					spinnerAngle [i] += jod.spinDelta [i] * degPerTick [i];
					//spinnerAngle[i] += jod.spinDelta[i];
					//				Debug.Log("Spin "+i+" : "+jod.spinDelta[i]);
					spinnerAngle [i] = Mathf.Repeat (spinnerAngle [i], 360);
					Vector3 rot = spinners [i].transform.rotation.eulerAngles;
					rot.y = initAngle [i] + spinnerAngle [i];
					spinners [i].transform.rotation = Quaternion.Euler (rot);
	
				}
				//hit
				if (jod.hits [i] > 0) {
					Debug.Log (jod.hits [i]);
					drums [i].renderer.material.mainTexture = hittedDrumTexture [i];
				} else {
					drums [i].renderer.material.mainTexture = normalDrumTexture [i];
	
				}
			}

			if ((jod.hits [0] > 0) && (jod.hits [1] > 0) && (jod.hits [2] > 0) && (jod.hits [3] > 0)) {
				begin = true;
			}



			if (Input.GetKeyUp (KeyCode.Escape)) {
					Application.Quit ();
			}
				
		}
	
		public void SpinHandler (int controllerID, int delta)
		{
				//		Debug.Log("SPIN EVENT "+(controllerID-1));
		}
	
		public void HitHandler (int controllerID)
		{
				//		Debug.Log("HIT EVENT "+(controllerID-1));
		}
	
}