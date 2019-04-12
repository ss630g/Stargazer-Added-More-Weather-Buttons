using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerLoaded : MonoBehaviour {


	// Use this for initialization
	
	public bool loadpressed = true;
	// Update is called once per frame
	void Start () {
		loadpressed = false;
		if(!loadpressed){
			SetPlayerPosition();
		}
	}

	public void SetLoadPressedTrue(){
		loadpressed = true;
	}

	void Update () {
	
	}
	public void SetPlayerPosition(){
		Vector3 position;
		// switch (SceneManager.GetActiveScene().buildIndex)
		// {
		// 	case 1:
		// 		position.x = (float)-65.08;
		// 		position.y = (float)-16.31;
		// 		position.z = 13f;
		// 		transform.position = position;
		// 		loadpressed = false;
		// 	break;
		// 	case 2:
		// 		position.x = (float)-21.65;
		// 		position.y = (float)-16.83;
		// 		position.z = (float)-0.3;
		// 		transform.position = position;
		// 		loadpressed = false;
		// 	break;
		// }

		 if(SceneManager.GetActiveScene().buildIndex == 2){
		 	position.x = (float)-21.65;
		 	position.y = (float)-16.83;
		 	position.z = (float)-0.3;
		 	transform.position = position;
		 	loadpressed = false;
		 }

	}

}
