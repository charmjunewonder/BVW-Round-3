using UnityEngine;
using System.Collections;

public class SpecialItemCreator : MonoBehaviour {
	public GameObject[] specialItems; 
	public GameObject spaceShip;
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
			yield return new WaitForSeconds(3f);

			for(int i = 0; i < specialItems.Length; ++i){
				//if(!specialItems[i].activeSelf){
					if(i < 2){
						int colorChoice = Random.Range(0,4);
						specialItems[i].GetComponent<ColorItem>().setColor(colorChoice);
					}
					specialItems[i].transform.position = getRandomPosition();
					specialItems[i].SetActive(true);
					specialItems[i].GetComponent<SpecialItemDead>().dieInSeconds();
				//}
				yield return new WaitForSeconds(3f);
			}
			yield return new WaitForSeconds(10f);
		}
	}

	float Distance2D(Vector3 a, Vector3 b){
		float xd = a.x - b.x;
		float zd = a.z - b.z;
		return Mathf.Sqrt(xd*xd + zd*zd);
	}

	Vector3 getRandomPosition(){
		Vector3 pos;
		for(int i = 0; i < 10; i++){
			bool isGood = true;
			pos = new Vector3 ((float)Random.Range (-17, 17), 0.5f, (float)Random.Range (-17, 17));
			if(Distance2D(pos, spaceShip.transform.position) < 12){
				isGood &= false;
			}
			for(int j = 0; j < 4; j++){
				if(Distance2D(pos, specialItems[j].transform.position) < 10){
					Debug.Log("item" + Distance2D(pos, specialItems[j].transform.position));
					isGood &= false;
				}
			}
			if(isGood){
				Debug.Log("space" + Distance2D(pos, spaceShip.transform.position));
				for(int j = 0; j < 4; j++){
					Debug.Log("item" + Distance2D(pos, specialItems[j].transform.position));
				}
				return pos;
			}
		}
		int ran = Random.Range(0, 4);
		switch(ran)
		{
			case 1:
				return new Vector3(0, 0.5f, 30);
			case 2:
				return new Vector3(0, 0.5f, -30);
			case 3:
				return new Vector3(30, 0.5f, 0);
			case 4:
				return new Vector3(-30, 0.5f, 0);
		}
		return new Vector3(0, 0.5f, 30);
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
				specialItems[typeChoose].transform.position = getRandomPosition();
				specialItems[typeChoose].SetActive(true);
				specialItems[typeChoose].GetComponent<SpecialItemDead>().dieInSeconds();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
