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

        if (selected < 0) selected = 0;
        if (selected >= targets.Count) selected = targets.Count;
    }
}