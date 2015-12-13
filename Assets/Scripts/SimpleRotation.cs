using UnityEngine;
using System.Collections;

public class SimpleRotation : MonoBehaviour {
	public float xRotationSpeed;
    public float yRotationSpeed;
    public float zRotationSpeed;

	// Update is called once per frame
	void Update () {
        transform.Rotate(xRotationSpeed * Time.deltaTime, yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime);
	}
}
