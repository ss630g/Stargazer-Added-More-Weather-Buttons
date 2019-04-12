using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Script : MonoBehaviour {

	VSYNC_Script VSYNCscript;
	public float FPS = 60;
	//public float updatedFPS;
	//public int updatedFPS;
	//public int updatedFPS = 100;
	//public bool FPS_Enabled = false;
	Text FPSText;
	// Text VSyncText;
	// Use this for initialization
	void Start(){
		FPSText = GetComponent<Text> ();
		// VSyncText = GetComponent<Text> ();
		// QualitySettings.vSyncCount = 1;
	}

	//void Update(){
		//updatedFPS = (int)FPS;
	//}

	public void UpdateFpsNum(float newFPS){
		//FPSText.text = newFPS.ToString();
		FPS = newFPS;
	}

	public void UpdateFPSText(){
		FPSText.text = FPS.ToString(); 
	}



	public void ApplyFrameRate(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = (int)FPS;
		Debug.Log("FPS is " + FPS);
	}

	// public int CurrentFPS(){
	// 	return FPS;
	// }

	// public void EnableVSync(){
	// 	VSyncText.text = "Enabled";
	// 	QualitySettings.vSyncCount = 1;
	// }

	// public void DisableVSync(){
	// 	VSyncText.text = "Disabled";
	// 	QualitySettings.vSyncCount = 0;
	// 	Application.targetFrameRate = (int)FPS;
	// }
}
