using UnityEngine;

public class RotateWaypoint : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of left-right rotation
    public float maxAngle = 30f; // Maximum left-right sway
    public float floatSpeed = 2f; // Speed of up-down movement
    public float floatHeight = 0.5f; // Maximum height difference for floating

    private float startRotationY;
    private float startY;

    void Start()
    {
        // Capture the initial Y-axis rotation and position
        startRotationY = transform.eulerAngles.y;
        startY = transform.position.y;
    }

    void Update()
    {
        // **Left-Right Rotation (Swing)**
        float angleOffset = Mathf.PingPong(Time.time * rotationSpeed, maxAngle * 2) - maxAngle;
        float newYRotation = startRotationY + angleOffset;

        // **Up-Down Floating Motion (Wave)**
        float newYPosition = startY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Apply rotation (keeping X and Z the same)
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, newYRotation, transform.eulerAngles.z);

        // Apply floating movement
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
