using Menu.Managers.SubMenus;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class ProfilesManager : MenuItemManager {
		//int _index;

		//public RectTransform valueRect;

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Base.InputManager.LeftDown) {
		//				_index = (_index + SaveLoad.savedProfiles.Count - 1) % SaveLoad.savedProfiles.Count;
		//			}

		//			if (Base.InputManager.RightDown) {
		//				_index = (_index + 1) % SaveLoad.savedProfiles.Count;
		//			}

		//			valueRect.GetComponent<Text>().text = SaveLoad.savedProfiles[_index].Name;

		//			if (Base.InputManager.ConfirmDown) {
		//				Base.MappingMenu.Enable();
		//				Base.MappingMenu.Profile = SaveLoad.savedProfiles[_index];
		//				Base.Animator.SetBool("ToMapping", true);
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//				Base.SettingsMenu.Disable();
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}

		//			if (Base.InputManager.DeleteDown) {
		//				SaveLoad.savedProfiles.RemoveAt(_index);
		//				SaveLoad.Save();
		//				if (SaveLoad.savedProfiles.Count == 0) {
		//					Deactivate();
		//					((SubMenuManager)Parent).Enter();
		//				}
		//			}
		//		} else {
		//			string text = SaveLoad.savedProfiles.Count + " ";
		//			text += SaveLoad.savedProfiles.Count == 1 ? "Profile" : "Profiles";
		//			valueRect.GetComponent<Text>().text = text;
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//public override void Activate () {
		//	base.Activate();
		//	_index = 0;
		//}
	}
}