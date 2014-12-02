using UnityEngine;
using System.Collections;

public class AnimateTiledTexture : MonoBehaviour
{
    public int Columns = 4;
    public int Rows = 4;
    public float RunTimeInSeconds;
 
    private Material materialCopy = null;
 	private float interval;
    void Start()
    {
        // Copy its material to itself in order to create an instance not connected to any other
        materialCopy = new Material(renderer.sharedMaterial);
        renderer.sharedMaterial = materialCopy;
 
        Vector2 size = new Vector2(1f / Columns, 1f / Rows);
        renderer.sharedMaterial.SetTextureScale("_MainTex", size);
        interval = RunTimeInSeconds/(Columns*Rows);
    }
 
    void OnEnable()
    {
        StartCoroutine(UpdateTiling());
    }
 
    private IEnumerator UpdateTiling()
    {
        float x = 0f;
        float y = 0f;
        Vector2 offset = Vector2.zero;
 

        for (int i = Rows-1; i >= 0; i--) // y
        {
            y = (float) i / Rows;

            for (int j = 0; j <= Columns-1; j++) // x
            {
                x = (float) j / Columns;

                offset.Set(x, y);

                renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
                yield return new WaitForSeconds(interval);
            }
        }

    }
}
