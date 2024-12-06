using UnityEngine;
using TMPro;

public class TextFadeInEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshPro component
    public float delayBeforeFade = 25f; // Delay before the text starts fading in
    public float fadeDuration = 2f;    // Duration of the fade-in effect

    void Start()
    {
        // Start with text fully transparent
        SetTextAlpha(0);

        // Begin the coroutine to delay and then fade in the text
        StartCoroutine(FadeInText());
    }

    private System.Collections.IEnumerator FadeInText()
    {
        // Wait for the delay
        yield return new WaitForSeconds(delayBeforeFade);

        // Perform the fade-in over the specified duration
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            SetTextAlpha(alpha);
            yield return null;
        }

        // Ensure the text is fully visible at the end
        SetTextAlpha(1);
    }

    private void SetTextAlpha(float alpha)
    {
        if (textMeshPro != null)
        {
            // Get the current color, modify its alpha, and reassign
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
    }
}
