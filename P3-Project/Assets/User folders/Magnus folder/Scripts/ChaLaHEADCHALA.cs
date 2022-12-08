using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChaLaHEADCHALA : MonoBehaviour
{
    float timer = 56;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SceneManager.LoadScene("HeadTrackingTutorial");
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("HeadTrackingTutorial");
        }
    }
}
