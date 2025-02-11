using UnityEngine;

public class FinalWaypointTrigger : MonoBehaviour
{
    public AudioSource finalAudio; // Assign an AudioSource for completion sound
    public GameObject nextStageObject; // Assign an object to activate the next stage

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers it
        {
            Debug.Log("Final waypoint reached!");

            // Play a sound when the final waypoint is reached
            if (finalAudio != null)
            {
                finalAudio.Play();
            }

            // Activate next stage elements
            if (nextStageObject != null)
            {
                nextStageObject.SetActive(true);
            }

            // Hide the final waypoint after reaching it
            gameObject.SetActive(false);
        }
    }
}
