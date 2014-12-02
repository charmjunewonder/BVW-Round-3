using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour
{
	public GameObject meteor;
	public System.Random random;
	public int meteorcount = 1;
	int limitedNumer = 50;
	public ObjectPool objectPool;
	private float speed = 10;
	private float waitingTime = 1f;
	// Use this for initialization
	void Start ()
	{
		random = new System.Random ();

		StartCoroutine (createMeteorOutside ());
		StartCoroutine (increaseDifficulty ());

	}

	IEnumerator increaseDifficulty(){
		while(true){
			yield return new WaitForSeconds(12.0f);

			Debug.Log("more difficult");
			if(waitingTime > 0.3f)
				waitingTime -=0.15f;
			if(speed < 20f)
				speed += 0.5f;
		}
	}

	IEnumerator createMeteorOutside(){
		while(true){
			SpawnMeteorOutside1 ();
			SpawnMeteorOutside2 ();
			SpawnMeteorOutside3 ();
			SpawnMeteorOutside4 ();
			// Debug.Log(waitingTime);
			yield return new WaitForSeconds(waitingTime);
		}
	}

	void SpawnMeteor ()
	{
		GameObject g = Instantiate (meteor, (new Vector3 ((float)random.Next (-21, 21), 1, (float)random.Next (-21, 21))), Quaternion.identity) as GameObject;
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.transform.parent = transform;
		g.rigidbody.AddForce (new Vector3 (random.Next (-1, 1), 0, random.Next (-1, 1)));
		meteorcount += 1;
	}

	void SpawnMeteorOutside1 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.GetComponent<Meteor> ().firstTime = true;
		g.renderer.enabled = true;
		g.transform.position = new Vector3 (60, 0, Random.Range(-35, 35));
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (-speed, 0, Random.Range(-speed, speed));
		g.transform.LookAt(g.transform.position+g.rigidbody.velocity);
		meteorcount += 1;
	}

	void SpawnMeteorOutside2 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (-60, 0, Random.Range(-35, 35));
		g.renderer.enabled = true;
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (speed, 0, Random.Range(-speed, speed));
		g.transform.LookAt(g.transform.position+g.rigidbody.velocity);
		meteorcount += 1;
	}

	void SpawnMeteorOutside3 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (Random.Range(-35, 35), 0, 60);
		g.renderer.enabled = true;
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (Random.Range(-speed, speed), 0, -speed);
		g.transform.LookAt(g.transform.position+g.rigidbody.velocity);
		meteorcount += 1;
	}

	void SpawnMeteorOutside4 ()
	{
		GameObject g = objectPool.GetObjectFromPool();
		g.transform.position = new Vector3 (Random.Range(-35, 35), 0, -60);
		g.renderer.enabled = true;
		g.GetComponent<Meteor> ().firstTime = true;
		g.SetActive (true);
		g.rigidbody.velocity = new Vector3 (Random.Range(-speed, speed), 0, speed);
		g.transform.LookAt(g.transform.position+g.rigidbody.velocity);
		meteorcount += 1;
	}
}
