using UnityEngine;
using System.Collections.Generic;

public class CameraTargetController : MonoBehaviour
{
    public List<GameObject> targets;

    void Start ()
    {
        Selected = 1;
    }

    void LateUpdate()
    {

        GameObject target = targets[Selected];

		transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.05f);
		transform.LookAt (GameObject.FindGameObjectWithTag ("Player").transform.position);

        int prevSelected = Selected;
        if (Selected == 0 || Selected == 2) return;

        if (Input.GetKey("1")) Selected = 0;
        if (Input.GetKey("2")) Selected = 1;
        if (Input.GetKey("3")) Selected = 2;
        if (Input.GetKey("4")) Selected = 3;
        if (Input.GetKey("5")) Selected = 4;
        if (Input.GetKey("6")) Selected = 5;
        if (Input.GetKey("7")) Selected = 6;
        if (Input.GetKey("8")) Selected = 7;
        if (Input.GetKey("9")) Selected = 8;

        if (Selected < 0) Selected = 0;
        if (Selected >= targets.Count) Selected = targets.Count;

        

        if (prevSelected != Selected)
        {
            HasChanged = true;
        }

	
    }

    public int Selected { get; set; }

    public bool HasChanged { get; set; }
}