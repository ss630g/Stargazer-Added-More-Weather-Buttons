using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuInGame : MonoBehaviour {

	[SerializeField] float LevelLoadDelay = 1f;
	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;
    public Animator animator;
	public bool loadMenuPressed;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(GameIsPaused)
			{
				Resume();
			} else {
				Pause();
			}
		}
	}

	void Start(){
		loadMenuPressed = false;
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu(){
		loadMenuPressed = true;
		Debug.Log("LoadMenu");
		Time.timeScale = 1f;
		StartCoroutine(LoadMainMenu());
	}

	 IEnumerator LoadMainMenu()
    // private void LoadNextLevel()
    {
        animator.SetTrigger("FadeOut");
        // Time.timeScale = LevelExitSlowMo;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        // Time.timeScale = 1f;
        // animator.SetTrigger("FadeOut");
        // animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(0);
    }

	public void QuitGame(){
		Debug.Log("QuitGame");
		Application.Quit();
	}

	 public void OnFadeComplete ()
	 {
	 	//  SceneManager.LoadScene(currentSceneIndex+1);
	 }
}
