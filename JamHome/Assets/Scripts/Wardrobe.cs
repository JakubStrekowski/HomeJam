using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas.enabled = false;
	}
	
	public void EnableUI()
    {
        if(!canvas.enabled)
        canvas.enabled = true;
    }

    public void DisableUI()
    {
        if (canvas.enabled)
            canvas.enabled = false;
    }
}
