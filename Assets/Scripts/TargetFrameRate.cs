using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour {

	public int frameRate = 60;
	public int vSyncToggle = 0;

	// Use this for initialization
	private void Awake () {
		if(vSyncToggle == 0){
			Application.targetFrameRate = frameRate;
		}else{
			QualitySettings.vSyncCount = vSyncToggle;
		}
	}
}
