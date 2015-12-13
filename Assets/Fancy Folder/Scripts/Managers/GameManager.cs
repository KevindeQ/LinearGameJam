using Events;
using Menu;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public const int _MAX_PLAYERS = 4;
    
	[SerializeField]
	MenuBase _menuBase;

	void Awake () {
		_menuBase.gameObject.SetActive(true);
	}

	void OnLevelWasLoaded (int level) {
		if (level != 0) {
			_menuBase.gameObject.SetActive(false);
		} else {
			_menuBase.gameObject.SetActive(true);
		}
	}

	void Update () {
		// if (_inGame) {
		//  if (Input.GetKey(KeyCode.Escape) || XCI.GetButton(XboxButton.B)) {
		//      Application.LoadLevel(0);
		//  }
		// }
	}

	#region Properties

	public MenuBase MenuBase {
		get {
			return _menuBase;
		}
	}

	#endregion
}