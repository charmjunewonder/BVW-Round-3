using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public Texture[] shieldTexture;
	private int animatedNumber = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (animateShield ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator animateShield(){
		while (true) {
			renderer.material.mainTexture = shieldTexture [animatedNumber++%5];
			yield return new WaitForSeconds(0.15f);
		}
	}
}
