using UnityEngine;
using Menu.Managers;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		switch (other.name) {
			case "Banana":
				MatrixManager.difference = 2;
				Destroy (other.gameObject);
				break;
			case "Minion":
				Destroy (other.gameObject);
				
				switch (SceneManager.GetActiveScene().buildIndex) {
					case 1:
						MenuManager.puzzleMatrix = LevelsMenuManager.level2matrix;
                        SceneManager.LoadScene("L2");
						break;
					case 2:
						MenuManager.puzzleMatrix = LevelsMenuManager.level3matrix;
                        SceneManager.LoadScene("L3");
						break;
					case 3:
						MenuManager.puzzleMatrix = LevelsMenuManager.level3matrix;
                        SceneManager.LoadScene("L3");
						break;
					default:
						break;
				}
				break;

		}

	}
}
