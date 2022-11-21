using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KeyTutorial : MonoBehaviour
{
    [SerializeField] private TMP_Text firstText, secondText;
    private bool firstStep = false;
    [SerializeField] private Button beginButton;

    private void Awake()
    {
        secondText.enabled = false;
        beginButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOutCR(firstText));
            //firstText.enabled = false;
            secondText.enabled = true;
            StartCoroutine(FadeInKEY(secondText));

            beginButton.gameObject.SetActive(true);
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
