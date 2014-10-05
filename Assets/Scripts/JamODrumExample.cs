using UnityEngine;
using System.Collections;

public class JamODrumExample : MonoBehaviour {
	
	public JamoDrum jod;
	public static float timeScore;
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
	// Use this for initialization
	void Start () {
		direction = new Vector3[4];
		direction [0] = new Vector3 (-1, 0, 1);
		direction [1] = new Vector3 (1, 0, 1);
		direction [2] = new Vector3 (1, 0, -1);
		direction[3] = new Vector3(-1, 0, -1);

		for(int i=0; i<4; i++) {
			initAngle[i] = spinners[i].transform.rotation.eulerAngles.y;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!once) {
			once = true;
			jod.AddHitEvent(HitHandler);
			jod.AddSpinEvent(SpinHandler);
		}
		for(int i=0; i<4; i++) {
			//spin
			if(Mathf.Abs(jod.spinDelta[i]) > 0) {
//				Debug.Log("EXAMPLE SPIN "+i);
				spinnerAngle[i] += jod.spinDelta[i] * degPerTick[i];
				//spinnerAngle[i] += jod.spinDelta[i];
//				Debug.Log("Spin "+i+" : "+jod.spinDelta[i]);
				spinnerAngle[i] = Mathf.Repeat(spinnerAngle[i], 360);
				Vector3 rot = spinners[i].transform.rotation.eulerAngles;
				rot.y = initAngle[i] + spinnerAngle[i];
				spinners[i].transform.rotation = Quaternion.Euler(rot);

			}
			//hit
			if(jod.hits[i] > 0) {
				spaceShip.rigidbody.AddForce(direction[i] * 10, ForceMode.VelocityChange);
				drums[i].renderer.material.mainTexture = hittedDrumTexture[i];
			} else{
				drums[i].renderer.material.mainTexture = normalDrumTexture[i];

			}
		}
		
		if(Input.GetKeyUp(KeyCode.Escape)){
			Application.Quit();
		}
		for(int i = 0; i < 4; i++)
		{
			jod.spinDelta[i] = 0;
			jod.hits[i] = 0;
		}
	}
	
	public void SpinHandler(int controllerID, int delta) {
//		Debug.Log("SPIN EVENT "+(controllerID-1));
	}
		
	public void HitHandler(int controllerID) {
//		Debug.Log("HIT EVENT "+(controllerID-1));
	}
	
}
