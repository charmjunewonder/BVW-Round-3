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
			yield return new WaitForSeconds(4.0f);

			for(int i = 0; i < specialItems.Length; ++i){
				if(!specialItems[i].activeSelf){
					if(i < 2){
						int colorChoice = Random.Range(0,2);
						specialItems[i].GetComponent<ColorItem>().setColor(colorChoice);
					}
					specialItems[i].transform.position = new Vector3 ((float)Random.Range (-21, 21), 0.5f, (float)Random.Range (-21, 21));
					specialItems[i].SetActive(true);
					specialItems[i].GetComponent<SpecialItemDead>().dieInSeconds();
				}
				yield return new WaitForSeconds(3.0f);
			}
			yield return new WaitForSeconds(10.0f);
		}
	}
}
