using Menu.Managers.SubMenus;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class ControllerConfigManager : MenuItemManager {
		//	MatchInput _thisInput;
		//	int _index;
		//	readonly object[] _validButtons = {
		//		XboxButton.A,
		//		XboxButton.B,
		//		XboxButton.X,
		//		XboxButton.Y,
		//		XboxButton.LeftBumper,
		//		XboxButton.RightBumper,
		//		XboxAxis.LeftTrigger,
		//		XboxAxis.RightTrigger
		//	};

		//	public RectTransform valueRect;

		//	void Start () {
		//		_thisInput = (MatchInput)transform.GetSiblingIndex();
		//	}

		//	// Update is called once per frame
		//	void Update () {
		//		if (!_firstFrame) {
		//			if (_activated) {
		//				if (Input.GetKeyDown(KeyCode.LeftArrow) || XCI.GetDPadDown(XboxDPad.Left)) {
		//					_index = (_index + _validButtons.Length - 1) % _validButtons.Length;
		//				}

		//				if (Input.GetKeyDown(KeyCode.RightArrow) || XCI.GetDPadDown(XboxDPad.Right)) {
		//					_index = (_index + 1) % _validButtons.Length;
		//				}

		//				string inputName;
		//				if (_validButtons[_index] is XboxButton) {
		//					inputName = ((XboxButton)_validButtons[_index]).ToString();
		//				} else {
		//					inputName = ((XboxAxis)_validButtons[_index]).ToString();
		//				}

		//				valueRect.GetComponent<Text>().text = inputName;

		//				if (Input.GetKeyDown(KeyCode.Space) || XCI.GetButtonDown(XboxButton.A)) {
		//					Base.MappingMenu.Profile.ControllerConfig.Change(_thisInput, _validButtons[_index]);
		//					SaveLoad.Save();
		//					Deactivate();
		//					((SubMenuManager)Parent).Enter();
		//				}

		//				if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.B)) {
		//					Deactivate();
		//					((SubMenuManager)Parent).Enter();
		//				}
		//			} else {
		//				object mappedButton = Base.MappingMenu.Profile.ControllerConfig.Mapping[_thisInput];

		//				string inputName;
		//				if (mappedButton is XboxButton) {
		//					inputName = ((XboxButton)mappedButton).ToString();
		//				} else {
		//					inputName = ((XboxAxis)mappedButton).ToString();
		//				}

		//				valueRect.GetComponent<Text>().text = inputName;
		//			}
		//		}

		//		GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//		_firstFrame = false;
		//	}

		//	public override void Activate () {
		//		base.Activate();
		//		object mappedButton = Base.MappingMenu.Profile.ControllerConfig.Mapping[_thisInput];
		//		_index = Array.IndexOf(_validButtons, mappedButton);
		//	}
	}
}