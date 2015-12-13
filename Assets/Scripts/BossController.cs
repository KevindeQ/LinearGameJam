using UnityEngine;
using System.Collections.Generic;

public class BossController : MonoBehaviour
{
    public Material StartWeakpointMaterial;
    public Material WeakpointMaterial;

    public int MaxHitCount;
    int NextHitIndex;
    List<Vector2> HitOrderList = new List<Vector2>();

    System.Random rnd = new System.Random();

	void Start ()
    {
        NextHitIndex = 0;

        SelectHitOrder();
        ModifyHitBoxes();
	}
	
	void Update ()
    {
	}

    void HitBox(Vector2 Coordinates)
    {
        if (Coordinates == HitOrderList[NextHitIndex])
            NextHitIndex += 1;
        else if (HitLosingBox(Coordinates))
            PlayerLost();

        if (NextHitIndex >= HitOrderList.Count)
            PlayerWin();
    }

    bool HitLosingBox(Vector2 Coordinates)
    {
        for(int Index = 0; Index < HitOrderList.Count; ++Index)
        {
            if (Coordinates == HitOrderList[Index])
                return true;
        }

        return false;
    }

    void PlayerWin()
    {

    }

    void PlayerLost()
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

            if (!HitOrderList.Contains(vector) && GameObject.Find(Vector2Name(vector)) != null)
                HitOrderList.Add(vector);

            tries += 1;
        }
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
