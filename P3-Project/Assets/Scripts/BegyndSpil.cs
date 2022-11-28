using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BegyndSpil : MonoBehaviour
{
    [SerializeField] private Button næste;

    void Start()
    {
        næste.onClick.AddListener(Next);
    }

    private void Next()
    {
        SceneManager.LoadScene("HeadTrackingTutorial");

    }

}
