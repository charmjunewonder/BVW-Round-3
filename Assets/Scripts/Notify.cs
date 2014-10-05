using UnityEngine;
using System.Collections;

public class Notify : MonoBehaviour
{
		public Texture2D[] textures;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (StartGame.begin == true) {
						renderer.enabled = true;
						StartCoroutine (NotifyPlayer ());
				}
	
		}
		IEnumerator NotifyPlayer ()
		{
				for (int i=0; i<4; i++) {
						renderer.material.mainTexture = textures [i];
						yield return new WaitForSeconds (1f);

				}
				if (renderer.material.mainTexture == textures [3])
						Application.LoadLevel ("GamePlay");
				
		}
}
