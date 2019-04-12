using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ControlButtonToggle : MonoBehaviour {

	public Button myButton;

	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		CheckToggable();
	}
	
	public void CheckToggable(){
		string path = Application.persistentDataPath + "/death_info";
		if (!File.Exists(path)){
			myButton.interactable = false;
		}else
			myButton.interactable = true;
	}
}
