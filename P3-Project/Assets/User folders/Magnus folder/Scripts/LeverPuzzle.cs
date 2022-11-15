using UnityEngine;
using Input = UnityEngine.Input;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.UI;

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

    public bool lever1Active;
    public bool lever2Active;
    public bool lever3Active;

    [SerializeField] private GameObject leverb1;
    [SerializeField] private GameObject leverb2;
    [SerializeField] private GameObject leverb3;

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

        //Lever1Click();
    }

   /* void Lever1Click()
    {
        if (ColliderLever.enableClick && GameObject.FindGameObjectWithTag("Lever1"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever1 == 0)
                {
                    lever1 = 1;
                    leverb1.GetComponent<Animator>().Play("LeverUp");
                }
                else lever1 = 0;
                leverb1.GetComponent<Animator>().Play("Idle");
            }

        }
        else if (ColliderLever.enableClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever2 == 0)
                {
                    lever2 = 1;
                    leverb2.GetComponent<Animator>().Play("LeverUp");
                }
                else lever2 = 0;
                leverb2.GetComponent<Animator>().Play("Idle");
            }
        }

        else if (ColliderLever.enableClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (lever3 == 0)
                {
                    lever3 = 1;
                    leverb3.GetComponent<Animator>().Play("LeverUp");
                }
                else lever3 = 0;
                leverb3.GetComponent<Animator>().Play("Idle");
            }
        }
    }*/

    private void OnMouseDown()
    {
        if(lever1Active)
        {
            if (lever1 == 0)
            {
                lever1 = 1;
                leverb1.GetComponent<Animator>().Play("LeverUp");
            }
            else lever1 = 0;
            leverb1.GetComponent<Animator>().Play("Idle");
        }
        else if (lever2Active)
        {
            if (lever2 == 0)
            {
                lever2 = 1;
                leverb2.GetComponent<Animator>().Play("LeverUp");
            }
            else lever2 = 0;
            leverb2.GetComponent<Animator>().Play("Idle");
        }
        else if (lever3Active)
        {
            if (lever3 == 0)
                {
                    lever3 = 1;
                    leverb3.GetComponent<Animator>().Play("LeverUp");
                }
                else lever3 = 0;
                leverb3.GetComponent<Animator>().Play("Idle");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Lever1"))
        {
            lever1Active = true;
        }
        else if (other.gameObject.CompareTag("Lever2"))
        {
            lever2Active = true;
        }
        else if (other.gameObject.CompareTag("Lever3"))
        {
            lever3Active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Lever1"))
        {
            lever1Active = false;
        }
        else if (other.gameObject.CompareTag("Lever2"))
        {
            lever2Active = false;
        }
        else if (other.gameObject.CompareTag("Lever3"))
        {
            lever3Active = false;
        }
    }
    //Vi fucking cool ez plebs 
}
