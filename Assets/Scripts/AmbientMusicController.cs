using UnityEngine;
using System.Collections;

[ RequireComponent(typeof (AudioSource)) ]
public class AmbientMusicController : MonoBehaviour {

    private AudioSource audioSource;
    private int lastTimeSamples = 0;

    void Awake() {
        GameObject.DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

	void FixedUpdate () {
        lastTimeSamples = audioSource.timeSamples;
	}

    void OnLevelWasLoaded(int level)
    {
        audioSource.timeSamples = lastTimeSamples;
    }
}
