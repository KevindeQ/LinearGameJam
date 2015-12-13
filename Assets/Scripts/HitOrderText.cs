using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HitOrderText : MonoBehaviour {

	public Text text;
	string textOrder ="";
	List<string> listVectors = new List<string> ();
	// Use this for initialization
	void Start () {
		text =  GetComponent<Text> ();
	}

	void CalculateVectors() {
		string textOrder;
		for (int n = 1; n < BossController.HitOrderList.Count; n++) {
			//.Log ("normal " + BossController.HitOrderList [n].x + " " + BossController.HitOrderList [n].y);
			//Debug.Log ("dif " + (BossController.HitOrderList [n].x - BossController.HitOrderList [n-1].x) + " " + (BossController.HitOrderList [n].y - BossController.HitOrderList [n-1].y));
			textOrder = "(" + (BossController.HitOrderList [n].x - BossController.HitOrderList [n-1].x) + ", " + (BossController.HitOrderList [n].y - BossController.HitOrderList [n-1].y) + ")";
			listVectors.Add (textOrder);
		}
	}

	void ShowText() {
		
	}

	// Update is called once per frame
	void Update () {

		if (listVectors.Count > 0 && Crosshair.orderHit >= 0 && listVectors [Crosshair.orderHit] != null) {
			text.text = listVectors [Crosshair.orderHit];
		}
		if (BossController.done) {
			BossController.done = false;
			CalculateVectors ();
		}
	
	}
}
