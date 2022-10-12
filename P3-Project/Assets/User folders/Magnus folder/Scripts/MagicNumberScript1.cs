using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicNumberScript1 : MonoBehaviour
{
    public List<GameObject> movables = new List<GameObject>();
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        foreach(GameObject gaem in GameObject.FindGameObjectsWithTag("ILikeToMoveItMoveIt"))
        {
            gaem.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

    }
}
