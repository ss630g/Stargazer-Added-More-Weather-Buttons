using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerDontDestroy : MonoBehaviour {

	//  int currentSceneIndex = 0;
    //  int oldSceneIndex = -1;

	// // Use this for initialization
	 private void Awake(){
		//  int numGameSessions = FindObjectsOfType<GameSession>().Length;
		//  if (numGameSessions > 1 /*&& oldSceneIndex != currentSceneIndex && oldSceneIndex != currentSceneIndex*/)
        //   {
        //       Destroy(gameObject);
        //   }
        // //   else if(SceneManager.GetActiveScene().buildIndex == 0){
        // //        Destroy(gameObject);
        // //   }
        //   else
        //   {
             //   DontDestroyOnLoad(gameObject);
        //   } 
	 	//DuplicateGameSessionCheck();
	 }



	//  private void Update(){
		 

	//  }
	// 	DuplicateGameSessionCheck();
	// 	oldSceneIndex = currentSceneIndex;

	// }

	//  private void DuplicateGameSessionCheck(){
    // 	int numGameSessions = FindObjectsOfType<GameSession>().Length;
    //     // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     //  bool created = false;
    //     //  Debug.Log("From Game Session, Called: " + (SceneManager.GetActiveScene().buildIndex));
    //      if (numGameSessions > 1 && oldSceneIndex != currentSceneIndex/*&& oldSceneIndex != currentSceneIndex*/)
    //      {
    //          Destroy(gameObject);
    //      }
    //      else if(SceneManager.GetActiveScene().buildIndex == 0){
    //           Destroy(gameObject);
    //      }
    //      else
    //      {
    //          DontDestroyOnLoad(gameObject);
    //      } 
    // }
}
