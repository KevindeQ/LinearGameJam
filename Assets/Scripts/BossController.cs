using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossController : MonoBehaviour
{
    public Material StartWeakpointMaterial;
    public Material WeakpointMaterial;

    public int MaxHitCount;
	public static List<Vector2> HitOrderList = new List<Vector2>();
	public static List<Vector2> HitOrderPositionList = new List<Vector2>();
	public static bool done = false;
    System.Random rnd = new System.Random();

	void Start ()
    {
        SelectHitOrder();
        ModifyHitBoxes();
	}
	
	void Update ()
    {
	    
	}

    void SelectHitOrder()
    {
        int tries = 0;

        while(HitOrderList.Count < MaxHitCount && tries < (MaxHitCount + 50))
        {
            int x = rnd.Next(-5, 5);
            int y = rnd.Next(0, 10);
            Vector2 vector = new Vector2(x, y);

			if (!HitOrderList.Contains (vector) && GameObject.Find (Vector2Name (vector)) != null) {
				HitOrderList.Add (vector);
				HitOrderPositionList.Add (GameObject.Find (Vector2Name (vector)).transform.localPosition);
			}
            tries += 1;
        }
		done = true;
    }

    void ModifyHitBoxes()
    {
        if (HitOrderList.Count <= 0)
            return;

        GameObject box = GameObject.Find(Vector2Name(HitOrderList[0])).gameObject;
        box.GetComponent<Renderer>().material = StartWeakpointMaterial;

        for(int Index = 1; Index < HitOrderList.Count; ++Index)
        {
            box = GameObject.Find(Vector2Name(HitOrderList[Index])).gameObject;
            box.GetComponent<Renderer>().material = WeakpointMaterial;
        }
    }

    GameObject RecursiveFindChildObject(GameObject parent, string name)
    {
        Transform child = parent.transform.Find(name);
        if (child != null)
            return child.gameObject;

        for(int ChildIndex = 0; ChildIndex < parent.transform.childCount; ++ChildIndex)
        {
            child = parent.transform.GetChild(ChildIndex);

            GameObject obj = RecursiveFindChildObject(child.gameObject, name);
            if (obj != null)
                return obj;
        }

        return null;
    }

    string Vector2Name(Vector2 vector)
    {
        return "(" + ((int)vector.x).ToString() + "," + ((int)vector.y).ToString() + ")";
    }
}
