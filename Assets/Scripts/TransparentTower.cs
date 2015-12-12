﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransparentTower : MonoBehaviour {
	private List<Transform> transforms;

	// Use this for initialization
	void Start () {
		transforms = new List<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		//Reset the alpha value of the hit objects
		if(transforms.Count > 0){
			foreach(Transform t in transforms)
				t.GetComponent<MeshRenderer>().material.color = new Color(1f,1f,1f,1f);
			transforms.Clear();
		}

		Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position-transform.position);
		//Cast a ray from this object's transform the the watch target's transform.
		RaycastHit[] hits = Physics.RaycastAll(rayToCameraPos, Vector3.Distance(transform.position, Camera.main.transform.position));

		if(hits.Length > 0){
			foreach(RaycastHit hit in hits){
				if(hit.transform.parent != null) {
					for (int n = 0; n < hit.transform.parent.childCount; n++) {
						hit.transform.parent.GetChild(n).GetComponent<MeshRenderer>().material.color = new Color(1f,1f,1f,0.1f);
						transforms.Add(hit.transform.parent.GetChild(n).transform);
					}
				}
			}
		}

		Debug.DrawRay (rayToCameraPos.origin, rayToCameraPos.direction *  50, Color.yellow);
	}
}