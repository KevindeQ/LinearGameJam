using UnityEngine;
using System.Collections.Generic;

public class CameraTargetController : MonoBehaviour
{
    public List<GameObject> targets;
    public int selected = 0;

    void FixedUpdate()
    {
        GameObject target = targets[selected];
        transform.position = Vector3.Lerp(transform.position, target.transform.position, 0.05f);

        if (Input.GetKey("1")) selected = 0;
        if (Input.GetKey("2")) selected = 1;
        if (Input.GetKey("3")) selected = 2;
        if (Input.GetKey("4")) selected = 3;
        if (Input.GetKey("5")) selected = 4;
        if (Input.GetKey("6")) selected = 5;
        if (Input.GetKey("7")) selected = 6;
        if (Input.GetKey("8")) selected = 7;
        if (Input.GetKey("9")) selected = 8;

        if (selected < 0) selected = 0;
        if (selected >= targets.Count) selected = targets.Count;
    }
}