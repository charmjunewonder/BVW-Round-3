using UnityEngine;
using System.Collections;

public class RestartNotify : MonoBehaviour
{

	public Texture[] numbersTexture = new Texture[10];
	public GameObject[] currentScore;
	public GameObject[] highestScore;
	public GameObject timeNotify;
	// Use this for initialization
	void Start ()
	{
		currentScore [0].renderer.material.mainTexture = numbersTexture [0];
		currentScore [1].renderer.material.mainTexture = numbersTexture [0];
		currentScore [2].renderer.material.mainTexture = numbersTexture [0];
		currentScore [3].renderer.material.mainTexture = numbersTexture [0];
		
		highestScore [0].renderer.material.mainTexture = numbersTexture [0];
		highestScore [1].renderer.material.mainTexture = numbersTexture [0];
		highestScore [2].renderer.material.mainTexture = numbersTexture [0];
		highestScore [3].renderer.material.mainTexture = numbersTexture [0];
		showTime ();

		GameObject timeNotifyClone = Instantiate (timeNotify) as GameObject;
		timeNotifyClone.transform.Rotate (0, 180, 0);
	}

	void showTime(){
		int currentTime = PlayerPrefs.GetInt ("CS");
		int highestTime = PlayerPrefs.GetInt ("HS");
		if (currentTime > highestTime){
			PlayerPrefs.SetInt ("HS", currentTime);
			highestTime = currentTime;
		}
		
		Debug.Log (PlayerPrefs.GetInt ("HS"));
		Debug.Log (PlayerPrefs.GetInt ("CS"));

		int minutes = currentTime / 60;
		int seconds = currentTime - minutes * 60;
		int second1 = seconds / 10;
		int second2 = seconds - second1 * 10;
		int minute1 = minutes / 10;
		int minute2 = minutes - minute1 * 10;
		currentScore[0].renderer.material.mainTexture = numbersTexture[minute1];
		currentScore[1].renderer.material.mainTexture = numbersTexture[minute2];
		currentScore[2].renderer.material.mainTexture = numbersTexture[second1];
		currentScore[3].renderer.material.mainTexture = numbersTexture[second2];

		minutes = highestTime / 60;
		seconds = highestTime - minutes * 60;
		second1 = seconds / 10;
		second2 = seconds - second1 * 10;
		minute1 = minutes / 10;
		minute2 = minutes - minute1 * 10;
		highestScore[0].renderer.material.mainTexture = numbersTexture[minute1];
		highestScore[1].renderer.material.mainTexture = numbersTexture[minute2];
		highestScore[2].renderer.material.mainTexture = numbersTexture[second1];
		highestScore[3].renderer.material.mainTexture = numbersTexture[second2];
	}
	
	
	
}
