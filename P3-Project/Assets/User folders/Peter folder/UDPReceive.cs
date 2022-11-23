using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

//Script downloaded from: https://www.computervision.zone/courses/3d-head-tracking-with-car-movement/
public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public static bool getStartRecieving; 
    public bool printToConsole = false;
    public string data;
    public List<int> PuzzleIndex = new List<int> { 3, 4, 5 };

    public void Start()
    {
        DontDestroyOnLoad(this);
        if (client != null)
        {
            client = new UdpClient(port);
        }
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void Update()
    {
        getStartRecieving = startRecieving;
        Debug.Log(getStartRecieving);
    }


    // receive thread
    private void ReceiveData()
    {
        client = new UdpClient(port);
            while (startRecieving)
            {

                try
                {
                    IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] dataByte = client.Receive(ref anyIP);
                    data = Encoding.UTF8.GetString(dataByte);

                    if (printToConsole) { print(data); }
                }
                catch (Exception err)
                {
                    print(err.ToString());
                }
            }
        
    }

    public void EnableBool()
    {
        if(startRecieving == false)
        {
            startRecieving=true;
        }
        else
        {
            startRecieving = false;
        }
    }

}
