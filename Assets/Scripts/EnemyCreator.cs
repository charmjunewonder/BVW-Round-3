using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
	public GameObject meteor;
	public System.Random random;
	public int meteorcount = 1;
	int limitedNumer = 50;
	public ObjectPool objectPool;
	public int speed = 10;
	public float waitTime = 0.5f;
	// Use this for initialization
	void Start ()
	{
		random = new System.Random ();

		StartCoroutine (createMeteorOutside ());
	}

	IEnumerator createMeteorOutside(){
		while(true){
			SpawnMeteorOutside1 ();
			SpawnMeteorOutside2 ();
			SpawnMeteorOutside3 ();
			SpawnMeteorOutside4 ();
			yield return new WaitForSeconds(waitTime);
		}
	}

	void SpawnMeteor ()
	{
		GameObject g = Instantiate (meteor, (new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21))), Quaternion.identity) as GameObject;
		g.SetActive (true);
		g.transform.parent = transform;
		g.rigidbody.AddForce (new Vector3 (random.Next (-1, 1), 0, random.Next (-1, 1)));
		meteorcount += 1;
	}

	void SpawnMeteorOutside1 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (60, 0, Random.Range(-35, 35));
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (-speed, 0, Random.Range(-20, 20));
		meteorcount += 1;
	}

	void SpawnMeteorOutside2 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (-60, 0, Random.Range(-35, 35));
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (speed, 0, Random.Range(-20, 20));
		meteorcount += 1;
	}

	void SpawnMeteorOutside3 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (Random.Range(-35, 35), 0, 60);
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (Random.Range(-20, 20), 0, -speed);
		meteorcount += 1;
	}

	void SpawnMeteorOutside4 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (Random.Range(-35, 35), 0, -60);
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (Random.Range(-20, 20), 0, speed);
		meteorcount += 1;
	}
}
