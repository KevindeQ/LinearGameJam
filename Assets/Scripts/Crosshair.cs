﻿using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public Texture2D cursorTexture;	
	int cursorSizeX = 16;  // Your cursor size x
	int cursorSizeY = 16; 
	RaycastHit hit;
	float range = 50;
	bool hitBoss = false;
	public static int orderHit = -1;

	LineRenderer line;
	void Start() {
		line = gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
		Cursor.visible = false;
	}

    void Awake()
    {
        orderHit = -1;
    }

	void OnGUI()
	{
		GUI.DrawTexture (new Rect(Event.current.mousePosition.x-cursorSizeX/2, Event.current.mousePosition.y-cursorSizeY/2, cursorSizeX, cursorSizeY), cursorTexture);
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			StopCoroutine("Fire");
			StartCoroutine("Fire");
            GetComponent<AudioSource>().Play();
		}
		//Debug.Log (orderHit);
	}

	IEnumerator Fire() {
		line.enabled = true;
		while (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			line.SetPosition(0, this.transform.position);
			if (Physics.Raycast (ray, out hit, range)) {
				//if (hit.collider.gameObject.tag == "Boss") {
					line.SetPosition(1, hit.point);
					//Debug.Log("hit");
				if (hit.collider.gameObject.transform.position.x == BossController.HitOrderPositionList [orderHit+1].x
				   && hit.collider.gameObject.transform.position.y == BossController.HitOrderPositionList [orderHit+1].y)
					hit.collider.gameObject.GetComponent<Renderer> ().material.color = Color.red;
				//}
				else {
                    BossController.losing = true;
				}
			}
			else
				line.SetPosition(1,ray.GetPoint(100));

			yield return null;
		}
		line.enabled = false;
		orderHit++;
	}
}
