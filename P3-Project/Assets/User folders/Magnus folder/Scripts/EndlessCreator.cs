using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
public class EndlessCreator : MonoBehaviour
{
    //The list of new gameobject in the scene
    public static List<GameObject> movables = new List<GameObject>();
    // The speed at which the ground is traveling
    public  int speed = 5;

    //The original Prefab of the ground
    public GameObject ground;
    //The temporary name of the instantiated ground getting added to the list
    public GameObject newGround;
    // The startpoint of the plane
    [SerializeField]
    private int planeStartPoint = 25;

    //The original Prefab of the Obstacle
    public GameObject obstacle;
    //The temporary name of the instantiated obstacle getting added
    public GameObject newObstacle;

    //The time for which the plane will be created
    float timer = 2f;
    //The spawn position of each new plane
    Vector3 spawnPosition;


    // Update is called once per frame
    void Start()
    {
        //Start by adding the first plane to the list
        movables.Add(GameObject.FindGameObjectWithTag("ILikeToMoveItMoveIt"));
        spawnPosition = new Vector3(0, 0, 0 + planeStartPoint);
    }

    void Update()
    {
        //This controlls the time for when a new plane will be instantiated 
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            newGround = Instantiate(ground, spawnPosition, Quaternion.identity);
            newObstacle = Instantiate(obstacle, new Vector3(Random.Range(-4f,4), Random.Range(1,2),25f), Quaternion.identity);
            movables.Add(newGround);
            movables.Add(newObstacle);
            planeStartPoint += 50;
            timer = 2f;
        }
        MovePlane();
    }

    /// <summary>
    /// Takes each element of movables and translates them according to the speed variable
    /// </summary>
    void MovePlane()
    {
        foreach (GameObject go in movables)
        {
            go.transform.Translate(Vector3.back * (speed * Time.deltaTime));
        }
    }
}
