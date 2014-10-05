using UnityEngine;
using System.Collections;

public class SpecialItemDead : MonoBehaviour {
	

	public void dieInSeconds(){
		StartCoroutine (dead ());
	}

	IEnumerator dead(){
		yield return new WaitForSeconds(10.0f);
		gameObject.SetActive (false);
	}
}
