using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;


// [RequireComponent(typeof(GameSession))]
public class playerLevelInfo : MonoBehaviour {


	public int level;
	//public float time;
	private float LevelLoadDelay = .95f;
	playerLoaded playerLoad;
	
 
	    AsyncOperation asyncLoadLevel;

IEnumerator LoadLevel(int newlevel)
{
	yield return new WaitForSeconds(0);
    SceneManager.LoadSceneAsync(newlevel);
	//yield return new WaitForSeconds(3);
    // while (!asyncLoadLevel.isDone)
    // {
    //     print("Loading the Scene");
    //     yield return null;
    // }
    //the game has finished loading
    // ScoreManager.Reset();
    // ScoreManager.AddPoints(blueWaffle);
    // //player.GetComponent<Transform> ().position = loadedPosition;
    // if (loaded(posX, posY, posZ))
    // {
    //     Debug.Log("I changed my position");
    // }
    // else
    // {
    //     Debug.Log("I didint change my position");
    // }
    // Time.timeScale = 1f;
}
	
	void Start() {
		// playerLoaded playerLoad;
		// GameObject thePlayer = GameObject.Find("Player");
		// playerLoad = thePlayer.GetComponent<playerLoaded>();
		level = SceneManager.GetActiveScene().buildIndex;
		// GameObject thePlayer = GameObject.Find("Player");
		// playerLoad = thePlayer.GetComponent<playerLoaded>();
		// if(playerLoad.loadpressed){
		// PlayerData data = SaveSystem.LoadPlayer();
		// Vector3 position;
		 
		// position.x = data.position[0];
		// position.y = data.position[1];
		// position.z = data.position[2];
		// transform.position = position;
		
		// playerLoad.loadpressed = false;
		//time = game.t;
		//}
	}

	public void SavePlayer()
	{
		//Vector3 position;
		//time = game.t;
		Debug.Log("Game is Saved");
		//Debug.Log("Player Pos - X:" + position.x + " Y:" + position.y + " Z:" + position.z);
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player_info";


		if (!File.Exists(path)){
			Debug.Log("No Save File was Loaded");
		}else {
		//playerLoad.loadpressed = true;
		Debug.Log("Game is Loaded");
		PlayerData data = SaveSystem.LoadPlayer();
		level = data.level;
		//time = data.time;
		//StartCoroutine(LoadLevel(level));	
		//SceneManager.LoadScene(level);
		Debug.Log("Level: " + level);
		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		transform.position = position;
		StartCoroutine(LoadLevel(level));
		}
	}

	/*IEnumerator LoadLevel(int newlevel)
       {
        //    animator.SetTrigger("FadeOut");
           yield return new WaitForSecondsRealtime(LevelLoadDelay);
        //    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
           SceneManager.LoadScene(newlevel);
	   }
	   */
}
