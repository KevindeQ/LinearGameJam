using Menu.Managers.SubMenus;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class NewProfileManager : MenuItemManager {
		//public RectTransform valueRect;

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Base.InputManager.ConfirmDown || Input.GetKeyDown(KeyCode.Return)) {
		//				string profileName = valueRect.GetComponent<InputField>().text.ToUpper();
		//				if (profileName.Length == 0) {
		//					Reselect();
		//					Debug.Log("Valid input is between 1 - 4 alphanumeric characters!");
		//				} else if (SaveLoad.savedProfiles.Exists(x => x.Name == profileName)) {
		//					Reselect();
		//					Debug.Log("Profile " + profileName + " already exists!");
		//				} else {
		//					SaveLoad.savedProfiles.Add(new Profile(profileName));
		//					SaveLoad.Save();
		//					Deactivate();
		//					((SubMenuManager)Parent).Enter();
		//				}
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}
		//		}
		//	}

		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//void Reselect () {
		//	EventSystem.current.SetSelectedGameObject(null);
		//	EventSystem.current.SetSelectedGameObject(valueRect.gameObject);
		//}

		//public override void Activate () {
		//	base.Activate();
		//	valueRect.GetComponent<InputField>().enabled = true;
		//	valueRect.GetComponent<InputField>().text = "";
		//	EventSystem.current.SetSelectedGameObject(valueRect.gameObject);
		//}

		//public override void Deactivate () {
		//	base.Deactivate();
		//	valueRect.GetComponent<InputField>().enabled = false;
		//	valueRect.GetComponent<InputField>().text = "< New Profile >";
		//	EventSystem.current.SetSelectedGameObject(null);
		//}
	}
}