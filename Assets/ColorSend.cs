using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using WindowsInput;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;
using TMPro;
using System.Threading;


public class JsonData
{
    public string id { get; set; }
    public string module { get; set; }
    public string function { get; set; }
};



public class ColorSend : MonoBehaviour
{


 




    int socketPort = 5252;

    public void OnPress()
    {



        string socketIp = "192.168.1.87";
        JsonData jsondata = new JsonData
        {
            id = "1",
            module = "lights",
            function = "read",

        };
        string json = JsonConvert.SerializeObject(jsondata);
        Debug.Log(json);
        Console.WriteLine(json);



        
    }

    public void OnCustomButtonPress()
    {
        Debug.Log("We pushed our custom button!");
    }
}