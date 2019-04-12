using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class OnLevelLoad : MonoBehaviour {


	public playerLevelInfo pli;
	public DeathCount dc; 
	//public PauseMenuInGame pmig;
	public int currentLevel;
	// public bool existsSaveFile;
	
	// Use this for initialization
	void Start () {
		// currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("Current Level from OnLevelLoad: " + currentLevel);
		//pmig.loadMenuPressed = true;
		SaveGameAtBeginning();
		// CheckForSaveFile();
	}
	
	// public bool CheckForSaveFile(){
	// 	string path = Application.persistentDataPath + "/player_info";
	// 	if (!File.Exists(path))
	// 		return false;
	// 	else
	// 		return true;
	// }

	public void SaveGameAtBeginning(){
			bool insideMainMenu = inMainMenu();
			//Debug.Log(insideMainMenu.ToString());
			if(insideMainMenu == false){
				  //dc.SaveDeaths();
				dc.LoadDeaths();
				//Debug.Log("dc.totalDeaths after load: " + dc.totalDeaths);
        // playerDeaths = dc.totalDeaths;
				Debug.Log("Not in Main Menu");
				pli.SavePlayer();
			}else{
				Debug.Log("In Main Menu");
				// pli.SavePlayer();
			}
	}

	public bool inMainMenu(){
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("Current Level from inMainMenu: " + currentLevel);
		if(currentLevel == 0){
			return true;
		}else{
			return false;
		}
	}
	// Update is called once per frame
}
