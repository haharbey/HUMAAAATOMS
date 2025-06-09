using UnityEngine;

public class WaypointTrigger : MonoBehaviour
{
    public static int waypointsRemaining = 3; // Track how many waypoints are left
    public static bool soundPlayed = false;   // Prevent multiple audio plays
    public static AudioSource globalAudioSource; // Static reference to an AudioSource

    public AudioSource waypointAudioSource; // Assign the same AudioSource to all waypoints

    private void Start()
    {
        // Assign the first valid AudioSource as the global one
        if (globalAudioSource == null && waypointAudioSource != null)
        {
            globalAudioSource = waypointAudioSource;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers it
        {
            Debug.Log($"{gameObject.name} touched!");

            // Hide this waypoint
            gameObject.SetActive(false); 

            // Reduce the waypoint count
            waypointsRemaining--;

            // Play audio when all waypoints are touched
            if (waypointsRemaining == 0 && globalAudioSource != null && !soundPlayed)
            {
                Debug.Log("All waypoints cleared! Playing audio...");
                globalAudioSource.Play();
                soundPlayed = true; // Ensure it only plays once
            }
        }
    }
}
