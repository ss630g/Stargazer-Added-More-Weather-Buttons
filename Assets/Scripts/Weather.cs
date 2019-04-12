using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;
using UnityEngine.Experimental.Networking;
using System.Xml;
using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;
//using Newtonsoft.Json;

public class Weather : MonoBehaviour
{
    public string ipcity = "";
     
    public string LocalIPAddress()
         {
             string localIP = "";
            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];
            return a4;
             
         }
    
  
    void Start()
    {
        //LocalIPAddress();
        //StartCoroutine(GetWeather("London"));
        //GetWeatherIntput();
    }

    public string city;
    public string temp;
    public string humidy;
    public string clouds;
    public string Title;
    public string bruh;

    public IEnumerator GetWeather()
    {
       string a= LocalIPAddress();
       string url = "api.ipgeolocation.io/ipgeo?apiKey=63675d7f1aa14c7fbeda269fb00bee57&ip="+a+"&fields=city";
        //WWW www = new WWW(url);
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
            ipcity = www.downloadHandler.text;
            string[] arr = ipcity.Split(':');
            ipcity = arr[2];
            ipcity = ipcity.Trim(new Char[]{'\"','}'});
            print("Loaded following: " + ipcity);
            print(www.downloadHandler.data);
            bruh = ipcity;

        }
           
        }
        print("BRUH:" + bruh);
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+bruh+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        //WWW qww = new WWW(qrl);
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            //GameObject input = GameObject.Find("SpringPowerUp");
            //weatherpowerup w = input.GetComponent<weatherpowerup>();

            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);

            //w.currentLocation.GetComponentInChildren<Text>().text = city + " " + temp + " F";
             float t;
             Debug.Log("this is temp: " + temp);
            t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
        }
        }
           
        
    }
     
     public IEnumerator ShowWeather()
    {
       string a= LocalIPAddress();
       string url = "api.ipgeolocation.io/ipgeo?apiKey=63675d7f1aa14c7fbeda269fb00bee57&ip="+a+"&fields=city";
        //WWW www = new WWW(url);
        using (UnityWebRequest www = UnityWebRequest.Get(url)) {
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
            ipcity = www.downloadHandler.text;
            string[] arr = ipcity.Split(':');
            ipcity = arr[2];
            ipcity = ipcity.Trim(new Char[]{'\"','}'});
            print("Loaded following: " + ipcity);
            print(www.downloadHandler.data);
            bruh = ipcity;

        }
           
        }
        print("BRUH:" + bruh);
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+bruh+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        //WWW qww = new WWW(qrl);
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            GameObject input = GameObject.Find("SpringPowerUp");
            weatherpowerup w = input.GetComponent<weatherpowerup>();

            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);

            w.currentLocation.GetComponentInChildren<Text>().text = city + " " + temp + " F";
             /*float t;
             Debug.Log("this is temp: " + temp);
                t= float.Parse(temp);
                //Int32.TryParse(temp, out t);
                Debug.Log("this is t: " + t);
                if(t < 32)
                {
                    Debug.Log("Wrap to Winter");
                SceneManager.LoadScene(7);

                }
                else if(t >= 32 && t <= 70) {
                    Debug.Log("Wrap to Spring");
                SceneManager.LoadScene(1);
                }
                else if(t >= 90 && t <= 150) {
                    Debug.Log("Wrap to Summer");
                SceneManager.LoadScene(3);
                }
                else if(t > 70 && t < 90) {
                    Debug.Log("Wrap to Fall");
                SceneManager.LoadScene(6);
                }
                */
        }
        }
           
        
    }

     public IEnumerator ShowWeatherCity1(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city1;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            wp.FirstCity.GetComponentInChildren<Text>().text = city + " " + temp + " F";
            //float t;
             //Debug.Log("this is temp: " + temp);
            /* t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            */
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }

    public IEnumerator ShowWeatherCity2(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city2;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            wp.SecondCity.GetComponentInChildren<Text>().text = city + " " + temp + " F";
            //float t;
            // Debug.Log("this is temp: " + temp);
            /* t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            */
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }

    public IEnumerator ShowWeatherCity3(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city3;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            wp.ThirdCity.GetComponentInChildren<Text>().text = city + " " + temp + " F";
            //float t;
            // Debug.Log("this is temp: " + temp);
            /* t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            */
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }

    public IEnumerator GetWeatherIntput(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.yo;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            float t;
             Debug.Log("this is temp: " + temp);
            t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }

    public IEnumerator GetWeatherIntput1(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city1;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            float t;
             Debug.Log("this is temp: " + temp);
            t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }
    public IEnumerator GetWeatherIntput2(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city2;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            float t;
             Debug.Log("this is temp: " + temp);
            t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }
    public IEnumerator GetWeatherIntput3(string a)
    {
        GameObject input = GameObject.Find("SpringPowerUp");
        weatherpowerup wp = input.GetComponent<weatherpowerup>();
        a = wp.city3;
        string qrl = "http://api.openweathermap.org/data/2.5/find?q="+a+"&type=accurate&mode=xml&lang=nl&units=imperial&appid=4f258e4971d0c07f770b8bc4759fb32e";
        using (UnityWebRequest qww = UnityWebRequest.Get(qrl)) {
        yield return qww.SendWebRequest();
        if(qww.isNetworkError || qww.isHttpError)
        {
            print(qww.error);
        }
        else
        {
            print("Loaded following XML " + qww.downloadHandler.text);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(qww.downloadHandler.text);
            city = xmlDoc.SelectSingleNode("cities/list/item/city/@name").InnerText;
            temp = xmlDoc.SelectSingleNode("cities/list/item/temperature/@value").InnerText;
            humidy = xmlDoc.SelectSingleNode("cities/list/item/humidity /@value").InnerText;
            clouds= xmlDoc.SelectSingleNode("cities/list/item/clouds/@value").InnerText;
            Title = xmlDoc.SelectSingleNode("cities /list/item/weather/@value").InnerText;
            print("City: " + city);
            print("Temperature: " + temp);
            print("humidity: " + humidy);
            print("Cloud : " + clouds);
            print("Title: " + Title);
            float t;
             Debug.Log("this is temp: " + temp);
            t= float.Parse(temp);
            //Int32.TryParse(temp, out t);
            Debug.Log("this is t: " + t);
             if(t < 32)
            {
                Debug.Log("Wrap to Winter");
               SceneManager.LoadScene(7);

            }
            else if(t >= 32 && t <= 70) {
                Debug.Log("Wrap to Spring");
               SceneManager.LoadScene(1);
            }
            else if(t >= 90 && t <= 150) {
                Debug.Log("Wrap to Summer");
               SceneManager.LoadScene(3);
            }
            else if(t > 70 && t < 90) {
                Debug.Log("Wrap to Fall");
               SceneManager.LoadScene(6);
            }
            Debug.Log("this in weathe function " +  a);
        }
        }
           
        
    }


    void Awake()
    {
        //print("City YOLO: " + ipcity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
