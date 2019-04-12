using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSeason : MonoBehaviour {

    public float LevelLoadDelay = .95f;
    // [SerializeField] float LevelExitSlowMo = .2f;
    // public Animator animator;
    // private int currentSceneIndex;
	int TotalLevels;
	int midLevel;
	int quarterLevel;
	private string CurrentSeason;
	private int CurrentLevelNumber;
	private int NextLevelNumber;
	int currentSceneIndex = 0;
    int oldSceneIndex = -1;

	 private void DuplicateGameSessionCheck(){
    int numGameSessions = FindObjectsOfType<GameSession>().Length;
        // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //  bool created = false;
        // Debug.Log("From Game Session, Called: " + (SceneManager.GetActiveScene().buildIndex));
         if (numGameSessions > 1 && oldSceneIndex != currentSceneIndex/*&& oldSceneIndex != currentSceneIndex*/)
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

	void Update(){
		// int numGameSessions = FindObjectsOfType<GameSession>().Length;
        // // currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // // bool created = false;
        // // Debug.Log("From Game Session, Awake: " + (SceneManager.GetActiveScene().buildIndex));
        //  if (numGameSessions > 1 && oldSceneIndex != currentSceneIndex)
        //  {
        //      Destroy(gameObject);
        //  }
        //  else if(SceneManager.GetActiveScene().buildIndex == 0){
        //      Destroy(gameObject);
        //  }
        //  else
        //  {
        //      DontDestroyOnLoad(gameObject);
        //  }
		 DuplicateGameSessionCheck();
		 oldSceneIndex = currentSceneIndex;
	}
	
	private void Awake()
    {
        // int numGameSessions = FindObjectsOfType<GameSession>().Length;
        // if (numGameSessions > 1 && oldSceneIndex != currentSceneIndex)
        // {
        //     Destroy(gameObject);
        // }
		//  else if(SceneManager.GetActiveScene().buildIndex == 0){
        //      Destroy(gameObject);
    	//  }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);
        // } 
		 DuplicateGameSessionCheck();
     }
	 

	void Start(){
		// Debug.Log("From Change Season, Start: " + SceneManager.GetActiveScene().buildIndex);
		// int numGameSessions = FindObjectsOfType<GameSession>().Length;
        // if (numGameSessions > 1)
        //  {
        //      Destroy(gameObject);
        //  }
        //  else if(SceneManager.GetActiveScene().buildIndex == 0){
        //      Destroy(gameObject);
        //  }
        //  else
        //  {
        //      DontDestroyOnLoad(gameObject);
        //  } 
		// Debug.Log(SceneManager.GetActiveScene().buildIndex);
		    // private void DuplicateGameSessionCheck(){
    // int numGameSessions = FindObjectsOfType<GameSession>().Length;
    //     currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     // bool created = false;
    //     // Debug.Log("From Game Session, Awake: " + (SceneManager.GetActiveScene().buildIndex));
    //      if (numGameSessions > 1 /*|| oldSceneIndex != currentSceneIndex*/)
    //      {
    //          Destroy(gameObject);
    //      }
    //      else if(SceneManager.GetActiveScene().buildIndex == 0){
    //          Destroy(gameObject);
    //      }
    //      else
    //      {
    //          DontDestroyOnLoad(gameObject);
    //      } 
    // }
		CurrentSeason = "";
		CurrentLevelNumber = SceneManager.GetActiveScene().buildIndex;
		TotalLevels = 8;
		midLevel = TotalLevels >> 1;
		quarterLevel = TotalLevels >> 2;
		NextLevelNumber = CurrentLevelNumber;
	}

	/* 
	0 - MainMenu
	1 - SpringLevel1
	2 - SpringLevel2
	3 - SummerLevel1
	4 - SummerLevel2
	5 - FallLevel1
	6 - FallLevel2
	7 - WinterLevel1
	8 - WinterLevel2
	*/

	public string getCurrentSeason()
	{
		//EX 1 and 2
		if(CurrentLevelNumber <= (TotalLevels / midLevel))
		{
			return "spring";
		}
		//EX 4 and 3
		else if((CurrentLevelNumber <= (TotalLevels / quarterLevel)) && (CurrentLevelNumber > (TotalLevels / midLevel)))
		{
			return "summer";
		}
		//EX 5 and 6
		else if(CurrentLevelNumber <= TotalLevels - (TotalLevels/midLevel) && CurrentLevelNumber > (TotalLevels / quarterLevel))
		{
			return "fall";
		}
		//EX 7 and 8
		else /*((CurrentLevelNumber <= TotalLevels) && (CurrentLevelNumber > TotalLevels - (TotalLevels/midLevel)))*/
		{
			return "winter";
		}
	}

	public void WarpToSpringWeather()
	{
		CurrentSeason = getCurrentSeason();
		NextLevelNumber = WarpToSpringReturnNumber();
	     StartCoroutine(LoadNextSeasonLevel());
		//SceneManager.LoadScene(NextLevelNumber);
	}

	public void WarpToSummerWeather()
	{
		CurrentSeason = getCurrentSeason();
		NextLevelNumber = WarpToSummerReturnNumber();
		 StartCoroutine(LoadNextSeasonLevel());
		//SceneManager.LoadScene(NextLevelNumber);
	}

	public void WarpToFallWeather()
	{
		CurrentSeason = getCurrentSeason();
		NextLevelNumber = WarpToFallReturnNumber();
		 StartCoroutine(LoadNextSeasonLevel());
		//SceneManager.LoadScene(NextLevelNumber);
	}

	public void WarpToWinterWeather()
	{
		CurrentSeason = getCurrentSeason();
		NextLevelNumber = WarpToWinterReturnNumber();
		 StartCoroutine(LoadNextSeasonLevel());
		//SceneManager.LoadScene(NextLevelNumber);
	}

	// public void DisplayCurrentSeason()
	// {
	// 	Debug.Log("Current Season:" + getCurrentSeason());
	// 	CurrentSeason = getCurrentSeason();
	// 	Debug.Log("Current Level: " + CurrentLevelNumber);
	// }

	// public int DetermineNewLevelFromSpring()
	// {
	// 		if(CurrentSeason == "spring")
	// 		{
	// 			return 0;
	// 		}
	// 		else if(CurrentSeason == "summer")
	// 		{
	// 			return CurrentLevelNumber + quarterLevel;
	// 		}
	// 		else if(CurrentSeason == "fall")
	// 		{
	// 			return CurrentLevelNumber + midLevel;
	// 		}
	// 		else 
	// 		{
	// 			return CurrentLevelNumber + midLevel + quarterLevel;
	// 		}
	// }

	// public int DetermineNewLevelFromSummer()
	// {
	// 		if(CurrentSeason == "spring")
	// 		{
	// 			return CurrentLevelNumber-quarterLevel;
	// 		}
	// 		else if(CurrentSeason == "summer")
	// 		{
	// 			return 0;
	// 		}
	// 		else if(CurrentSeason == "fall")
	// 		{
	// 			return CurrentLevelNumber + quarterLevel;
	// 		}
	// 		else 
	// 		{
	// 			return CurrentLevelNumber + midLevel;
	// 		}
	// }
	
	// public void DisplayNewSummerNumber()
	// {
	// 	Debug.Log("New Level Number: " + WarpToSummerReturnNumber());
	// 	// CurrentLevelNumber = WarpToSummerReturnNumber();
	// 	NextLevelNumber = WarpToSummerReturnNumber();
	// }

	// public void DisplayNewSpringNumber()
	// {
	// 	Debug.Log("New Level Number: " + WarpToSpringReturnNumber());
	// 	// CurrentLevelNumber = WarpToSpringReturnNumber();
	// 	NextLevelNumber = WarpToSpringReturnNumber();
	// }

	// public void DisplayNewFallNumber()
	// {
	// 	Debug.Log("New Level Number: " + WarpToFallReturnNumber());
	// 	// CurrentLevelNumber = WarpToFallReturnNumber();
	// 	NextLevelNumber = WarpToFallReturnNumber();
	// }

	// public void DisplayNewWinterNumber()
	// {
	// 	Debug.Log("New Level Number: " + WarpToWinterReturnNumber());
	// 	// CurrentLevelNumber = WarpToWinterReturnNumber();
	// 	NextLevelNumber = WarpToWinterReturnNumber();
	// }

	public int WarpToSpringReturnNumber()
	{
		if(CurrentSeason == "spring")
	 		{
				return CurrentLevelNumber;
	 		}
			else if(CurrentSeason == "summer")
	 		{
	 			return CurrentLevelNumber - quarterLevel;
	 		}
	 		else if(CurrentSeason == "fall")
	 		{
	 			return CurrentLevelNumber - midLevel;
	 		}
	 		else 
	 		{
	 			return CurrentLevelNumber - (quarterLevel+midLevel);
	 		}
	}

	public int WarpToSummerReturnNumber()
	{
		if(CurrentSeason == "spring")
	 		{
				return CurrentLevelNumber + quarterLevel;
	 		}
			else if(CurrentSeason == "summer")
	 		{
	 			return CurrentLevelNumber;
	 		}
	 		else if(CurrentSeason == "fall")
	 		{
	 			return CurrentLevelNumber - quarterLevel;
	 		}
	 		else 
	 		{
	 			return CurrentLevelNumber - midLevel;
	 		}
	}

	public int WarpToFallReturnNumber()
	{
		if(CurrentSeason == "spring")
	 		{
				return CurrentLevelNumber + midLevel;
	 		}
			else if(CurrentSeason == "summer")
	 		{
	 			return CurrentLevelNumber + quarterLevel;
	 		}
	 		else if(CurrentSeason == "fall")
	 		{
	 			return CurrentLevelNumber;
	 		}
	 		else 
	 		{
	 			return CurrentLevelNumber - quarterLevel;
	 		}
	}

	public int WarpToWinterReturnNumber()
	{
		if(CurrentSeason == "spring")
	 		{
				return CurrentLevelNumber + midLevel + quarterLevel;
	 		}
			else if(CurrentSeason == "summer")
	 		{
	 			return CurrentLevelNumber + midLevel;
	 		}
	 		else if(CurrentSeason == "fall")
	 		{
	 			return CurrentLevelNumber + quarterLevel;
	 		}
	 		else 
	 		{
	 			return CurrentLevelNumber;
	 		}
	}

	// public void WarpToFallSeason()
	// {

	// }

	// public void WarpToWinterSeason()
	// {

	// }
	

	// private int GetSeasonLevel()
	// {
	// 	if (CurrentSeason == "spring" && SelectedSeason == "summer"){

	// 	}
	// }

    // public void Warp()
    // {
    //       StartCoroutine(LoadNextSeasonLevel());
    // }

    IEnumerator LoadNextSeasonLevel()
       {
        //    animator.SetTrigger("FadeOut");
           yield return new WaitForSecondsRealtime(LevelLoadDelay);
        //    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
           SceneManager.LoadScene(NextLevelNumber);
	   }

    public void OnFadeComplete ()
	{
		// SceneManager.LoadScene(currentSceneIndex+1);
	}
}
