using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    private float yaw = 0;
    public float yawSensitivity = 1.0f;
    public float yawMin = -30f;
    public float yawMax = 30f;

    private float pitch = 0;
    public float pitchSensitivity = 1.0f;
    public float pitchMin = -10f;
    public float pitchMax = 10f;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        yaw = Mathf.Clamp(yaw + Input.GetAxis("Mouse X") * yawSensitivity, yawMin, yawMax);
        pitch = Mathf.Clamp(pitch + Input.GetAxis("Mouse Y") * pitchSensitivity, pitchMin, pitchMax);
        transform.rotation = initialRotation * Quaternion.Euler(pitch, yaw, 0);
    }

}
