using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{

    //The list of new gameobject in the scene
    public static List<GameObject> movables = new List<GameObject>();
    // The speed at which the ground is traveling
    public int speed = 5;

    //The original Prefab of the ground
    public GameObject ground;
    //The temporary name of the instantiated ground getting added to the list
    public GameObject newGround;
    // The startpoint of the plane
    private float planeStartPoint = 74.5f;
    public static float timerForSpeed = 10;

    //The original Prefab of the Obstacle
    public List<GameObject> obstacle = new List<GameObject>();
    //The temporary name of the instantiated obstacle getting added
    private GameObject newObstacle;

    //The time for which the plane will be created
    float timer = 2f;
    float originalTimer = 2f;

    // time for speed

    //The spawn position of each new plane
    Vector3 spawnPosition;

    // Update is called once per frame
    void Start()
    {
        //Instantiate(ground, new Vector3(0, 0, 24.5f), Quaternion.identity);
        movables.Clear();
        //Start by adding the first plane to the list
        movables.Add(GameObject.FindGameObjectWithTag("Floor"));
        spawnPosition = new Vector3(0, 0, 0 + planeStartPoint);
    }

    void Update()
    {
        //This controlls the time for when a new plane will be instantiated 
        timer -= Time.deltaTime;
        timerForSpeed -= Time.deltaTime;
        if (timer <= 0)
        {
            newGround = Instantiate(ground, spawnPosition, Quaternion.identity);
            SpawnObstacles();
            //newObstacle = Instantiate(obstacle[Random.Range(0,obstacle.Count)], new Vector3(Random.Range(-4f,4), Random.Range(1,4),25f), Quaternion.identity);
            spawnPosition.z += 50;
            timer = originalTimer;
            if (PlayerBehaviourMagnus.speed == 5)
            {
                originalTimer = 1f;
            }
        }
    }

    void SpawnObstacles()
    {
        //newObstacle = Instantiate(obstacle[Random.Range(0, obstacle.Count)], new Vector3(Random.Range(-4f, 4), Random.Range(1, 4), 25f), Quaternion.identity);
        switch (Random.Range(0, obstacle.Count))
        {
            case 0:
                newObstacle = Instantiate(obstacle[0], new Vector3(Random.Range(-4f, 4), Random.Range(1, 4), spawnPosition.z +25f), Quaternion.identity);
                break;
            case 1:
                newObstacle = Instantiate(obstacle[1], new Vector3(0, 0.5f, spawnPosition.z), Quaternion.identity);
                break;
            case 2:
                newObstacle = Instantiate(obstacle[2], new Vector3(Random.Range(-4f, 4), Random.Range(1, 4), spawnPosition.z), Quaternion.identity);
                break;
            default:
                break;

        }
    }
}
