using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{

    PlayerBehaviour playerBehaviour;
    [SerializeField]
    Collider spawnWall;
    [SerializeField]
    GameObject player;

    //The list of new gameobject in the scene
    public static List<GameObject> movables = new List<GameObject>();
    // The speed at which the ground is traveling
    public int speed = 5;

    //The original Prefab of the ground
    public GameObject ground;
    //The temporary name of the instantiated ground getting added to the list
    public GameObject newGround;

    // The startpoint of the plane
    private float planeStartPoint = 150f;        //74.5f; Original value for timer spawn
    public static float timerForSpeed = 10;

    // The original wall for the level 
    public GameObject wall;
    // The temporary name of the instantiated wall getting added
    public GameObject newWall;

    //The original Prefab of the Obstacle
    public List<GameObject> obstacle = new List<GameObject>();
    //The temporary name of the instantiated obstacle getting added
    private GameObject newObstacle;

    //The time for which the plane will be created
    float timer = 4f;
    float originalTimer = 4f;

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
        playerBehaviour = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        //This controlls the time for when a new plane will be instantiated 
        timer -= Time.deltaTime;
        timerForSpeed -= Time.deltaTime;
        if (timer <= 0)
        {
            //newGround = Instantiate(ground, spawnPosition, Quaternion.identity);
            //newWall = Instantiate(wall, spawnPosition, Quaternion.identity);
            SpawnObstacles();
            //spawnPosition.z += 50;
            timer = originalTimer;
            if (playerBehaviour.maxSpeed == 6)
            {
                originalTimer = 2f;
            }
        }
        
    }

    void SpawnObstacles()
    {
        switch (Random.Range(0, obstacle.Count))
        {
            //Case 0 the blade, new vector represents the spawn position being mid on X, 6.5 on Y to fit the ceiling, and z in relation to the player
            case 0:
                newObstacle = Instantiate(obstacle[0], new Vector3(0, 10f, spawnPosition.z +25f), Quaternion.identity);
                break;
            //Case 1 the spiked log, new vector represents the spawn position being mid on X, 1 on Y and z in relation to the player
            case 1:
                newObstacle = Instantiate(obstacle[1], new Vector3(0, 1, spawnPosition.z), Quaternion.identity);
                break;
            //Case 2 the morningstar, new vector represents the spawn position being random on X axis, 10 on Y to fit the ceiling, and z in relation to the player
            case 2:
                newObstacle = Instantiate(obstacle[2], new Vector3(Random.Range(-4f, 4), 10, spawnPosition.z), Quaternion.identity);
                break;
            default:
                break;

        }
    }

    public void SpawnWall()
    {
        { 
            newGround = Instantiate(ground, new Vector3(spawnPosition.x,spawnPosition.y, spawnPosition.z + 24.5f), Quaternion.identity);
            newWall = Instantiate(wall, spawnPosition, Quaternion.identity);
            spawnPosition.z += 50;
            //spawnWall.transform.position = new Vector3(spawnWall.transform.position.x, spawnWall.transform.position.y, spawnPosition.z);
        }
        
    }
}
