using UnityEngine;
using System.Collections;

public class MoveMeteor : MonoBehaviour
{
	public Random random;
	public float smoother;
	Vector3 randpos;
	int timer;
	public int FORCE_MULTIPLIER = 15;
	// Use this for initialization
	void Start ()
	{
		random = new Random ();
		ChangePos ();
//		rigidbody.AddForce(new Vector3 (Random.Range (-10, 10), 0, Random.Range (-10, 10))*FORCE_MULTIPLIER, ForceMode.Force);
		//StartCoroutine (addForce ());
	}

	
	IEnumerator addForce(){
		while(true){
			rigidbody.AddForce (randpos * 10, ForceMode.Force);
			yield return new WaitForSeconds(10.0f);
		}
	}
	// Update is called once per frame
	void Update ()
	{
//		transform.position = Vector3.Lerp (transform.position, randpos, Time.deltaTime * smoother);
//		if (Vector3.Distance (transform.position, randpos) < 6) {
//			ChangePos ();
//		}

	}
	void ChangePos ()
	{
		randpos = new Vector3 ((float)Random.Range (-28, 28), 0.5f, (float)Random.Range (-28, 28));
	}
}
