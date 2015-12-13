using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    private float yaw = 0;
    public float yawSensitivity = 1.0f;
    public float yawMin = -30f;
    public float yawMax = 30f;

    private float pitch = 0;
    public float pitchSensitivity = 0f;
    public float pitchMin = 0f;
    public float pitchMax = 0f;

    private Quaternion initialRotation;

	public Vector3 temp;
	public int zValue = 0;
    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        yaw = Mathf.Clamp(yaw + Input.GetAxis("Mouse X") * yawSensitivity, yawMin, yawMax);
		pitch = Mathf.Clamp(pitch + -Input.GetAxis("Mouse Y") * pitchSensitivity, -pitchMax, -pitchMin);
		transform.rotation = initialRotation * Quaternion.Euler(pitch, yaw, 0);

		if (Input.GetKey ("b")) {
			temp = new Vector3 (transform.position.x, transform.position.y, 10);
			transform.position = temp;
			yaw = Mathf.Clamp(yaw + Input.GetAxis("Mouse X") * yawSensitivity, yawMin, yawMax);
			pitch = Mathf.Clamp(pitch + -Input.GetAxis("Mouse Y") * pitchSensitivity, -pitchMax, -pitchMin);
			transform.rotation = initialRotation * Quaternion.Euler(pitch, yaw, 180);
		} 


    }



}
