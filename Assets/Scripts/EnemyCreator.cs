using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
	public GameObject meteor;
	public System.Random random;
	public int meteorcount = 1;
	int limitedNumer = 50;
	// Use this for initialization
	void Start ()
	{
		random = new System.Random ();
		for(int i = 0; i < 5; ++i){
			SpawnMeteor ();
		}
		StartCoroutine (createMeteor ());
	}
	
	IEnumerator createMeteor(){
		float waitTime = 5;
		while(true){
			if(limitedNumer > meteorcount){
				Debug.Log("Spawn");
				SpawnMeteor ();
				waitTime *= 0.95f;
			}
			yield return new WaitForSeconds(waitTime);
		}
	}



	void SpawnMeteor ()
	{
		GameObject g = Instantiate (meteor, (new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21))), Quaternion.identity) as GameObject;
		g.transform.parent = transform;
		g.rigidbody.AddForce (new Vector3 (random.Next (-1, 1), 0, random.Next (-1, 1)));
		meteorcount += 1;
	}

	void SpawnMeteorOutside ()
	{
		GameObject g = Instantiate (meteor, (new Vector3 (60, 0, 0)), Quaternion.identity) as GameObject;
		g.transform.parent = transform;
		meteorcount += 1;
	}
}
