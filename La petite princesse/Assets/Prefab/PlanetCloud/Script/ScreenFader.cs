using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private float fadeStartTime;
    private bool isFading;

    public static event System.Action OnFadeComplete;

    void Start()
    {
        fadeImage = GetComponentInChildren<Image>();
        RotationScript.fading = FadeToBlack;
    }

    public void FadeToBlack()
    {
        if (isFading) return;

        fadeStartTime = Time.realtimeSinceStartup;
        isFading = true;
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        Color startColor = fadeImage.color;
        Color endColor = new Color(0f, 0f, 0f, 1f);

        while (isFading)
        {
            float elapsedTime = Time.realtimeSinceStartup - fadeStartTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Use unscaledDeltaTime to avoid being affected by Time.timeScale
            fadeImage.color = Color.Lerp(startColor, endColor, t / Time.timeScale);

            if (t >= 1f)
            {
                isFading = false;
                OnFadeComplete?.Invoke();
            }

            yield return null;
        }
    }
}