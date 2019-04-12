using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchMainMenu : MonoBehaviour {
	 int currentSceneIndex = 0;
	// Use this for initialization
	void Start () {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0){
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        
        // bool created = false;
        // Debug.Log("From Game Session, Awake: " + (SceneManager.GetActiveScene().buildIndex));
         if (numGameSessions > 1)
         {
             Destroy(gameObject);
         }
         else if(SceneManager.GetActiveScene().buildIndex == 0){
             Destroy(gameObject);
         }
         else
         {
             DontDestroyOnLoad(gameObject);
         }
        }
	}
}
