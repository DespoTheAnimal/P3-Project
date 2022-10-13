using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

//Code is taken from tutorial: https://www.youtube.com/watch?v=RQ-2JWzNc6k&ab_channel=Murtaza%27sWorkshop-RoboticsandAI
public class UDPRecieve : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5022;
    public bool startReceiving = true;
    public bool printToConsole = false;
    public string data;

    private void Start()
    {
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while(startReceiving)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP);
                data = Encoding.UTF8.GetString(dataByte);

                if (printToConsole)
                {
                    print(data);
                }
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

}
