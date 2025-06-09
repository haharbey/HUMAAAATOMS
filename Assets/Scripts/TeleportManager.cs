using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportAnchor;  // Assign the teleport location
    public GameObject xrRig;          // Assign the XR Rig (player object)
    public Canvas uiCanvas;           // Assign the UI Canvas
    public AudioSource teleportSound; // Assign an AudioSource for teleport sound
    public CanvasGroup fadeScreen;    // Assign the UI Image CanvasGroup for fade effect

    public GameObject[] hiddenObjects; // Assign 3 hidden objects in the Inspector
    public float fadeDuration = 0.5f; // Duration of fade effect

    public void Teleport()
    {
        if (xrRig != null && teleportAnchor != null)
        {
            StartCoroutine(BlinkAndTeleport());
        }
        else
        {
            Debug.LogError("XR Rig or Teleport Anchor is not assigned!");
        }
    }

    private IEnumerator BlinkAndTeleport()
    {
        // Fade to black
        yield return StartCoroutine(FadeToBlack());

        // Teleport Player
        Transform xrCamera = xrRig.GetComponentInChildren<Camera>().transform;
        Vector3 offset = xrRig.transform.position - xrCamera.position;
        xrRig.transform.position = teleportAnchor.position + offset;
        xrRig.transform.rotation = teleportAnchor.rotation;

        // Hide UI Canvas
        if (uiCanvas != null) uiCanvas.gameObject.SetActive(false);

        // Delay before playing sound
        yield return new WaitForSeconds(1f);
        if (teleportSound != null) teleportSound.Play();

        // Fade back to clear
        yield return StartCoroutine(FadeToClear());

        // Wait 8 seconds, then reveal hidden objects
        yield return new WaitForSeconds(8f);
        RevealHiddenObjects();
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadeScreen.alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeScreen.alpha = 1;
    }

    private IEnumerator FadeToClear()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadeScreen.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeScreen.alpha = 0;
    }

    private void RevealHiddenObjects()
    {
        foreach (GameObject obj in hiddenObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
                Debug.Log($"{obj.name} has been revealed!");
            }
        }
    }
}
