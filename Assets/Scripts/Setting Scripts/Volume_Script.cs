using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume_Script : MonoBehaviour {
	
    private AudioSource m_MyAudioSource;
	public float musicVolume = 1f;
    public int textnum = 100;
    public int VolText = 100;

	//public Text VolumeText;
    //Value from the slider, and it converts to volume level
    //public float m_MySliderValue;

    void Start()
    {
		//VolumeText = GetComponent<Text> ();
        m_MyAudioSource = GetComponent<AudioSource>();
		//VolumeText.text = (musicVolume*100).ToString();
        /*m_MyAudioSource.Play();*/
    }

     void Update(){
         m_MyAudioSource.volume = musicVolume;
        textnum = VolText;
         //VolumeText.text = (musicVolume*100).ToString();
     }

    public void UpdateWithSlider(float NewVolume)
    {
		
		//Volume = NewVolume;
        musicVolume = NewVolume/100;
        VolText = (int)NewVolume;
        //m_MyAudioSource.volume = musicVolume;
        
    }
}
