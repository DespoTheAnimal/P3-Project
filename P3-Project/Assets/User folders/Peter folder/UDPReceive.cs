using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

//Script downloaded from: https://www.computervision.zone/courses/3d-head-tracking-with-car-movement/
public class UDPReceive : MonoBehaviour
{

    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;
    public string data;
    

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

}
