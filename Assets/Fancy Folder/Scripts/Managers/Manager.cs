using UnityEngine;

public abstract class Manager<T> : MonoBehaviour, IManager where T : Base {
	T _base;
	bool _firstSearch; // Boolean indicating whether we have already searched for base or not

	public virtual void Enable () {
		enabled = true;
	}

	public virtual void Disable () {
		enabled = false;
	}

	#region Properties

	public T Base {
		get {
			return GetComponentInParent<T>();
		}
	}

	#endregion
}