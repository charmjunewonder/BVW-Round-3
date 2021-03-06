﻿using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public JamoDrum jod;

	public GameObject explosion;

	public EnemyCreator enemyCreator;

	public GameObject lazer;
	public GameObject lazerTrail;
	public Texture[] laserColorAttackTextures;
	public ColorItem laserItem;
	private float lazerAngle = 45;
	private bool isLazer = false;
	private float angleToRadian = Mathf.PI / 180;

	public ColorItem bladeItem;
	public GameObject blade;
	public Texture[] bladeColorAttackTextures;
	private bool isBlader = false;
	public bool isBladerWorking = false;

	public GameObject bombExplosion;
	private bool isBomb = false;

	public GameObject shield;
	private bool isShield = false;

	public TimeRecorder timeRecorder;

	public GameObject[] spinnerPower;

	public AudioClip[] audios;

	private int laserColorIndex = 0;
	private int bladeColorIndex = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLazer){
			lazerAngle -= jod.spinDelta[laserColorIndex]/2;
			float angle = lazerAngle*angleToRadian / 2 ;//* 50 * Time.deltaTime;
			//lazerAngle = Mathf.Repeat(lazerAngle, 360);
			Vector3 direction = new Vector3(100* Mathf.Cos(angle), 0, -100* Mathf.Sin(angle));
			Vector3 targetPosition = direction + transform.position;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position + direction.normalized * 2, targetPosition);

			RaycastHit[] hits;
			int meteorLayer = 1 << 8;
			hits = Physics.SphereCastAll(transform.position, 0.8f, direction, 100.0F, meteorLayer);

			//Debug.Log(Time.deltaTime);
			//Debug.DrawRay(transform.position, direction, Color.green, 10);

			for(int i = 0; i < hits.Length; ++i){
				//hits[i].collider.gameObject.SetActive(false);
				hits[i].collider.gameObject.GetComponent<Meteor>().DieWithAnimation();
				enemyCreator.meteorcount--;
			}
		} 

		if(isBlader){
			blade.transform.Rotate(0, -jod.spinDelta[bladeColorIndex]*10, 0);
			blade.transform.position = transform.position + new Vector3(0, 0.1f, 0);

			if(Mathf.Abs(jod.spinDelta[bladeColorIndex]) > 0){
				isBladerWorking = true;
				audio.clip = audios[2];
				audio.loop = true;
				audio.Play();
			} else{
				isBladerWorking = false;
				audio.Stop();
			}
		} 

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
			if(isBlader){
				if(isBladerWorking){
					collision.collider.gameObject.GetComponent<Meteor>().DieWithAnimation();
					//collision.collider.gameObject.SetActive(false);
					enemyCreator.meteorcount--;
				}
			} else if(isShield){

			} else{
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
			}
		} else if (collision.collider.tag == "LaserItem") {
//			if(isLazer || isBlader || isShield){
//				return;
//			}
			isLazer = true;
			laserColorIndex = laserItem.colorChoice;
			audio.clip = audios[1];
			audio.loop = true;
			audio.Play();

			lazerTrail.renderer.material.mainTexture = laserColorAttackTextures [laserColorIndex];

			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			spinnerPower[laserItem.colorChoice].SetActive(true);
			StopCoroutine("turnOffLazer");
			StartCoroutine("turnOffLazer");
			collision.gameObject.SetActive(false);
		} else if (collision.collider.tag == "BladeItem") {
//			if(isLazer || isBlader || isShield){
//				return;
//			}
			isBlader = true;
			bladeColorIndex = bladeItem.colorChoice;
			StopCoroutine("turnOffBlader");
			StartCoroutine("turnOffBlader");
			collision.gameObject.SetActive(false);
			blade.renderer.material.mainTexture = bladeColorAttackTextures [bladeColorIndex];
			//GetComponent<SphereCollider>().enabled = false;
			GetComponent<SphereCollider> ().radius = 0.44f;
			blade.SetActive(true);
			spinnerPower[bladeItem.colorChoice].SetActive(true);

		} else if (collision.collider.tag == "ShieldItem") {
//			if(isLazer || isBlader || isShield){
//				return;
//			}
			isShield = true;
			StartCoroutine(turnOffShield());
			shield.SetActive(true);
			//GetComponent<SphereCollider>().enabled = false;
			collision.gameObject.SetActive(false);
			GetComponent<SphereCollider> ().radius = 0.5f;

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
		}
		fixInstructionUI();
	}

	void fixInstructionUI(){
		for(int i = 0; i < 4; i++){
			spinnerPower[i].SetActive(false);
		}
		if(isLazer)
			spinnerPower[laserColorIndex].SetActive(true);
		if(isBlader)
			spinnerPower[bladeColorIndex].SetActive(true);
	}

	IEnumerator turnOffLazer(){
		yield return new WaitForSeconds(5.0f);
		isLazer = false;
		lazer.SetActive (false);
		lazerAngle = 0;
		spinnerPower[laserColorIndex].SetActive(false);
		audio.loop = false;
		audio.Stop();
	}

	float Distance2D(Vector3 a, Vector3 b){
		float xd = a.x - b.x;
		float zd = a.z - b.z;
		return Mathf.Sqrt(xd*xd + zd*zd);
	}

	IEnumerator killWithBomb(){
		for(int n = 0; n < 3; ++n){
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Distance2D(meteors[i].transform.position, transform.position) < 30){
					meteors [i].gameObject.SetActive(false);
					//meteors [i].gameObject.GetComponent<Meteor>().DieWithAnimation();
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
		//GetComponent<SphereCollider>().enabled = true;
		GetComponent<SphereCollider> ().radius = 0.25f;

	}
	
	IEnumerator turnOffBlader(){
		yield return new WaitForSeconds(6.0f);
		isBlader = false;
		blade.SetActive (false);
		//GetComponent<SphereCollider>().enabled = true;
		audio.loop = false;
		audio.Stop();
		GetComponent<SphereCollider> ().radius = 0.25f;
		transform.rotation = Quaternion.identity;
		spinnerPower[bladeColorIndex].SetActive(false);

	}

	IEnumerator destroyExplosion(GameObject explosionClone){
		yield return new WaitForSeconds(2.0f);
		Destroy (explosionClone);
	}
}
