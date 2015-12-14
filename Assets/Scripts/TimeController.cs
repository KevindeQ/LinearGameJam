using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {
    public float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

	    if (timer <= 0)
        {
            SceneManager.LoadScene("Menu Scene");
        }
	}
}
