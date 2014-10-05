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
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLazer){
			lazerAngle += jod.spinDelta[laserItem.colorChoice]/2;
			//lazerAngle = Mathf.Repeat(lazerAngle, 360);
			Vector3 direction = new Vector3(100* Mathf.Cos(lazerAngle*angleToRadian), 0, -100* Mathf.Sin(lazerAngle*angleToRadian));
			Vector3 targetPosition = direction + transform.position;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, targetPosition);

			RaycastHit[] hits;
			int meteorLayer = 1 << 8;
			hits = Physics.RaycastAll(transform.position, direction, 100.0F, meteorLayer);

			for(int i = 0; i < hits.Length; ++i){
				Destroy(hits[i].collider.gameObject);
				enemyCreator.meteorcount--;
			}
		} 

		if(isBlader){
			blade.transform.Rotate(0, jod.spinDelta[bladeItem.colorChoice]*10, 0);
			blade.transform.position = transform.position;

			if(Mathf.Abs(jod.spinDelta[bladeItem.colorChoice]) > 0){
				isBladerWorking = true;
			} else{
				isBladerWorking = false;
			}
		} 

		if(isBomb && Mathf.Abs(jod.spinDelta[1]) > 0){
			GameObject explosionClone = Instantiate(bombExplosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Vector3.Distance(meteors[i].transform.position, transform.position) < 5){
					Destroy (meteors [i].gameObject);
					enemyCreator.meteorcount--;
				}
			}
			isBomb = false;
			StartCoroutine(destroyExplosion(explosionClone));
		}
		if(isShield){
			shield.SetActive(true);
			shield.transform.position = transform.position;

		}
	}

	IEnumerator restartGame(){
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel ("GamePlay");
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {
			Debug.Log("Collide! Loss!");
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			GameObject explosionClone = Instantiate(explosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			StartCoroutine(restartGame());
		} else if (collision.collider.tag == "LaserItem") {
			isLazer = true;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			StartCoroutine(turnOffLazer());
			collision.gameObject.SetActive(false);
		} else if (collision.collider.tag == "BladeItem") {
			isBlader = true;
			GetComponent<SphereCollider> ().radius = 0.58f;
			StartCoroutine(turnOffBlader());
			collision.gameObject.SetActive(false);
			GetComponent<SphereCollider>().enabled = false;
			blade.SetActive(true);
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
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Vector3.Distance(meteors[i].transform.position, transform.position) < 5){
					Destroy (meteors [i].gameObject);
					enemyCreator.meteorcount--;
				}
			}
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
	}

	
	IEnumerator turnOffShield(){
		yield return new WaitForSeconds(5.0f);
		isShield = false;
		shield.SetActive (false);
		GetComponent<SphereCollider>().enabled = true;
	}
	
	IEnumerator turnOffBlader(){
		yield return new WaitForSeconds(5.0f);
		isBlader = false;
		blade.SetActive (false);
		GetComponent<SphereCollider>().enabled = true;

		GetComponent<SphereCollider> ().radius = 0.4f;
		transform.rotation = Quaternion.identity;
	}

	IEnumerator destroyExplosion(GameObject explosionClone){
		yield return new WaitForSeconds(2.0f);
		Destroy (explosionClone);
	}
}
