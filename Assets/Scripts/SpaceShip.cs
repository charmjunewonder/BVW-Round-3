using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public JamoDrum jod;

	public GameObject explosion;

	public EnemyCreator enemyCreator;

	public GameObject lazer;
	public ColorItem laserItem;
	private float lazerAngle = 45;
	private bool isLazer = false;
	private float angleToRadian = Mathf.PI / 180;

	public ColorItem bladeItem;
	public GameObject blade;
	private bool isBlader = false;
	public bool isBladerWorking = false;

	public GameObject bombExplosion;
	private bool isBomb = false;

	public GameObject shield;
	private bool isShield = false;

	public TimeRecorder timeRecorder;

	public GameObject[] spinnerPower;

	public AudioClip[] audios;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLazer){
			lazerAngle += jod.spinDelta[laserItem.colorChoice]/2;
			float angle = lazerAngle*angleToRadian / 2;
			//lazerAngle = Mathf.Repeat(lazerAngle, 360);
			Vector3 direction = new Vector3(100* Mathf.Cos(angle), 0, -100* Mathf.Sin(angle));
			Vector3 targetPosition = direction + transform.position;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position + direction.normalized * 2, targetPosition);

			RaycastHit[] hits;
			int meteorLayer = 1 << 8;
			hits = Physics.RaycastAll(transform.position, direction, 100.0F, meteorLayer);
			Debug.Log(hits.Length);

			for(int i = 0; i < hits.Length; ++i){
				hits[i].collider.gameObject.SetActive(false);
				enemyCreator.meteorcount--;
			}
		} 

		if(isBlader){
			blade.transform.Rotate(0, jod.spinDelta[bladeItem.colorChoice]*10, 0);
			blade.transform.position = transform.position + new Vector3(0, 0.1f, 0);

			if(Mathf.Abs(jod.spinDelta[bladeItem.colorChoice]) > 0){
				isBladerWorking = true;
				audio.clip = audios[2];
				audio.loop = true;
				audio.Play();
			} else{
				isBladerWorking = false;
				audio.Stop();
			}
		} 

		/*if(isBomb && Mathf.Abs(jod.spinDelta[1]) > 0){
			GameObject explosionClone = Instantiate(bombExplosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Vector3.Distance(meteors[i].transform.position, transform.position) < 5){
					meteors [i].gameObject.SetActive(false);
					enemyCreator.meteorcount--;
				}
			}
			isBomb = false;
			StartCoroutine(destroyExplosion(explosionClone));
		}*/
		if(isShield){
			shield.SetActive(true);
			shield.transform.position = transform.position;

		}
	}

	IEnumerator restartGame(){
		yield return new WaitForSeconds (2.0f);
		PlayerPrefs.SetInt ("CS", timeRecorder.gameTime);
		Application.LoadLevel ("End");
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {
			Debug.Log("Collide! Loss!");
			audio.clip = audios[0];
			if(!audio.isPlaying)
				audio.Play();
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			GameObject explosionClone = Instantiate(explosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			StartCoroutine(restartGame());
		} else if (collision.collider.tag == "LaserItem") {
			isLazer = true;
			audio.clip = audios[1];
			audio.loop = true;
			audio.Play();
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			spinnerPower[laserItem.colorChoice].SetActive(true);
			StartCoroutine(turnOffLazer());
			collision.gameObject.SetActive(false);
		} else if (collision.collider.tag == "BladeItem") {
			isBlader = true;
			GetComponent<SphereCollider> ().radius = 0.58f;
			StartCoroutine(turnOffBlader());
			collision.gameObject.SetActive(false);
			GetComponent<SphereCollider>().enabled = false;
			blade.SetActive(true);
			spinnerPower[bladeItem.colorChoice].SetActive(true);

		} else if (collision.collider.tag == "ShieldItem") {
			isShield = true;
			StartCoroutine(turnOffShield());
			shield.SetActive(true);
			GetComponent<SphereCollider>().enabled = false;
			collision.gameObject.SetActive(false);

		} else if (collision.collider.tag == "BombItem") {
			collision.gameObject.SetActive(false);
			GameObject explosionClone = Instantiate(bombExplosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			audio.clip = audios[4];
			audio.Play ();
			StartCoroutine(killWithBomb());
			StartCoroutine(destroyExplosion(explosionClone));
		} /*else if (collision.collider.tag == "RedItem") {
			isLazer = true;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			StartCoroutine(turnOffLazer());
			collision.gameObject.SetActive(false);
		} else if (collision.collider.tag == "YellowItem") {
			isBlader = true;
			renderer.material.mainTexture = bladerTexture [1];
			GetComponent<SphereCollider> ().radius = 0.58f;
			StartCoroutine(turnOffBlader());
			collision.gameObject.SetActive(false);

		} else if (collision.collider.tag == "BlueItem") {
			isBomb = true;
			collision.gameObject.SetActive(false);

		} else if (collision.collider.tag == "GreenItem") {
			isShield = true;
			StartCoroutine(turnOffShield());
			collision.gameObject.SetActive(false);

		}*/

	}

	IEnumerator turnOffLazer(){
		yield return new WaitForSeconds(2.0f);
		isLazer = false;
		lazer.SetActive (false);
		lazerAngle = 0;
		spinnerPower[laserItem.colorChoice].SetActive(false);
		audio.loop = false;
		audio.Stop();
	}

	IEnumerator killWithBomb(){
		for(int n = 0; n < 3; ++n){
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Vector3.Distance(meteors[i].transform.position, transform.position) < 13){
					meteors [i].gameObject.SetActive(false);
					enemyCreator.meteorcount--;
				}
			}
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	IEnumerator turnOffShield(){
		yield return new WaitForSeconds(3.0f);
		isShield = false;
		shield.SetActive (false);
		GetComponent<SphereCollider>().enabled = true;
	}
	
	IEnumerator turnOffBlader(){
		yield return new WaitForSeconds(6.0f);
		isBlader = false;
		blade.SetActive (false);
		GetComponent<SphereCollider>().enabled = true;
		audio.loop = false;
		audio.Stop();
		GetComponent<SphereCollider> ().radius = 0.4f;
		transform.rotation = Quaternion.identity;
		spinnerPower[bladeItem.colorChoice].SetActive(false);

	}

	IEnumerator destroyExplosion(GameObject explosionClone){
		yield return new WaitForSeconds(2.0f);
		Destroy (explosionClone);
	}
}
