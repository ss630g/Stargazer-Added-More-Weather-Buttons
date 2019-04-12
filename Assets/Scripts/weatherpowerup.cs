using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Random;

public class weatherpowerup : MonoBehaviour
{
    public CircleCollider2D bruh;
    public GameObject panel;
    public Button WeathertButton;
    public InputField location;
    public string yo = "";
    public Button currentLocation;
    public Button FirstCity;
    public Button SecondCity;
    public Button ThirdCity;
    public string [] cities ={"New York", "Mumbai", "Tianjin" , "Moscow", "Denver", "Los Angeles", "Tokyo", "Dhaka", "Istanbul", "Karachi", "Beijing",
    "Shanghai", "Singapore"};
    public string city1;
    public string city2;
    public string city3;
   //[SerializeField] private panel customPanel;
    void Start()
    {
         
        panel.SetActive(false);
        //WeathertButton.interactable = false;
        OnTriggerEnter2D(bruh);
        WeathertButton.onClick.AddListener(Exit);
        ShowWeather();
        getcity();
        showWeatherCity1(city1);
        showWeatherCity2(city2);
        showWeatherCity3(city3);
        Debug.Log("3 cities " + city1 + ", " + city2 + ", " + city3);
        currentLocation.onClick.AddListener(CurrentLocation);
        FirstCity.onClick.AddListener(CityLocation1);
        SecondCity.onClick.AddListener(CityLocation2);
        ThirdCity.onClick.AddListener(CityLocation3);
        //currentLocation.onClick.AddListener(CurrentLocation);
       // yo = location.text;
        //Debug.Log("this is the input "+yo);
        //OnTriggerExit2D(bruh);
    }

    void Update()
    {
      
    }
    void getcity() {
        System.Random rand = new System.Random();
        int index = rand.Next(0,12);
        int index2 = rand.Next(0,12);
        int index3 = rand.Next(0,12);
        city1 = cities[index];
        city2 = cities[index2];
        city3 = cities[index3];
        //return city;
    }
    void OnTriggerEnter2D(Collider2D bruh){
       
        if (bruh.name == "Player") {
            panel.SetActive(true);
            //gameObject.SetActive(false);
             //gameObject.renderer.enabled= false;
             //gameObject.GetComponent<Renderer>().enabled = false;
            
            }
            
     }

     void ShowWeather() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.ShowWeather());
     }

     void showWeatherCity1(string a) {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.ShowWeatherCity1(a));
     }
     void showWeatherCity2(string a) {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.ShowWeatherCity2(a));
     }
     void showWeatherCity3(string a) {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.ShowWeatherCity3(a));
     }

     void CurrentLocation() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeather());
        //urrentLocation.GetComponentInChildren<Text>().text = w.city;
        panel.SetActive(false);
     }
     void CityLocation1() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeatherIntput1(city1));
        panel.SetActive(false);
     }
    void CityLocation2() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeatherIntput2(city2));
        panel.SetActive(false);
     }
    void CityLocation3() {
         GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeatherIntput3(city3));
        panel.SetActive(false);
     }
     void Exit(){
         Debug.Log("Button has been clicked please check your button");
         //if (bruh.name == "Player") {
             yo = location.text;
            
            Debug.Log("this is the input "+yo);
           // }
           GameObject input = GameObject.Find("Weather");
        Weather w = input.GetComponent<Weather>();
        StartCoroutine(w.GetWeatherIntput(yo));
        panel.SetActive(false);
        //gameObject.SetActive(false);
     }

}
