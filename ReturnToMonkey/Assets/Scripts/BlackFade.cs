using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    public float entranceTime = 1f;
    public float exitTime = 1f;

    public CanvasGroup uiElement;

    public void FadeIn()
    {
        uiElement.alpha = 1;
        StartCoroutine(FadeCanvasGroup(uiElement, 1, 0, entranceTime));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(uiElement, 0, 1, exitTime));
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
