using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System.Collections;

public class Trigger : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI texto;
    public float fadeDuration = 1f;
    public float showDuration = 2f;
    public float textMoveDistance = 50f;    
    public float textMoveSpeed = 20f;       
    bool triggered = false;
    float originalSize;
    Vector3 originalCameraOffset;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;


        StartCoroutine(ShowTextCoroutine());

    }

    IEnumerator ShowTextCoroutine()
    {
        Vector2 startPos = texto.rectTransform.anchoredPosition;
        Vector2 endPos = startPos + new Vector2(textMoveDistance, 0f);

        // Fade In
        float t = 0f;
        Color c = texto.color;
        c.a = 0f;
        texto.color = c;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float norm = Mathf.Clamp01(t / fadeDuration);
            c.a = Mathf.Lerp(0f, 1f, norm);
            texto.color = c;

            texto.rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, norm);

            yield return null;
        }

        float timer = 0f;
        while (timer < showDuration)
        {
            timer += Time.deltaTime;
            texto.rectTransform.anchoredPosition += Vector2.right * textMoveSpeed * Time.deltaTime;
            yield return null;
        }

        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float norm = Mathf.Clamp01(t / fadeDuration);
            c.a = Mathf.Lerp(1f, 0f, norm);
            texto.color = c;
            yield return null;
        }
    }

   
}
