using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		switch (other.name) {
			case "Banana":
				MatrixManager.difference = 2;
				Destroy (other.gameObject);
				break;
			case "Minion":
				Destroy (other.gameObject);
				
				switch (Application.loadedLevel) {
					case 1:
						MenuManager.puzzleMatrix = MenuManager.level2matrix;
						Application.LoadLevel("L2");
						break;
					case 2:
						MenuManager.puzzleMatrix = MenuManager.level3matrix;
						Application.LoadLevel("L3");
						break;
					case 3:
						MenuManager.puzzleMatrix = MenuManager.level3matrix;
						Application.LoadLevel("L3");
						break;
					default:
						break;
				}
				break;

		}

	}
}
