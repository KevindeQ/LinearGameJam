using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		MatrixManager.difference = 2;
		Destroy(other.gameObject);
	}
}
