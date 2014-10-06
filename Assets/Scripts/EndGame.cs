using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
	
	public JamoDrum jod;
	public Texture startTexture;
	public GameObject[] spinners = new GameObject[4];
	public GameObject[] drums = new GameObject[4];
	public GameObject[] colorNotify;
	public GameObject fourColorNotify;
	public GameObject notify;
	public Material[] starMaterials = new Material[4];
	public GameObject star;
	public float[] degPerTick = new float[4];
	public float[] spinnerAngle = new float[4];
	public Texture[] normalDrumTexture;
	public Texture[] hittedDrumTexture;
	public GameObject spaceShip;
	private float[] initAngle = new float[4];

	private bool once;
	public static bool begin;
	// Use this for initialization
	void Start ()
	{
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
				drums [i].renderer.material.mainTexture = hittedDrumTexture [i];
				colorNotify[i].SetActive(true);
				audio.Play();
			} 
		}


		if ((colorNotify[0].activeSelf) && (colorNotify[1].activeSelf) && (colorNotify[2].activeSelf) && (colorNotify[3].activeSelf)) {
			fourColorNotify.SetActive(false);

			notify.SetActive(true);
			StartCoroutine(restartGame());

		}

		if (Input.GetKeyUp (KeyCode.Escape)) {
				Application.Quit ();
		}
		for(int i = 0; i < 4; i++)
		{
			jod.spinDelta[i] = 0;
			jod.hits [i] = 0;
		}
	}

	IEnumerator restartGame(){
		yield return new WaitForSeconds (0.5f);
		notify.renderer.material.mainTexture = startTexture;
		yield return new WaitForSeconds (0.5f);

		Application.LoadLevel ("GamePlay");
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
