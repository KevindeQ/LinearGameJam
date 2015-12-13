using Menu.Managers.SubMenus;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class FullscreenManager : MenuItemManager {
		//bool _fullscreen;

		//public RectTransform valueRect;

		// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Base.InputManager.LeftDown || Base.InputManager.RightDown) {
		//				_fullscreen = !_fullscreen;
		//			}

		//			valueRect.GetComponent<Text>().text = _fullscreen ? "Yes" : " No";

		//			if (Base.InputManager.ConfirmDown) {
		//				Screen.fullScreen = _fullscreen;
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}
		//		} else {
		//			valueRect.GetComponent<Text>().text = Screen.fullScreen ? "Yes" : " No";
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//public override void Activate () {
		//	base.Activate();
		//	_fullscreen = Screen.fullScreen;
		//}
	}
}