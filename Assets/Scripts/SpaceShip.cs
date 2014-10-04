using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour {

	public JamoDrum jod;

	public GameObject explosion;
	public GameObject lazer;
	private float lazerAngle = 45;
	private bool isLazer;
	private float angleToRadian = Mathf.PI / 180;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(isLazer){
			lazerAngle += jod.spinDelta[0];
			//lazerAngle = Mathf.Repeat(lazerAngle, 360);
			Vector3 direction = new Vector3(100* Mathf.Cos(lazerAngle*angleToRadian), 0, -100* Mathf.Sin(lazerAngle*angleToRadian));
			Vector3 targetPosition = direction + transform.position;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, targetPosition);

			RaycastHit[] hits;
			int meteorLayer = 1 << 8;
			hits = Physics.RaycastAll(transform.position, direction, 100.0F, meteorLayer);
			Debug.DrawLine(transform.position, targetPosition);

			Debug.Log(hits.Length);
			for(int i = 0; i < hits.Length; ++i){
				Destroy(hits[i].collider.gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Meteor") {
			//explosion.SetActive(true);
			Debug.Log("Collide! Loss!");
		} else if (collision.collider.tag == "RedItem") {
			Debug.Log("Lazer");
			isLazer = true;
			lazer.GetComponent<LazerAttackTarget> ().setTarget (transform.position, new Vector3(100, 0, -100) - transform.position);
			lazer.SetActive (true);
			StartCoroutine(turnOffLazer());
		}
	}

	IEnumerator turnOffLazer(){
		yield return new WaitForSeconds(2.0f);
		isLazer = false;
		lazer.SetActive (false);
		lazerAngle = 0;
	}
}
