using UnityEngine;
using System.Collections;

public class MoveMeteor : MonoBehaviour
{
	public Random random;
	public float smoother;
	Vector3 randpos;
	int timer;

	// Use this for initialization
	void Start ()
	{
		random = new Random ();

		ChangePos ();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp (transform.position, randpos, Time.deltaTime * smoother);
		if (Vector3.Distance (transform.position, randpos) < 6) {
			ChangePos ();
		}

	}
	void ChangePos ()
	{
		randpos = new Vector3 ((float)Random.Range (-28, 28), 0.5f, (float)Random.Range (-28, 28));
	}
}
