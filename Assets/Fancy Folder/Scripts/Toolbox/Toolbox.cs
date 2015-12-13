using UnityEngine;

/// <summary>
/// Toolbox containing all the singletons. Is also a singleton itself
/// </summary>
public class Toolbox : Singleton<Toolbox> {

	protected Toolbox () {}

	/// <summary>
	/// Keep this and only this first instance persistent throug all scenes
	/// </summary>
	void Awake () {
		if (Instance == this) {
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Register a new singleton component in this toolbox
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	static public T RegisterComponent<T>() where T : Component {
		return Instance.GetOrAddComponent<T>();
	}

	#region Properties

	/// <summary>
	/// Game manager in this toolbox
	/// </summary>
	public static GameManager GameManager {
		get {
			return RegisterComponent<GameManager>();
		}
	}

	/// <summary>
	/// Event manager in this toolbox
	/// </summary>
	public static EventManager EventManager {
		get {
			return RegisterComponent<EventManager>();
		}
	}

	#endregion
}