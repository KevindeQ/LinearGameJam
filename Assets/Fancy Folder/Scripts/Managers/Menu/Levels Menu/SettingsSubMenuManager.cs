using Menu.Managers.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.SubMenus {
	public class SettingsSubMenuManager : SubMenuManager {
		//int _subIndex;
		//MenuItemManager _activatedItem;
		//float _downTimer;
		//float _upTimer;

		//public RectTransform items;

		//void OnEnable () {
		//	for (int i = 0; i < items.childCount; i++) {
		//		items.GetChild(i).GetComponent<MenuItemManager>().Enable();
		//	}
		//}

		//void Start () {
		//	_subIndex = 0;
		//	for (int i = 0; i < items.childCount; i++) {
		//		items.GetChild(i).GetComponent<MenuItemManager>().Parent = this;
		//	}
		//}

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_entered) {
		//			if (Base.InputManager.LeftDown) {
		//				Leave();
		//				((SettingsMenuManager)Parent).NavigateLeft();
		//			}

		//			if (Base.InputManager.RightDown) {
		//				Leave();
		//				((SettingsMenuManager)Parent).NavigateRight();
		//			}

		//			if (Base.InputManager.Down && _downTimer <= 0.0f) {
		//				items.GetChild(_subIndex).GetComponent<Image>().enabled = false;
		//				_subIndex = Mathf.Min(_subIndex + 1, items.childCount - 1);
		//				_downTimer = _INTERVAL;
		//			} else {
		//				_downTimer -= Time.deltaTime;
		//			}

		//			if (Base.InputManager.Up && _upTimer <= 0.0f) {
		//				items.GetChild(_subIndex).GetComponent<Image>().enabled = false;
		//				_subIndex = Mathf.Max(_subIndex - 1, 0);
		//				_upTimer = _INTERVAL;
		//			} else {
		//				_upTimer -= Time.deltaTime;
		//			}

		//			items.GetChild(_subIndex).GetComponent<Image>().enabled = true;

		//			if (Base.InputManager.ConfirmDown) {
		//				MenuItemManager item = items.GetChild(_subIndex).GetComponent<MenuItemManager>();
		//				ActivateItem(item);
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Leave();
		//				((SettingsMenuManager)Parent).Exit();
		//			}
		//		}
		//	}

		//	_firstFrame = false;
		//}

		//void OnDisable () {
		//	for (int i = 0; i < items.childCount; i++) {
		//		items.GetChild(i).GetComponent<MenuItemManager>().Disable();
		//	}
		//}

		//public override void Enter () {
		//	base.Enter();
		//	if (_activatedItem != null) {
		//		DeactivateItem(_activatedItem);
		//		_activatedItem = null;
		//	}
		//}

		///// <summary>
		///// Activate the selected item and leave this sub menu
		///// </summary>
		///// <param name="item">Item to be activated</param>
		//public void ActivateItem (MenuItemManager item) {
		//	if (item.GetType() != typeof(ProfilesManager) ||
		//		((item.GetType() == typeof(ProfilesManager) && SaveLoad.savedProfiles.Count != 0))) {
		//		if (_activatedItem != null && _activatedItem != item) {
		//			DeactivateItem(_activatedItem);
		//		}

		//		item.Activate();
		//		_activatedItem = item;
		//		Leave();
		//	}
		//}

		//public void HoverItem (MenuItemManager item) {
		//	items.GetChild(_subIndex).GetComponent<Image>().enabled = false;
		//	_subIndex = item.transform.GetSiblingIndex();
		//	items.GetChild(_subIndex).GetComponent<Image>().enabled = true;
		//}

		//void DeactivateItem (MenuItemManager item) {
		//	item.Deactivate();
		//	items.GetChild(item.transform.GetSiblingIndex()).GetComponent<Image>().enabled = false;
		//}
	}
}