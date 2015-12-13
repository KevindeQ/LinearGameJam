using UnityEngine;
using System.Collections;

namespace Events {
	/// <summary>
	/// Game event that is fired during a game
	/// </summary>
	public class GameEvent {}

	///// <summary>
	///// Game event fired at the start of a match
	///// </summary>
	//#region New Match Event
	//public class MatchStartEvent : GameEvent {}
	//#endregion

	///// <summary>
	///// Game event fired when the match countdown start
	///// </summary>
	//#region Match Countdown Event
	//public class MatchCountdownEvent : GameEvent {}
	//#endregion

	///// <summary>
	///// Game event fired when the fighting is started
	///// </summary>
	//#region Match Fight Event
	//public class MatchFightEvent : GameEvent {}
	//#endregion

	///// <summary>
	///// Game event fired when a match reaches its time limit
	///// </summary>
	//#region Match Time Limit Event
	//public class MatchTimeLimitEvent : GameEvent {}
	//#endregion

	///// <summary>
	///// Game event fired when a player is killed
	///// </summary>
	//#region Player Killed Event
	//public class PlayerKilledEvent : GameEvent {
	//	/// <summary>
	//	/// Constructor for creating a new game event for when a player is killed
	//	/// </summary>
	//	/// <param name="victim">The player that is killed</param>
	//	/// <param name="killer">The player that has killed</param>
	//	public PlayerKilledEvent (Player victim, Player killer) {
	//		Victim = victim;
	//		Killer = killer;
	//	}

	//	/// <summary>
	//	/// The player that is killed
	//	/// </summary>
	//	public Player Victim {
	//		get; private set;
	//	}

	//	/// <summary>
	//	/// The player that has killed
	//	/// </summary>
	//	public Player Killer {
	//		get; private set;
	//	}
	//}
	//#endregion

	///// <summary>
	///// Game event fired when the match goes into Sudden Death
	///// </summary>
	//#region Sudden Death Event
	//public class SuddenDeathEvent : GameEvent {}
	//#endregion
}