using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public JamoDrum jod;

	public GameObject explosion;
	public GameObject lazer;
	public Texture[] bladerTexture;

	private float lazerAngle = 45;
	private bool isLazer = false;
	private float angleToRadian = Mathf.PI / 180;

	private bool isBlader = false;
	private bool isBladerWorking = false;

	private bool isBomb = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLazer){
			lazerAngle += jod.spinDelta[0]/2;
			//lazerAngle = Mathf.Repeat(lazerAngle, 360);
			Vector3 direction = new Vector3(100* Mathf.Cos(lazerAngle*angleToRadian), 0, -100* Mathf.Sin(lazerAngle*angleToRadian));
			Vector3 targetPosition = direction + transform.position;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, targetPosition);

			RaycastHit[] hits;
			int meteorLayer = 1 << 8;
			hits = Physics.RaycastAll(transform.position, direction, 100.0F, meteorLayer);

			for(int i = 0; i < hits.Length; ++i){
				Destroy(hits[i].collider.gameObject);
			}
		} 
		if(isBlader){
			transform.Rotate(0, jod.spinDelta[3]*10, 0);
			if(jod.spinDelta[3] > 0){
				isBladerWorking = true;
			} else{
				isBladerWorking = false;
			}
		} 
		Debug.Log(isBomb + " sdjflak " + jod.spinDelta[1]);

		if(isBomb && Mathf.Abs(jod.spinDelta[1]) > 0){
			Debug.Log("sdjflak");
			GameObject explosionClone = Instantiate(explosion) as GameObject;
			explosionClone.SetActive(true);
			explosionClone.transform.parent = transform;
			explosionClone.transform.position = transform.position;
			GameObject[] meteors = GameObject.FindGameObjectsWithTag ("Meteor");
			for (int i=0; i<meteors.Length; i++) {
				if(Vector3.Distance(meteors[i].transform.position, transform.position) < 5){
					Destroy (meteors [i].gameObject);
				}
			}
			isBomb = false;
			StartCoroutine(destroyExplosion(explosionClone));
		}
	}
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {

			if(isBladerWorking){
				Destroy(collision.collider.gameObject);
			} else{
				Debug.Log("Collide! Loss!");
				//explosion.SetActive(true);

			}
		} else if (collision.collider.tag == "RedItem") {
			isLazer = true;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			StartCoroutine(turnOffLazer());
		} else if (collision.collider.tag == "YellowItem") {
			isBlader = true;
			renderer.material.mainTexture = bladerTexture [1];
			GetComponent<SphereCollider> ().radius = 0.46f;
			StartCoroutine(turnOffBlader());
		} else if (collision.collider.tag == "BlueItem") {
			isBomb = true;
		}
	}

	IEnumerator turnOffLazer(){
		yield return new WaitForSeconds(2.0f);
		isLazer = false;
		lazer.SetActive (false);
		lazerAngle = 0;
	}

	IEnumerator turnOffBlader(){
		yield return new WaitForSeconds(5.0f);
		isBlader = false;
		renderer.material.mainTexture = bladerTexture [0];
		GetComponent<SphereCollider> ().radius = 0.4f;
		transform.rotation = Quaternion.identity;
	}

	IEnumerator destroyExplosion(GameObject explosionClone){
		yield return new WaitForSeconds(2.0f);
		Destroy (explosionClone);
	}
}
