using UnityEngine;
using System.Collections;

public class InstructionScript : MonoBehaviour {

	public GameObject[] instructionPlanes;
	// Use this for initialization
	void Start () {
		StartCoroutine (die ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator die(){
		yield return new WaitForSeconds (3);
		instructionPlanes [0].renderer.enabled = false;
		instructionPlanes [1].renderer.enabled = false;
	}
}
