using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessSpawner : MonoBehaviour
{
    //The list of new gameobject in the scene
    ///public static List<GameObject> movables = new List<GameObject>();
    // The speed at which the ground is traveling
    // public int speed = 5;

    //The original Prefab of the ground
    public GameObject ground;
    //The temporary name of the instantiated ground getting added to the list
    public GameObject newGround;

    // The startpoint of the plane
    private float planeStartPoint = 150f;        //74.5f; Original value for timer spawn
   // public static float timerForSpeed = 10;

    // The original wall for the level 
    public GameObject wall;
    // The temporary name of the instantiated wall getting added
    public GameObject newWall;

    //The original Prefab of the Obstacle
    public List<GameObject> obstacle = new List<GameObject>();
    //The temporary name of the instantiated obstacle getting added
    private GameObject newObstacle;

    //The scene change gameobject
    [SerializeField] GameObject newLevel;
    [SerializeField] GameObject newLevel2;
    [SerializeField] GameObject newLevel3;

    private Scene currentScene;
    private string sceneName;


    //The time for which the plane will be created
    float timer = 4f;
    float originalTimer = 4f;

    // Test timer for the spawning of the levelchange 
    float timerr = 100f;

    internal int indexOfScene = 1;
    //The spawn position of each new plane
    Vector3 spawnPosition;

    // Update is called once per frame
    void Start()
    {
        spawnPosition = new Vector3(0, 0, 0 + planeStartPoint);

        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        //This controls the time for when a new obstacle will be instantiated 
        timer -= Time.deltaTime;
        timerr -= Time.deltaTime; // timer for the change of scene THIS IS A TEST
        Debug.Log(PlayerBehaviour.currentSpeed);
        if (currentScene.name != "HeadTrackingTutorial")
        {
            if (timer <= 0)
            {
                SpawnObstacles(); //Spawns the obstacles 
                timer = originalTimer; // sets the time back to it's original value 
                if (PlayerBehaviour.currentSpeed == 10) //Speeds up the time for which the obstacles will spawn 
                {
                    originalTimer = 1f;
                }
            }
            ChangeSceneSpawn(); // Change of scene
        }
        else
        {
            return;
        }    
    }

    /// <summary>
    /// Spawns the different obstacles randomly from the spawnposition
    /// </summary>
    void SpawnObstacles()
    {
        if (timerr > 0)
        {
            switch (Random.Range(0, obstacle.Count))
            {
                //Case 0 the blade, new vector represents the spawn position being mid on X, 6.5 on Y to fit the ceiling, and z in relation to the player
                case 0:
                    newObstacle = Instantiate(obstacle[0], new Vector3(0, 10f, spawnPosition.z + 25f), Quaternion.identity);
                    break;
                //Case 1 the spiked log, new vector represents the spawn position being mid on X, 1 on Y and z in relation to the player
                case 1:
                    newObstacle = Instantiate(obstacle[1], new Vector3(0, 1, spawnPosition.z), Quaternion.identity);
                    break;
                //Case 2 the morningstar, new vector represents the spawn position being random on X axis, 10 on Y to fit the ceiling, and z in relation to the player
                case 2:
                    newObstacle = Instantiate(obstacle[2], new Vector3(Random.Range(-4f, 4), 10, spawnPosition.z), Quaternion.identity);
                    break;

            }
        }
        else return;
    }


    /// <summary>
    /// Spawns the walls of the world as well as the ground the player walks on 
    /// </summary>
    public void SpawnWall()
    {
        { 
            newGround = Instantiate(ground, new Vector3(spawnPosition.x,spawnPosition.y, spawnPosition.z + 24.5f), Quaternion.identity);
            newWall = Instantiate(wall, spawnPosition, Quaternion.identity);
            spawnPosition.z += 50;
        }
        
    }


    /// <summary>
    /// Changes the instantiated prefrab, once a timer has reached zero, to prefab that changes the level
    /// </summary>
    void ChangeSceneSpawn()
    {
        if (timerr <= 0)
        {
            switch (indexOfScene)
            {
                case 1:
                    Instantiate(newLevel, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z + 24.5f), Quaternion.identity);
                    timerr = 10000f;
                    spawnPosition.z += 50;
                    break;
                case 2:
                    Instantiate(newLevel2, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(newLevel2, spawnPosition, Quaternion.identity);
                    break;
            }
        }
    }
}
