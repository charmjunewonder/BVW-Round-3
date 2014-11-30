//Exmaple Jam-o-Drum simulator
//Andrew Roxby 2/29/12

using UnityEngine;
using System.Collections;
using ETC.Platforms;

public class JamoKey : MonoBehaviour
{
	private KeyCode[] spinLeft = {KeyCode.A, KeyCode.Keypad4, KeyCode.Keypad1, KeyCode.Z};
	private KeyCode[] spinRight = {KeyCode.D, KeyCode.Keypad6, KeyCode.Keypad3, KeyCode.C};
	private KeyCode[] hit = {KeyCode.S, KeyCode.Keypad5, KeyCode.Keypad2, KeyCode.X};
	
	public JamoDrum jamoDrum;
	public int spinsPerFrame;
	
	void Update()
	{
		if(jamoDrum==null) return;
		for(int i = 0; i<4; i++)
		{
			if(Input.GetKey(spinLeft[i])) 
				jamoDrum.InjectSpin(i+1, -spinsPerFrame);
			if(Input.GetKey(spinRight[i])) 
				jamoDrum.InjectSpin(i+1, spinsPerFrame);
			if(Input.GetKeyDown(hit[i])) 
				jamoDrum.HandleJodHit(i+1);
		}
	}
}
