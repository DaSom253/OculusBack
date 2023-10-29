using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCredit : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public float delayBeforeScrolling = 2f;

    private Text creditsText;
    private Coroutine scrollCoroutine;

    private void Start()
    {
        creditsText = GetComponent<Text>();
        StartCoroutine(StartCredits());
    }

    private IEnumerator StartCredits()
    {
        // Wait for a delay before scrolling starts
        yield return new WaitForSeconds(delayBeforeScrolling);

        // Get the initial position of the credits text
        Vector3 startPos = creditsText.rectTransform.position;

        // Calculate the target position based on the height of the credits text
        float targetPosY = startPos.y + creditsText.rectTransform.sizeDelta.y;

        // Start scrolling the credits
        scrollCoroutine = StartCoroutine(ScrollCredits(startPos, targetPosY));
    }

    private IEnumerator ScrollCredits(Vector3 startPos, float targetPosY)
    {
        while (creditsText.rectTransform.position.y < targetPosY)
        {
            // Move the credits text upwards
            Vector3 newPos = creditsText.rectTransform.position + Vector3.up * scrollSpeed * Time.deltaTime;
            creditsText.rectTransform.position = newPos;

            yield return null;
        }

        // Credits have finished scrolling
        scrollCoroutine = null;
    }

    public void SkipCredits()
    {
        if (scrollCoroutine != null)
        {
            StopCoroutine(scrollCoroutine);
            scrollCoroutine = null;
        }

        // You can perform any actions here when the credits are skipped
    }
}
