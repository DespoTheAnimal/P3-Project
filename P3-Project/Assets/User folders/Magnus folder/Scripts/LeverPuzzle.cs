using UnityEngine;
using Input = UnityEngine.Input;
using UnityEngine.SceneManagement;
public class LeverPuzzle : MonoBehaviour
{
    public float offset = 3f;

    public int lever1;
    public int lever2;
    public int lever3;
    public int leverCheck1;
    public int leverCheck2;
    public int leverCheck3;
    public bool doorOpen;


    // Start is called before the first frame update
    void Start()
    {
        doorOpen = false;
        lever1 = Random.Range(0, 2);
        lever2 = Random.Range(0, 2);
        lever3 = Random.Range(0, 2);

        leverCheck1 = Random.Range(0, 2);
        leverCheck2 = Random.Range(0, 2);
        leverCheck3 = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 cursorPos = Input.mousePosition;
        cursorPos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(cursorPos);

        if(lever1 == leverCheck1 &&  lever2 == leverCheck2 && lever3 == leverCheck3)
        {
            doorOpen=true;
            SceneManager.LoadScene(1);
        }


        Debug.Log(lever1);
        Debug.Log(lever2);
        Debug.Log(lever3);

        Debug.Log(leverCheck1);
        Debug.Log(leverCheck2);
        Debug.Log(leverCheck3);

    }

    //Vi fucking cool ez plebs 
   void OnTriggerStay(Collider other)
    {
        if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever1"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever1 == 0)
                {
                    lever1 = 1;
                }
                else lever1 = 0;
            }
                
        }
        else if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever2"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever2 == 0)
                {
                    lever2 = 1;
                }
                else lever2 = 0;
            }
        }

        else if (ColliderLever.enableClick && other.gameObject.CompareTag("Lever3"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever3 == 0)
                {
                    lever3 = 1;
                }
                else lever3 = 0;
            }
        }
    }
}
