using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVolumetext : MonoBehaviour {

	//public AudioSource m_MyAudioSource;

	Text VolumeText;
	Volume_Script volumescript;
	// Use this for initialization
	void Start () {
		GameObject vol = GameObject.Find("SoundEffectsPlayer");
		volumescript = vol.GetComponent<Volume_Script>();
		VolumeText = GetComponent<Text> ();
	}

	void Update(){
		VolumeText.text = (volumescript.textnum).ToString();
	}

	// public void UpdateVolumeNum(float newVolumeNum){
	// 	VolumeText.text = (newVolumeNum*100f).ToString();
	// }
	// Update is called once per frame
	
}
