using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DeathCount : MonoBehaviour {

	public int totalDeaths = 0;
	public float totalTime = 0f;
	public float startTime = 0f;
	public float stoppedTime = 0f;

	void Awake(){
		int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1){
         	Destroy(gameObject);
        }else{
             DontDestroyOnLoad(gameObject);
        } 
	}	
	
	public void SaveDeaths(){
		//Debug.Log("InSaveDeaths");
		SaveSystem.SaveDeaths(this);
	}

	public void LoadDeaths(){
		DeathData data = SaveSystem.LoadDeaths();
		string path = Application.persistentDataPath + "/death_info";
		if (!File.Exists(path)){
			totalDeaths = 0;
			totalTime = 0f;
			startTime = 0f;
			stoppedTime = 0f;
		}else{
			totalDeaths = data.deathsFromData;
			totalTime = data.timeFromData;
			startTime = data.startTimeFromData;
			stoppedTime = data.stoppedTimeFromData;
		}

		Debug.Log("InLoadDeaths: " + totalDeaths);
	}

	public void CreateNewGame(){
		Debug.Log("Game Reset");
		DeathData data = SaveSystem.LoadDeaths();
		totalDeaths = 0;
		totalTime = 0f;
		startTime = 0f;
		stoppedTime = 0f;
		SaveSystem.SaveDeaths(this);
	}
	

	// Update is called once per frame
	// void Update () {
		
	// }
}
