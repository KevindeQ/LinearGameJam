using UnityEngine;
using Menu.Managers;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour {
    bool nextLevel;

    void Update ()
    {
        if (nextLevel && transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
        {
            // To Boss
            if (SceneManager.GetActiveScene().buildIndex == LevelsMenuManager.levelMatrices.Count)
            {
                SceneManager.LoadScene("Boss");
            } else
            {
                MenuManager.puzzleMatrix = LevelsMenuManager.levelMatrices[SceneManager.GetActiveScene().buildIndex];
                SceneManager.LoadScene("L" + (SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
    }
	void OnTriggerEnter(Collider other) {
        switch (other.tag)
        {
            case "Drop":
                MatrixManager.difference = 2;
                Destroy(other.gameObject);
                break;
            case "EndPoint":
                nextLevel = true;
                break;
        }
	}
}
