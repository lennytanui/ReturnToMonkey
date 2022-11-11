using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    public float fadeEntraceSpeed = 1;
    public float fadeExitSpeed = 1;

    public CanvasGroup uiElement;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Image>().material.color = new Color(0,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));

        //GetComponent<Image>().material.color += new Color(0f, 0f, 0f, fadeExitSpeed * Time.deltaTime);
    }
    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));

        //GetComponent<Image>().material.color -= new Color(0f, 0f, 0f, fadeEntraceSpeed * Time.deltaTime);
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime =0.5f)
    {
        float timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }

        print("done");
    }
}
