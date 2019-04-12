using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
	  // Use this for initialization
	  public int level;
	  //public float time;
	  public float[] position; 

	  public PlayerData (playerLevelInfo player)
	  {
	  	level = player.level;

		//time = player.time;

	  	position = new float[3];
	  	position[0] = player.transform.position.x;
	  	position[1] = player.transform.position.y;
	  	position[2] = player.transform.position.z;
	  }
}
