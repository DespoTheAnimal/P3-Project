using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyTutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text firstText, secondText;
    [SerializeField] private TMP_Text firstHeadText, secondHeadText;
    private bool firstStep = false;
    [SerializeField] private Button beginButton;
    [SerializeField] private Button beginHButton;
    public bool isHeadTrack = false;

    private void Awake()
    {
        secondText.enabled = false;
        beginButton.gameObject.SetActive(false);
        secondHeadText.enabled = false;
        beginHButton.gameObject.SetActive(false);
        if (isHeadTrack == true)
        {
            firstText.enabled = false;
        }
        else
        {
            firstHeadText.enabled = false;
        }
    }

    private void Update()
    {
        if (isHeadTrack == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(FadeOutCR(firstHeadText));
                secondHeadText.enabled = true;
                StartCoroutine(FadeInKEY(secondHeadText));
                firstHeadText.enabled = false;
                beginHButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartCoroutine(FadeOutCR(firstText));
                secondText.enabled = true;
                StartCoroutine(FadeInKEY(secondText));
                firstText.enabled = false;
                beginButton.gameObject.SetActive(true);
            }
        }
        
    }

    //https://stackoverflow.com/questions/27885201/fade-out-unity-ui-text
    private IEnumerator FadeOutCR(TMP_Text text)
    {
        float duration = 0.75f; //0.75 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    private IEnumerator FadeInKEY(TMP_Text text)
    {
        float duration = 0.75f;
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / duration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
