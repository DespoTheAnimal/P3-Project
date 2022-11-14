using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILLCHARACTER : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(2);
        character.SetActive(false);
        
    }

}
