using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float HorizontalPlayerSpeed = 35.0f;

    public int JumpHeight = 40;
    int JumpHeightScale = 10;

    Rigidbody rigidbodyComponent = null;

	void Start ()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
	    if(Input.GetKey(KeyCode.A))
        {
            Vector3 translation = new Vector3(HorizontalPlayerSpeed * -Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }

        if(Input.GetKey(KeyCode.D))
        {
            Vector3 translation = new Vector3(HorizontalPlayerSpeed * Time.deltaTime, 0, 0);
            transform.Translate(translation);
        }

        if(rigidbodyComponent != null && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    void Jump()
    {
        Vector3 jumpForce = JumpHeightScale * JumpHeight * Vector3.up;
        rigidbodyComponent.AddForce(jumpForce);
    }
}
