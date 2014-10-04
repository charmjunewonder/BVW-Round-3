using UnityEngine;
using System.Collections;

public class ColorAlphaChange : MonoBehaviour {

	public string ShaderColorName = "_Color";
	public float StartDelay = 0;
	public float FadeInSpeed = 0;
	public float EndDelay = 0;
	public float FadeOutSpeed = 0;
	
	private Material mat;
	private Color oldColor, currentColor;
	private float oldAlpha, alpha;
	

	private void Start()
	{

		mat = renderer.material;
		oldColor = mat.GetColor(ShaderColorName);
		oldAlpha = 0;
		alpha = 0;
		
		currentColor = oldColor;
		currentColor.a = 0;
		mat.SetColor(ShaderColorName, currentColor);		
		Invoke("FadeIn", StartDelay);
		Invoke("FadeOut", EndDelay);

	}
		
	private void FadeIn()
	{
		alpha = oldAlpha + Time.deltaTime / FadeInSpeed;
		if (alpha >= oldColor.a) {
			alpha = oldColor.a;
			Invoke("FadeOut", EndDelay);
		} 
		currentColor.a = alpha;
		mat.SetColor(ShaderColorName, currentColor);
		oldAlpha = alpha;
	}
	
	private void FadeOut()
	{
		alpha = oldAlpha - Time.deltaTime / FadeOutSpeed;
		if (alpha <= 0) {
			alpha = 0;
		}
		currentColor.a = alpha;
		mat.SetColor(ShaderColorName, currentColor);
		oldAlpha = alpha;
	}

}
