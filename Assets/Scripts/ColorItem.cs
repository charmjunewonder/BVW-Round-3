using UnityEngine;
using System.Collections;

public class ColorItem : MonoBehaviour {

	public Texture[] colorTextures;
	public int colorChoice = 0;
	public GameObject attack;
	public Texture[] colorAttackTextures;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setColor(int colorNum){
		colorChoice = colorNum;
		renderer.material.mainTexture = colorTextures [colorChoice];
	}
}
