using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicNumberScript1 : MonoBehaviour
{
    public static List<GameObject> movables = new List<GameObject>();
    public static int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        movables.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Debug.Log(movables.Count);
    }

    void MovePlayer()
    {
        for(int i = 0; i <= movables.Count; i++)
        {
          movables[i].transform.Translate(Vector3.back * (speed * Time.deltaTime));
            i++;
        }
    }
}
