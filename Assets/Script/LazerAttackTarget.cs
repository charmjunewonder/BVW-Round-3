using UnityEngine;
using System.Collections;

public class LazerAttackTarget : MonoBehaviour {

	//public GameObject eyeTarget;
	public GameObject eyeBall;
	public GameObject trail;
	public GameObject glowTrail;
	public GameObject explosion;
	public bool isColliding = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setTarget(Vector3 startPosition, Vector3 targetPosition){
		trail.GetComponent<LineRenderer> ().SetPosition (0, startPosition);
		trail.GetComponent<LineRenderer> ().SetPosition (1, targetPosition);
		glowTrail.GetComponent<LineRenderer> ().SetPosition (0, startPosition);
		glowTrail.GetComponent<LineRenderer> ().SetPosition (1, targetPosition);

	}

}
