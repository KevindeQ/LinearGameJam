using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

public class EventManager : MonoBehaviour {
	public bool LimitQueueProcesing = false;
	public float QueueProcessTime = 0.0f;
	Queue _eventQueue = new Queue();

	public delegate void EventDelegate<T>(T e) where T : GameEvent;
	delegate void EventDelegate (GameEvent e);

	Dictionary<Type, EventDelegate> _delegates = new Dictionary<Type, EventDelegate>();
	Dictionary<Delegate, EventDelegate> _delegateLookup = new Dictionary<Delegate, EventDelegate>();
	Dictionary<Delegate, bool> _onceLookups = new Dictionary<Delegate, bool>();

	/// <summary>
	/// Every update cycle the queue is processed. If the queue processing is limited,
	/// a maximum processing time per update can be set which makes remaining events being
	/// processed during the next update loop.
	/// </summary>
	void Update () {
		float timer = 0.0f;
		while (_eventQueue.Count > 0) {
			if (LimitQueueProcesing) {
				if (timer > QueueProcessTime) {
					return;
				}
			}

			GameEvent evt = _eventQueue.Dequeue() as GameEvent;
			TriggerEvent(evt);

			if (LimitQueueProcesing) {
				timer += Time.deltaTime;
			}
		}
	}

	void OnApplicationQuit () {
		RemoveAll();
		_eventQueue.Clear();
		//Instance = null;
	}

	static EventManager Instance {
		get {
			return Toolbox.EventManager;
		}
	}

	EventDelegate AddDelegate<T>(EventDelegate<T> del) where T : GameEvent {
		// Early-out if we've already registered this delegate
		if (_delegateLookup.ContainsKey(del)) {
			return null;
		}

		// Create a new non-generic delegate which calls our generic one.
		// This is the delegate we actually invoke.
		EventDelegate internalDelegate = (e) => del((T)e);
		_delegateLookup[del] = internalDelegate;

		EventDelegate tempDel;
		if (_delegates.TryGetValue(typeof(T), out tempDel)) {
			_delegates[typeof(T)] = tempDel += internalDelegate;
		} else {
			_delegates[typeof(T)] = internalDelegate;
		}

		return internalDelegate;
	}

	public static void AddListener<T>(EventDelegate<T> del) where T : GameEvent {
		Instance.AddDelegate<T>(del);
	}

	public static void AddListenerOnce<T>(EventDelegate<T> del) where T : GameEvent {
		EventDelegate result = Instance.AddDelegate<T>(del);

		if (result != null) {
			// remember this is only called once
			Instance._onceLookups[result] = true;
		}
	}

	public static void RemoveListener<T>(EventDelegate<T> del) where T : GameEvent {
		EventDelegate internalDelegate;
		if (Instance._delegateLookup.TryGetValue(del, out internalDelegate)) {
			EventDelegate tempDel;
			if (Instance._delegates.TryGetValue(typeof(T), out tempDel)) {
				tempDel -= internalDelegate;
				if (tempDel == null) {
					Instance._delegates.Remove(typeof(T));
				} else {
					Instance._delegates[typeof(T)] = tempDel;
				}
			}

			Instance._delegateLookup.Remove(del);
		}
	}

	public static void RemoveAll () {
		Instance._delegates.Clear();
		Instance._delegateLookup.Clear();
		Instance._onceLookups.Clear();
	}

	public static bool HasListener<T>(EventDelegate<T> del) where T : GameEvent {
		return Instance._delegateLookup.ContainsKey(del);
	}

	public static void TriggerEvent (GameEvent e) {
		EventDelegate del;
		if (Instance._delegates.TryGetValue(e.GetType(), out del)) {
			del.Invoke(e);

			// remove listeners which should only be called once
			foreach (EventDelegate k in Instance._delegates[e.GetType()].GetInvocationList()) {
				if (Instance._onceLookups.ContainsKey(k)) {
					Instance._onceLookups.Remove(k);
				}
			}
		} else {
			Debug.LogWarning("Event: " + e.GetType() + " has no listeners");
		}
	}

	//Inserts the event into the current queue.
	public static bool QueueEvent (GameEvent evt) {
		if (!Instance._delegates.ContainsKey(evt.GetType())) {
			Debug.LogWarning("EventManager: QueueEvent failed due to no listeners for event: " + evt.GetType());
			return false;
		}

		Instance._eventQueue.Enqueue(evt);
		return true;
	}
}