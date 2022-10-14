using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp.Demo;
using OpenCvSharp;

public class ContourFinder : WebCamera
{

    [SerializeField] private FlipMode imageFlip;
    [SerializeField] private float threshold = 96f;
    [SerializeField] private bool showProcessedImage = true;

    private Mat image;
    private Mat processedImage;


    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        image = OpenCvSharp.Unity.TextureToMat(input);
        //Do IP stuff here

        Cv2.Flip(image, image, imageFlip);
        Cv2.CvtColor(image, processedImage, ColorConversionCodes.BGR2GRAY);
        Cv2.Threshold(processedImage, processedImage, threshold, 255, ThresholdTypes.BinaryInv);



        //then we output
        if(output == null)
        {
            output = OpenCvSharp.Unity.MatToTexture(showProcessedImage ? processedImage : image);
        }
        else
        {
            OpenCvSharp.Unity.MatToTexture(showProcessedImage ? processedImage : image, output);
        }
        return true;
    }
}
