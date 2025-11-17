using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Trigger : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI texto;
    public Image imagen;

    [Header("Particles")]
    public ParticleSystem particles;

    [Header("Animation")]
    public float fadeDuration = 1f;
    public float showDuration = 2f;
    public float textMoveDistance = 50f;
    public float textMoveSpeed = 20f;

    GameObject uiObject;
    bool triggered = false;

    private void Awake()
    {
        if (texto == null && imagen == null)
            Debug.LogWarning("Assign a TextMeshProUGUI OR an Image to Trigger script.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        StartCoroutine(ShowUICoroutine());
    }

    IEnumerator ShowUICoroutine()
    {
        Graphic ui = texto != null ? (Graphic)texto : imagen;
        RectTransform rect = ui.rectTransform;
        uiObject = ui.gameObject;

        // If object is disabled, activate it
        if (!uiObject.activeSelf)
            uiObject.SetActive(true);

        // 🔥 PLAY PARTICLES
        if (particles != null)
            particles.Play();

        Vector2 startPos = rect.anchoredPosition;
        Vector2 endPos = startPos + new Vector2(textMoveDistance, 0f);

        float t = 0f;
        Color c = ui.color;
        c.a = 0f;
        ui.color = c;

        // Fade In + Move
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float norm = Mathf.Clamp01(t / fadeDuration);

            c.a = Mathf.Lerp(0f, 1f, norm);
            ui.color = c;

            rect.anchoredPosition = Vector2.Lerp(startPos, endPos, norm);
            yield return null;
        }

        // Slide during show time
        float timer = 0f;
        while (timer < showDuration)
        {
            timer += Time.deltaTime;
            rect.anchoredPosition += Vector2.right * textMoveSpeed * Time.deltaTime;
            yield return null;
        }

        // Fade Out
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float norm = Mathf.Clamp01(t / fadeDuration);

            c.a = Mathf.Lerp(1f, 0f, norm);
            ui.color = c;
            yield return null;
        }

        uiObject.SetActive(false);

        // 🔥 OPTIONAL: Stop particles after animation
        if (particles != null)
            particles.Stop();
    }
}
