using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp.Demo;
using OpenCvSharp;

public class ContourFinder : WebCamera
{

    [SerializeField] private FlipMode imageFlip;
    [SerializeField] private float threshold = 75f;
    [SerializeField] private bool showProcessedImage = true;
    [SerializeField] private float curveAccuracy = 10f;
    [SerializeField] private float minArea = 5000f;

    private Mat image;
    private Mat processedImage = new Mat();
    private Point[][] contours;
    private HierarchyIndex[] hierarchy;


    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        image = OpenCvSharp.Unity.TextureToMat(input);
        //Do IP stuff here

        //Cv2.Flip(image, image, imageFlip);
        Cv2.CvtColor(image, processedImage, ColorConversionCodes.BGR2GRAY);
        Cv2.Threshold(processedImage, processedImage, threshold, 255, ThresholdTypes.BinaryInv);
        Cv2.FindContours(processedImage, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, null);

        foreach(Point[] contour in contours)
        {
            Point[] points = Cv2.ApproxPolyDP(contour, curveAccuracy, true);
            var area = Cv2.ContourArea(contour);

            if(area < minArea)
            {
                DrawContour(processedImage, new Scalar(127, 127, 127), 2, points);
            }
        }

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

    private void DrawContour(Mat Image, Scalar Color, int Thickness, Point[] Points)
    {
        for(int i = 0;i < Points.Length; i++)
        {

        }
    }
}
