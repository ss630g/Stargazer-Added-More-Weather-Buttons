using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayTextAndTime : MonoBehaviour {

	public DeathCount dc;
	public Text deathText;
    public Text timerText;
	public GameObject saveFileDetails;
	public bool activate;

	// Use this for initialization
	void Start () {
		dc.LoadDeaths();
		float t = dc.totalTime;
		int playerDeaths = dc.totalDeaths;
		//string hours = 
		string minutes = ((int)t / 60).ToString("0");
        string seconds = (t % 60).ToString("0");
        timerText.text = "Time: " + minutes + "m " + seconds + "s";
        deathText.text = "Deaths: " + playerDeaths.ToString();
		ShowContinuePanel();
	}

	public void ShowContinuePanel(){
		string path = Application.persistentDataPath + "/death_info";
		if (!File.Exists(path)){
			activate = false;
		}else
			activate = true;

		if (!activate){
		 	Debug.Log("Dont show");
		 	saveFileDetails.SetActive(false);
		 }else{
		 	Debug.Log("Show");
		 	saveFileDetails.SetActive(true);
		 }
	}
		
		
		// if (!File.Exists(path)){
		// 	Debug.Log("Dont show");
		// 	saveFileDetails.SetActive(false);
		// }else
		// 	Debug.Log("Show");
		// 	saveFileDetails.SetActive(true);
	
	// Update is called once per frame

}
