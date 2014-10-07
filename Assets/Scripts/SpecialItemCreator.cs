﻿using UnityEngine;
using System.Collections;

public class SpecialItemCreator : MonoBehaviour {
	public GameObject[] specialItems; 
	// Use this for initialization
	void Start () {
		StartCoroutine (createSpecialItem ());
		StartCoroutine (remainOneItem ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator createSpecialItem(){
		while(true){
			yield return new WaitForSeconds(3.0f);

			for(int i = 0; i < specialItems.Length; ++i){
				if(!specialItems[i].activeSelf){
					if(i < 2){
						int colorChoice = Random.Range(0,4);
						specialItems[i].GetComponent<ColorItem>().setColor(colorChoice);
					}
					specialItems[i].transform.position = new Vector3 ((float)Random.Range (-17, 17), 0.5f, (float)Random.Range (-17, 17));
					specialItems[i].SetActive(true);
					specialItems[i].GetComponent<SpecialItemDead>().dieInSeconds();
				}
				yield return new WaitForSeconds(1.0f);
			}
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator remainOneItem(){
		yield return new WaitForSeconds(4.0f);

		while(true){
			bool oneRemain = false;
			for(int i = 0; i < specialItems.Length; ++i){
				oneRemain = oneRemain | specialItems[i].activeSelf;
			}
			if(!oneRemain){
				int typeChoose = Random.Range(0,2);
				int colorChoice = Random.Range(0,4);
				specialItems[typeChoose].GetComponent<ColorItem>().setColor(colorChoice);
				specialItems[typeChoose].transform.position = new Vector3 ((float)Random.Range (-17, 17), 0.5f, (float)Random.Range (-17, 17));
				specialItems[typeChoose].SetActive(true);
				specialItems[typeChoose].GetComponent<SpecialItemDead>().dieInSeconds();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
