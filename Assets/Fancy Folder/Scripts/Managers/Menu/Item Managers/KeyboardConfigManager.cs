using Menu.Managers.SubMenus;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class KeyboardConfigManager : MenuItemManager {
		//MatchInput _thisInput;
		//// bool _canSet;
		//List<KeyCode> _invalidButtons = new List<KeyCode> {
		//	KeyCode.Escape,
		//	KeyCode.Return,
		//	KeyCode.W,
		//	KeyCode.S,
		//	KeyCode.A,
		//	KeyCode.D,
		//	KeyCode.None
		//};

		//public RectTransform valueRect;

		//void Start () {
		//	_thisInput = (MatchInput)transform.GetSiblingIndex();
		//}

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			valueRect.GetComponent<Text>().text = "< Press Key >";

		//			if (Input.GetKeyDown(KeyCode.LeftShift)) {
		//				Base.MappingMenu.Profile.KeyboardConfig.Change(_thisInput, KeyCode.LeftShift);
		//				Back(true);
		//			}

		//			if (Input.GetKeyDown(KeyCode.RightShift)) {
		//				Base.MappingMenu.Profile.KeyboardConfig.Change(_thisInput, KeyCode.RightShift);
		//				Back(true);
		//			}

		//			if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.B)) {
		//				Back(false);
		//			}
		//		} else {
		//			KeyCode mappedButton = Base.MappingMenu.Profile.KeyboardConfig.Mapping[_thisInput];
		//			valueRect.GetComponent<Text>().text = mappedButton.ToString();
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//void OnGUI () {
		//	if (_activated) {
		//		Event e = Event.current;
		//		if (e.isKey && e.type == EventType.KeyDown  && !_invalidButtons.Contains(e.keyCode)) {
		//			Base.MappingMenu.Profile.KeyboardConfig.Change(_thisInput, e.keyCode);
		//			Back(true);
		//		}
		//	}

		//	// _canSet = true;
		//}

		//void Back (bool save) {
		//	if (save) {
		//		SaveLoad.Save();
		//	}

		//	Deactivate();
		//	((SubMenuManager)Parent).Enter();
		//}
	}
}