using UnityEngine;
using System.Collections;

public class SpecialItemCreator : MonoBehaviour {
	public GameObject[] specialItems; 
	// Use this for initialization
	void Start () {
		StartCoroutine (createSpecialItem ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator createSpecialItem(){
		while(true){
			foreach(GameObject si in specialItems){
				if(!si.activeSelf){
					si.transform.position = new Vector3 ((float)Random.Range (-21, 21), 0.5f, (float)Random.Range (-21, 21));
					si.SetActive(true);
					si.GetComponent<SpecialItemDead>().dieInSeconds();
				}
				yield return new WaitForSeconds(3.0f);
			}
			yield return new WaitForSeconds(10.0f);
		}
	}
}
