using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public Material StartWeakpointMaterial;
    public Material WeakpointMaterial;

    public int MaxHitCount;

    public static List<Vector2> HitOrderList;
	public static List<Vector2> HitOrderPositionList;
	public static bool done;

    bool AlreadyWinning = false;
    bool AlreadyLosing = false;
    public static bool losing;

    System.Random rnd = new System.Random();

    void Awake()
    { 
        HitOrderList = new List<Vector2>();
        HitOrderPositionList = new List<Vector2>();

        losing = false;
        done = false;

        SelectHitOrder();
        ModifyHitBoxes();
    }
	
	void Update ()
    {
        if (!AlreadyWinning && Crosshair.orderHit >= HitOrderList.Count - 1)
        {
            AlreadyWinning = true;
            PlayerWin();
        }

        if(!AlreadyLosing && losing)
        {
            AlreadyLosing = true;
            PlayerLost();
        }
    }

    void PlayerWin()
    {
        float duration = 1.0f;
        float magnitude = 0.2f;
        StartCoroutine(Shake(duration, magnitude));
        StartCoroutine(DropBoss(duration));
        StartCoroutine(GoToWinScreen(5 * duration));
    }

    void PlayerLost()
    {
        StartCoroutine(GoToLoseScreen());
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x + originalCamPos.x, y + originalCamPos.y, originalCamPos.z); ;

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }

    IEnumerator DropBoss(float duration)
    {
        List<GameObject> objects = new List<GameObject>()
        {
            GameObject.Find("Boss/Mesh/Ring 6").gameObject,
            GameObject.Find("Boss/Mesh/Ring 5").gameObject,
            GameObject.Find("Boss/Mesh/Ring 4").gameObject,
            GameObject.Find("Boss/Mesh/Ring 3").gameObject,
            GameObject.Find("Boss/Mesh/Ring 2").gameObject,
            GameObject.Find("Boss/Mesh/Ring 1").gameObject,
        };

        yield return new WaitForSeconds(duration);

        foreach (GameObject obj in objects)
        {
            for (int ChildIndex = 0; ChildIndex < obj.transform.childCount; ++ChildIndex)
            {
                GameObject child = obj.transform.GetChild(ChildIndex).gameObject;
                child.AddComponent<Rigidbody>();
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator GoToWinScreen(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Menu Scene");
    }

    IEnumerator GoToLoseScreen()
    {
        SceneManager.LoadScene("Menu Scene");
        yield return null;
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
