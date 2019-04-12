using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeathData{

	public int deathsFromData;
	public float timeFromData;
	public float stoppedTimeFromData;
	public float startTimeFromData;
	
	public DeathData (DeathCount deaths){
		deathsFromData = deaths.totalDeaths;
		timeFromData = deaths.totalTime;
		startTimeFromData = deaths.startTime;
		stoppedTimeFromData = deaths.stoppedTime;

		//Debug.Log("Deaths in DeathData: " + deathsFromData);
	}

	
}
