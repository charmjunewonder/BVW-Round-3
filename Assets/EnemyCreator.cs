using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {
	public GameObject enemy;
	public System.Random random;
	Vector3 rnd;

	// Use this for initialization
	void Start () {
		random = new System.Random ();
		Debug.Log ("fjasd "+ random.Next ());
		//rnd=new Vector3((random.NextDouble()-0.5f)*42.0f,1,(random.NextDouble()-0.5f)*42.0f);
		//Instantiate (enemy, rnd, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
