using UnityEngine;
using Menu.Managers;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour {
    bool nextLevel;

    void Update ()
    {
        if (nextLevel && transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
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
        }
    }
	void OnTriggerEnter(Collider other) {
		switch (other.tag) {
			case "Drop":
				MatrixManager.difference = 2;
				Destroy (other.gameObject);
				break;
			case "EndPoint":
                nextLevel = true;
				break;

		}

	}
}
