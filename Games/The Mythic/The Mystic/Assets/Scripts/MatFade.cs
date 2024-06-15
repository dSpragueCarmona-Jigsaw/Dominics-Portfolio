using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatFade : MonoBehaviour {

    private float alpha;
  

    public bool alphaSwitch;

    // Use this for initialization
    void Start () {
        alpha = 1;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (alpha >= 0.4f)
        {
            alpha = alpha - .001f;
            alphaSwitch = false;
        }
        if (alpha <=1f)
        {
            alpha = alpha - .001f;
            alphaSwitch = true;
        }

        //int rgbshort = Mathf.RoundToInt(alpha);
        RenderSettings.skybox.SetColor("_Tint",new Color(.5f, 0, 0, alpha));

	}
}
