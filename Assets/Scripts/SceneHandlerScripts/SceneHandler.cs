using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour {

	//  int currentSceneIndex = 0;
    //  int oldSceneIndex = -1;

    // private void Awake(){
	// 	DuplicateGameSessionCheck();
	// }

	// private void Update(){
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
 
    //  public void SaveScene()
    //  {
    //      int activeScene = SceneManager.GetActiveScene().buildIndex;
 
    //      PlayerPrefs.SetInt("ActiveScene", activeScene);
    //  }
 
    //  public void LoadScene()
    //  {
    //      int activeScene = PlayerPrefs.GetInt("ActiveScene");
 
    //      //SceneManager.LoadScene(activeScene);
 
    //      //Note: In most cases, to avoid pauses or performance hiccups while loading,
    //      //you should use the asynchronous version of the LoadScene() command which is: LoadSceneAsync()
 
    //      //Loads the Scene asynchronously in the background
    //      StartCoroutine(LoadNewScene(activeScene));
    //  }
 
    //  IEnumerator LoadNewScene(int sceneBuildIndex)
    //  {
    //      AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneBuildIndex);
    //      asyncOperation.allowSceneActivation = false;
 
    //      while (asyncOperation.progress < 0.9f)
    //      {
    //          yield return null;
    //      }
 
    //      asyncOperation.allowSceneActivation = true;
 
    //  }
}

