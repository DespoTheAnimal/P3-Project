using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamImage : MonoBehaviour
{
    public string deviceName;
    WebCamTexture wct;

    public Texture2D heightMap;
    public Vector3 size = new Vector3(100, 10, 100);

    private string savePath = "/ Users / peter / Desktop";
    private int captureCounter;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        deviceName = devices[0].name;
        wct = new WebCamTexture(deviceName, 400, 30, 12);
        //Renderer.material.mainTexture = wct;
        wct.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeSnapShot();
        }
    }

    void TakeSnapShot()
    {
        Texture2D snap = new Texture2D(wct.width, wct.height);
        snap.SetPixels(wct.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(savePath + captureCounter.ToString() + ".png", snap.EncodeToPNG());
        captureCounter++;
    }
}
