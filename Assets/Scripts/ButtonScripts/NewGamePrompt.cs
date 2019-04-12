using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class NewGamePrompt : MonoBehaviour {

	public Button newGameButton;
	public GameObject newGamePrompt;
	public DeathCount dc;
	public LevelFaderScript lfs;

	// Use this for initialization
	void Start () {
		newGameButton.onClick.AddListener(DecidePromptOrLoad);
	}
	
	// Update is called once per frame
	public void DecidePromptOrLoad(){
		string path = Application.persistentDataPath + "/death_info";
		if (!File.Exists(path)){
			dc.CreateNewGame();
			lfs.FadeToLevel();
		}else{
			Debug.Log("Prompt");
			newGamePrompt.SetActive(true);
		}
	}
}
