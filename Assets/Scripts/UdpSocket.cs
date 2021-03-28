/*
Created by Youssef Elashry to allow two-way communication between Python3 and Unity to send and receive strings

Feel free to use this in your individual or commercial projects BUT make sure to reference me as: Two-way communication between Python 3 and Unity (C#) - Y. T. Elashry
It would be appreciated if you send me how you have used this in your projects (e.g. Machine Learning) at youssef.elashry@gmail.com

Use at your own risk
Use under the Apache License 2.0

Modified by: 
Youssef Elashry 12/2020 (replaced obsolete functions and improved further - works with Python as well)
Based on older work by Sandra Fang 2016 - Unity3D to MATLAB UDP communication - [url]http://msdn.microsoft.com/de-de/library/bb979228.aspx#ID0E3BAC[/url]
*/

using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UdpSocket : MonoBehaviour
{
    Light lt;
    

    public float PFR = 0;
    public float PFG = 0;
    public float PFB = 0;

    public float PTR = 0;
    public float PTG = 0;
    public float PTB = 0;

    public float PTopR = 0;
    public float PTopG = 0;
    public float PTopB = 0;



    public float PLR = 0;
    public float PLG = 0;
    public float PLB = 0;


    public float PRR = 0;
    public float PRG = 0;
    public float PRB = 0;


    public float PWR = 0;
    public float PWG = 0;
    public float PWB = 0;

    public GameObject colarr;
    public GameObject panelL;
    public GameObject panelT;
    public GameObject panelS;
    void Start()
    {
        pythonTest = FindObjectOfType<PythonTest>(); // Instead of using a public variable
        lt = GetComponent<Light>();
        colarr = GameObject.Find("side");
        panelL = GameObject.Find("panbarL");
        panelT = GameObject.Find("panbarT");
        panelS = GameObject.Find("woofer");

    }




    [HideInInspector] public bool isTxStarted = false;

    [SerializeField] string IP = "127.0.0.1"; // local host
    [SerializeField] int rxPort = 8000; // port to receive data from Python on
    [SerializeField] int txPort = 8001; // port to send data to Python on

    // Create necessary UdpClient objects
    UdpClient client;
    IPEndPoint remoteEndPoint;
    Thread receiveThread; // Receiving Thread

    PythonTest pythonTest;


    //IEnumerator SendDataCoroutine() // DELETE THIS: Added to show sending data from Unity to Python via UDP
    //{
    //    while (true)
    //    {
    //        SendData("Sent from Unity: " + i.ToString());
    //        i++;
    //        yield return new WaitForSeconds(1f);
    //    }
    //}

    public void SendData(string message) // Use to send data to Python
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    void Awake()
    {
        // Create remote endpoint (to Matlab) 
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), txPort);

        // Create local client
        client = new UdpClient(rxPort);

        // local endpoint define (where messages are received)
        // Create a new thread for reception of incoming messages
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

        // Initialize (seen in comments window)
        print("UDP Comms Initialised");

        //StartCoroutine(SendDataCoroutine()); // DELETE THIS: Added to show sending data from Unity to Python via UDP
    }



    // Receive data, update packets received
    public void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);
               /// print(">> " + text);
                ProcessInput(text);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    public void ProcessInput(string input)
    {


       



        // PROCESS INPUT RECEIVED STRING HERE
        string[] strings = input.Split(':');

         PFR = float.Parse(strings[0]);
         PFG = float.Parse(strings[1]); 
         PFB = float.Parse(strings[2]); 

         PTR = float.Parse(strings[3]); 
         PTG = float.Parse(strings[4]);
         PTB = float.Parse(strings[5]); 

         PTopR = float.Parse(strings[6]); 
         PTopG = float.Parse(strings[7]); 
         PTopB = float.Parse(strings[8]); 

         PLR = float.Parse(strings[9]); 
         PLG = float.Parse(strings[10]); 
         PLB = float.Parse(strings[11]); 

         PRR = float.Parse(strings[12]); 
         PRG = float.Parse(strings[13]); 
         PRB = float.Parse(strings[14]); 

         PWR = float.Parse(strings[15]); 
         PWG = float.Parse(strings[16]); 
         PWB = float.Parse(strings[17]);

        


        ///print("> " + PFB);


       
       



        //foreach (var info in infos)
        //{
        //    print($"<{info}>");  
        // }

        if (!isTxStarted) // First data arrived so tx started
        {
            isTxStarted = true;
        }
    }

    //Prevent crashes - close clients and threads properly!
    void OnDisable()
    {
        if (receiveThread != null)
            receiveThread.Abort();

        client.Close();
    }


    void Update()
    {
        Color bruh2 = new Color(PFR, PFG, PFB);
        lt.color = (bruh2);
        var colar = colarr.GetComponent<Renderer>();
        colar.material.SetColor("_Color", bruh2);
        var side1 = panelL.GetComponent<Renderer>();
        side1.material.SetColor("_Color", bruh2);
        var side2 = panelT.GetComponent<Renderer>();
        side2.material.SetColor("_Color", bruh2);
        var side3 = panelS.GetComponent<Renderer>();
        side3.material.SetColor("_Color", bruh2);

    }

}