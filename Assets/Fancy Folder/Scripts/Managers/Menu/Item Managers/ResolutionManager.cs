using Menu.Managers.SubMenus;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class ResolutionManager : MenuItemManager {
		//int _index;

		//public RectTransform valueRect;

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Base.InputManager.LeftDown) {
		//				_index = (_index + Screen.resolutions.Length - 1) % Screen.resolutions.Length;
		//			}

		//			if (Base.InputManager.RightDown) {
		//				_index = (_index + 1) % Screen.resolutions.Length;
		//			}

		//			int width = Screen.resolutions[_index].width;
		//			int height = Screen.resolutions[_index].height;
		//			valueRect.GetComponent<Text>().text = string.Format("{0} x {1}", width, height);

		//			if (Base.InputManager.ConfirmDown) {
		//				Screen.SetResolution(width, height, Screen.fullScreen);
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}
		//		} else {
		//			int width = Screen.currentResolution.width;
		//			int height = Screen.currentResolution.height;
		//			valueRect.GetComponent<Text>().text = string.Format("{0} x {1}", width, height);
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//public override void Activate () {
		//	base.Activate();
		//	_index = Array.IndexOf(Screen.resolutions, Screen.currentResolution);
		//}
	}
}