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
    [SerializeField] private PolygonCollider2D collider;

    private Mat image;
    private Mat processedImage = new Mat();
    private Point[][] contours;
    private HierarchyIndex[] hierarchy;
    private Vector2[] vectorList;


    protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
    {
        image = OpenCvSharp.Unity.TextureToMat(input);
        //Do IP stuff here

        //Cv2.Flip(image, image, imageFlip);
        Cv2.CvtColor(image, processedImage, ColorConversionCodes.BGR2GRAY);
        Cv2.Threshold(processedImage, processedImage, threshold, 255, ThresholdTypes.BinaryInv);
        Cv2.FindContours(processedImage, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple, null);

        collider.pathCount = 0;

        foreach(Point[] contour in contours)
        {
            Point[] points = Cv2.ApproxPolyDP(contour, curveAccuracy, true);
            var area = Cv2.ContourArea(contour);

            if(area < minArea)
            {
                DrawContour(processedImage, new Scalar(127, 127, 127), 2, points);

                //Her smider vi lige collideren på de linjer vi har tegner ovenfor.
                collider.pathCount++;
                collider.SetPath(collider.pathCount - 1, toVector2(points));
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

    //Unity Vector2 er det samme som OpenCV points, men man er nødt til at lave en lille omvej for at den fatter det.
    private Vector2[] toVector2(Point[] points)
    {
        vectorList = new Vector2[points.Length];
        for(int i = 0; i < points.Length; i++)
        {
            vectorList[i] = new Vector2(points[i].X, points[i].Y);
        }
        return vectorList;
    }

    private void DrawContour(Mat Image, Scalar Color, int Thickness, Point[] Points)
    {
        for(int i = 1;i < Points.Length; i++)
        {
            Cv2.Line(Image, Points[i-1], Points[i], Color, Thickness);
        }
        Cv2.Line(Image, Points[Points.Length-1], Points[0], Color, Thickness);
    }
}
