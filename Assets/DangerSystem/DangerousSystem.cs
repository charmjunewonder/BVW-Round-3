using UnityEngine;
using System.Collections;

public class DangerousSystem : MonoBehaviour {

	int gameTime;
	GameObject dangerPlane;
	GameObject swiper;

	GameObject meteorSystem;

	float alpha = 1.0f;

	int phase = 0;

	bool isIncreasing = false;

	Vector3 initPosition;

	public bool firstTime;

	int timeDelta, timePhaseEnter;

	// Use this for initialization
	void Start () {

		dangerPlane = GameObject.Find ("DangerPlane");
		dangerPlane.SetActive(false);

		swiper = GameObject.Find ("JD");
		swiper.SetActive (false);

		// store first position
		initPosition = swiper.transform.position;

		firstTime = true;

	}
	
	// Update is called once per frame
	void Update () {

		//gameTime = GameObject.Find("TimeNotify").GetComponent<TimeRecorder>().gameTime;

		gameTime = (int)Time.timeSinceLevelLoad+1;

		/* danger system manager */
		//if ( gameTime >= 3.0f && phase == 0 && gameTime%20 == 0) {
		if ( phase == 0 && gameTime%40 == 0) {

			if(firstTime == false)
			{	
				phase = 1;
				timePhaseEnter = gameTime;
			}
			else
			{firstTime = false;}
        }

		if (phase == 1) {
			Swipe ();
		}
	}

	void Swipe()
	{
           
        timeDelta = gameTime - timePhaseEnter;		// time passed
		
		Color newColor;
		
		Debug.Log ("Danger!");
		
		dangerPlane.SetActive(true);
		
		/* blink Danger Sign */
		if (alpha >= 1.0f)
			isIncreasing = false;
		else if (alpha <= 0.0f)
			isIncreasing = true;
		
		if (isIncreasing)
			alpha = alpha + 0.1f;
		else
			alpha = alpha - 0.1f;
		
		newColor = new Color (1, 1, 1, alpha);
		
		dangerPlane.renderer.material.color = newColor;
		
		/* swiper comes in */
		if (timeDelta >= 3.0f) {
			swiper.SetActive(true);
			swiper.transform.Translate(new Vector3(1.0f, 0, 0));
			dangerPlane.SetActive(false);
		}
		if (timeDelta >= 6.0f) {
			swiper.transform.position = initPosition;
			swiper.SetActive(false);

			phase = 0;
		}

    }

	IEnumerator PhaseOne() {
		print("Starting " + Time.time);

		while (true) {
		//	yield return WaitAndSwipe ();
		}
		print("Done " + Time.time);
	}
}
