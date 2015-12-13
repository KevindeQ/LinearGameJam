using Menu.Managers.SubMenus;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class MoveTypeManager : MenuItemManager {
		//bool _axisMove;

		//public RectTransform valueRect;

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Input.GetKeyDown(KeyCode.LeftArrow) || XCI.GetDPadDown(XboxDPad.Left) || Input.GetKeyDown(KeyCode.RightArrow) || XCI.GetDPadDown(XboxDPad.Right)) {
		//				_axisMove = !_axisMove;
		//			}

		//			valueRect.GetComponent<Text>().text = _axisMove ? "Stick" : " DPad";

		//			if (Input.GetKeyDown(KeyCode.Space) || XCI.GetButtonDown(XboxButton.A)) {
		//				Base.MappingMenu.Profile.ControllerConfig.AxisMove = _axisMove;
		//				SaveLoad.Save();
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}

		//			if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButtonDown(XboxButton.B)) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}
		//		} else {
		//			valueRect.GetComponent<Text>().text = Base.MappingMenu.Profile.ControllerConfig.AxisMove ? "Stick" : " DPad";
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//public override void Activate () {
		//	base.Activate();
		//	_axisMove = Base.MappingMenu.Profile.ControllerConfig.AxisMove;
		//}
	}
}