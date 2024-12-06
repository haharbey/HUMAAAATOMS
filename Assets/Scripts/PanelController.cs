using UnityEngine;

public class PanelController : MonoBehaviour
{
    public AudioSource audioSource;    // The audio source for this panel
    public AudioClip audioClip;        // The audio clip to play for this panel
    public GameObject nextPanel;       // The next panel to activate
    public float delayBeforeAudio = 1f; // Delay (in seconds) before the audio starts

    void OnEnable()
    {
        StartCoroutine(HandlePanelFlow());
    }

    private System.Collections.IEnumerator HandlePanelFlow()
    {
        // Wait for the specified delay before playing the audio
        yield return new WaitForSeconds(delayBeforeAudio);

        PlayAudio();
    }

    private void PlayAudio()
    {
        if (audioSource != null && audioClip != null)
        {
            // Assign the audio clip and play it
            audioSource.clip = audioClip;
            audioSource.Play();

            // Wait for the audio to finish and then transition
            StartCoroutine(WaitForAudioToFinish());
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is not assigned!");
        }
    }

    private System.Collections.IEnumerator WaitForAudioToFinish()
    {
        // Wait until the audio finishes playing
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Transition to the next panel
        ShowNextPanel();
    }

    private void ShowNextPanel()
    {
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);  // Activate the next panel
            gameObject.SetActive(false);  // Deactivate the current panel
        }
        else
        {
            Debug.Log("No next panel assigned!");
        }
    }
}
