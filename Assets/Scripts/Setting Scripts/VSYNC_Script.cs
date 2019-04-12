using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VSYNC_Script : MonoBehaviour {

	FPS_Script FPSscript;
	public Text VSyncText;
	// Use this for initialization
	void Start () {
		VSyncText = GetComponent<Text> ();
		FPSscript = GetComponent<FPS_Script>();
		QualitySettings.vSyncCount = 1;
		
	}
	
	public void EnableVSync(){
		//FPSscript.FPS_Enabled = false;
		VSyncText.text = "Enabled";
		QualitySettings.vSyncCount = 1;
	}

	public void DisableVSync(){
		VSyncText.text = "Disabled";
		QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = (int)FPSscript.FPS;
		//Debug.Log("FPS from VSYNC_Script: " + FPSscript.FPS);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
