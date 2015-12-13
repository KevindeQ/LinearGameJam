using UnityEngine;

/// <summary>
/// Base class
/// </summary>
public abstract class Base : MonoBehaviour {

	/// <summary>
	/// Enable this instance
	/// </summary>
	public virtual void Enable () {
		gameObject.SetActive(true);
	}

	/// <summary>
	/// Disable this instance
	/// </summary>
	public virtual void Disable () {
		gameObject.SetActive(false);
	}
}