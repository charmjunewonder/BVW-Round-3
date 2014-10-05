using UnityEngine;
using System.Collections;

public class RestartNotify : MonoBehaviour
{

		public Texture[] numbersTexture = new Texture[10];
		public GameObject[] currentScore;
		public GameObject[] highestScore;

		char[] minutes = Mathf.Floor ((JamODrumExample.timeScore) / 60).ToString ().ToCharArray ();
		char[] seconds = Mathf.RoundToInt ((JamODrumExample.timeScore) % 60).ToString ().ToCharArray ();

		char[] hminutes = Mathf.Floor ((JamODrumExample.highScore) / 60).ToString ().ToCharArray ();
		char[] hseconds = Mathf.RoundToInt ((JamODrumExample.highScore) % 60).ToString ().ToCharArray ();
	
		// Use this for initialization
		void Start ()
		{
				currentScore [0].renderer.material.mainTexture = numbersTexture [0];
				currentScore [1].renderer.material.mainTexture = numbersTexture [0];
				currentScore [2].renderer.material.mainTexture = numbersTexture [0];
				currentScore [3].renderer.material.mainTexture = numbersTexture [0];
				JamODrumExample.highScore = JamODrumExample.timeScore;
		}

		void Update ()
		{
				if (JamODrumExample.timeScore > JamODrumExample.highScore)
						JamODrumExample.highScore = JamODrumExample.timeScore;
				
				Debug.Log (JamODrumExample.timeScore);

				if (JamODrumExample.timeScore < 10) 
						currentScore [3].renderer.enabled = false;
				else
						currentScore [3].renderer.enabled = true;
			

				if (JamODrumExample.timeScore < 600) 
						currentScore [1].renderer.enabled = false;
				else
						currentScore [1].renderer.enabled = true;
				
//				Debug.Log (minutes [0] + ":" + seconds [0] + " " + seconds [1]);

				for (int i=0; i<seconds.Length; i++) {

						if (i == 0) {
								if (seconds [0] == '0')
										currentScore [2].renderer.material.mainTexture = numbersTexture [0];
								else if (seconds [0] == '1')
										currentScore [2].renderer.material.mainTexture = numbersTexture [1];
								else if (seconds [0] == '2')
										currentScore [2].renderer.material.mainTexture = numbersTexture [2];
								else if (seconds [0] == '3')
										currentScore [2].renderer.material.mainTexture = numbersTexture [3];
								else if (seconds [0] == '4')
										currentScore [2].renderer.material.mainTexture = numbersTexture [4];
								else if (seconds [0] == '5')
										currentScore [2].renderer.material.mainTexture = numbersTexture [5];
								else if (seconds [0] == '6')
										currentScore [2].renderer.material.mainTexture = numbersTexture [6];
								else if (seconds [0] == '7')
										currentScore [2].renderer.material.mainTexture = numbersTexture [7];
								else if (seconds [0] == '8')
										currentScore [2].renderer.material.mainTexture = numbersTexture [8];
								else if (seconds [0] == '9')
										currentScore [2].renderer.material.mainTexture = numbersTexture [9];
						}

						if (i == 1) {

								if (seconds [1] == '0')
										currentScore [3].renderer.material.mainTexture = numbersTexture [0];
								else if (seconds [1] == '1')
										currentScore [3].renderer.material.mainTexture = numbersTexture [1];
								else if (seconds [1] == '2')
										currentScore [3].renderer.material.mainTexture = numbersTexture [2];
								else if (seconds [1] == '3')
										currentScore [3].renderer.material.mainTexture = numbersTexture [3];
								else if (seconds [1] == '4')
										currentScore [3].renderer.material.mainTexture = numbersTexture [4];
								else if (seconds [1] == '5')
										currentScore [3].renderer.material.mainTexture = numbersTexture [5];
								else if (seconds [1] == '6')
										currentScore [3].renderer.material.mainTexture = numbersTexture [6];
								else if (seconds [1] == '7')
										currentScore [3].renderer.material.mainTexture = numbersTexture [7];
								else if (seconds [1] == '8')
										currentScore [3].renderer.material.mainTexture = numbersTexture [8];
								else if (seconds [1] == '9')
										currentScore [3].renderer.material.mainTexture = numbersTexture [9];
						}
				}

				for (int i=0; i<minutes.Length; i++) {
			
						if (i == 0) {
								if (minutes [0] == '0')
										currentScore [0].renderer.material.mainTexture = numbersTexture [0];
								else if (minutes [0] == '1')
										currentScore [0].renderer.material.mainTexture = numbersTexture [1];
								else if (minutes [0] == '2')
										currentScore [0].renderer.material.mainTexture = numbersTexture [2];
								else if (minutes [0] == '3')
										currentScore [0].renderer.material.mainTexture = numbersTexture [3];
								else if (minutes [0] == '4')
										currentScore [0].renderer.material.mainTexture = numbersTexture [4];
								else if (minutes [0] == '5')
										currentScore [0].renderer.material.mainTexture = numbersTexture [5];
								else if (minutes [0] == '6')
										currentScore [0].renderer.material.mainTexture = numbersTexture [6];
								else if (minutes [0] == '7')
										currentScore [0].renderer.material.mainTexture = numbersTexture [7];
								else if (minutes [0] == '8')
										currentScore [0].renderer.material.mainTexture = numbersTexture [8];
								else if (minutes [0] == '9')
										currentScore [0].renderer.material.mainTexture = numbersTexture [9];
						}
			
						if (i == 1) {
				
								if (minutes [1] == '0')
										currentScore [1].renderer.material.mainTexture = numbersTexture [0];
								else if (minutes [1] == '1')
										currentScore [1].renderer.material.mainTexture = numbersTexture [1];
								else if (minutes [1] == '2')
										currentScore [1].renderer.material.mainTexture = numbersTexture [2];
								else if (minutes [1] == '3')
										currentScore [1].renderer.material.mainTexture = numbersTexture [3];
								else if (minutes [1] == '4')
										currentScore [1].renderer.material.mainTexture = numbersTexture [4];
								else if (minutes [1] == '5')
										currentScore [1].renderer.material.mainTexture = numbersTexture [5];
								else if (minutes [1] == '6')
										currentScore [1].renderer.material.mainTexture = numbersTexture [6];
								else if (minutes [1] == '7')
										currentScore [1].renderer.material.mainTexture = numbersTexture [7];
								else if (minutes [1] == '8')
										currentScore [1].renderer.material.mainTexture = numbersTexture [8];
								else if (minutes [1] == '9')
										currentScore [1].renderer.material.mainTexture = numbersTexture [9];
						}
				}


				if (JamODrumExample.highScore < 10) 
						highestScore [3].renderer.enabled = false;
				else
						highestScore [3].renderer.enabled = true;
		
		
				if (JamODrumExample.highScore < 600) 
						highestScore [1].renderer.enabled = false;
				else
						highestScore [1].renderer.enabled = true;

				for (int i=0; i<hseconds.Length; i++) {
			
						if (i == 0) {
								if (hseconds [0] == '0')
										highestScore [2].renderer.material.mainTexture = numbersTexture [0];
								else if (hseconds [0] == '1')
										highestScore [2].renderer.material.mainTexture = numbersTexture [1];
								else if (hseconds [0] == '2')
										highestScore [2].renderer.material.mainTexture = numbersTexture [2];
								else if (hseconds [0] == '3')
										highestScore [2].renderer.material.mainTexture = numbersTexture [3];
								else if (hseconds [0] == '4')
										highestScore [2].renderer.material.mainTexture = numbersTexture [4];
								else if (hseconds [0] == '5')
										highestScore [2].renderer.material.mainTexture = numbersTexture [5];
								else if (hseconds [0] == '6')
										highestScore [2].renderer.material.mainTexture = numbersTexture [6];
								else if (hseconds [0] == '7')
										highestScore [2].renderer.material.mainTexture = numbersTexture [7];
								else if (hseconds [0] == '8')
										highestScore [2].renderer.material.mainTexture = numbersTexture [8];
								else if (hseconds [0] == '9')
										highestScore [2].renderer.material.mainTexture = numbersTexture [9];
						}
			
						if (i == 1) {
				
								if (hseconds [1] == '0')
										highestScore [3].renderer.material.mainTexture = numbersTexture [0];
								else if (hseconds [1] == '1')
										highestScore [3].renderer.material.mainTexture = numbersTexture [1];
								else if (hseconds [1] == '2')
										highestScore [3].renderer.material.mainTexture = numbersTexture [2];
								else if (hseconds [1] == '3')
										highestScore [3].renderer.material.mainTexture = numbersTexture [3];
								else if (hseconds [1] == '4')
										highestScore [3].renderer.material.mainTexture = numbersTexture [4];
								else if (hseconds [1] == '5')
										highestScore [3].renderer.material.mainTexture = numbersTexture [5];
								else if (hseconds [1] == '6')
										highestScore [3].renderer.material.mainTexture = numbersTexture [6];
								else if (hseconds [1] == '7')
										highestScore [3].renderer.material.mainTexture = numbersTexture [7];
								else if (hseconds [1] == '8')
										highestScore [3].renderer.material.mainTexture = numbersTexture [8];
								else if (hseconds [1] == '9')
										highestScore [3].renderer.material.mainTexture = numbersTexture [9];
						}
				}

				for (int i=0; i<hminutes.Length; i++) {
			
						if (i == 0) {
								if (hminutes [0] == '0')
										highestScore [0].renderer.material.mainTexture = numbersTexture [0];
								else if (hminutes [0] == '1')
										highestScore [0].renderer.material.mainTexture = numbersTexture [1];
								else if (hminutes [0] == '2')
										highestScore [0].renderer.material.mainTexture = numbersTexture [2];
								else if (hminutes [0] == '3')
										highestScore [0].renderer.material.mainTexture = numbersTexture [3];
								else if (hminutes [0] == '4')
										highestScore [0].renderer.material.mainTexture = numbersTexture [4];
								else if (hminutes [0] == '5')
										highestScore [0].renderer.material.mainTexture = numbersTexture [5];
								else if (hminutes [0] == '6')
										highestScore [0].renderer.material.mainTexture = numbersTexture [6];
								else if (hminutes [0] == '7')
										highestScore [0].renderer.material.mainTexture = numbersTexture [7];
								else if (hminutes [0] == '8')
										highestScore [0].renderer.material.mainTexture = numbersTexture [8];
								else if (hminutes [0] == '9')
										highestScore [0].renderer.material.mainTexture = numbersTexture [9];
						}
			
						if (i == 1) {
				
								if (hminutes [1] == '0')
										highestScore [1].renderer.material.mainTexture = numbersTexture [0];
								else if (hminutes [1] == '1')
										highestScore [1].renderer.material.mainTexture = numbersTexture [1];
								else if (hminutes [1] == '2')
										highestScore [1].renderer.material.mainTexture = numbersTexture [2];
								else if (hminutes [1] == '3')
										highestScore [1].renderer.material.mainTexture = numbersTexture [3];
								else if (hminutes [1] == '4')
										highestScore [1].renderer.material.mainTexture = numbersTexture [4];
								else if (hminutes [1] == '5')
										highestScore [1].renderer.material.mainTexture = numbersTexture [5];
								else if (hminutes [1] == '6')
										highestScore [1].renderer.material.mainTexture = numbersTexture [6];
								else if (hminutes [1] == '7')
										highestScore [1].renderer.material.mainTexture = numbersTexture [7];
								else if (hminutes [1] == '8')
										highestScore [1].renderer.material.mainTexture = numbersTexture [8];
								else if (hminutes [1] == '9')
										highestScore [1].renderer.material.mainTexture = numbersTexture [9];
						}
				}


		}

}
