using Menu.Managers.SubMenus;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers.Items {
	public class MasterVolumeManager : MenuItemManager {
		//const float _INTERVAL = 0.1f;

		//float _volume;
		//float _leftTimer;
		//float _rightTimer;

		//public RectTransform sliderRect;
		//public RectTransform valueRect;

		//// Update is called once per frame
		//void Update () {
		//	if (!_firstFrame) {
		//		if (_activated) {
		//			if (Base.InputManager.Left && _leftTimer <= 0.0f) {
		//				_volume -= 5f;
		//				_volume = Mathf.Max(0, _volume);
		//				_leftTimer = _INTERVAL;
		//			} else {
		//				_leftTimer -= Time.deltaTime;
		//			}

		//			if (Base.InputManager.Right && _rightTimer <= 0.0f) {
		//				_volume += 5f;
		//				_volume = Mathf.Min(_volume, 100);
		//				_rightTimer = _INTERVAL;
		//			} else {
		//				_rightTimer -= Time.deltaTime;
		//			}

		//			valueRect.GetComponent<Text>().text = _volume.ToString();
		//			sliderRect.GetComponent<Slider>().value = _volume;

		//			if (Base.InputManager.ConfirmDown) {
		//				Settings.MasterVolume = _volume;
		//				Settings.Save();
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}

		//			if (Base.InputManager.CancelDown) {
		//				Deactivate();
		//				((SubMenuManager)Parent).Enter();
		//			}
		//		} else {
		//			valueRect.GetComponent<Text>().text = Settings.MasterVolume.ToString();
		//			sliderRect.GetComponent<Slider>().value = Settings.MasterVolume;
		//		}
		//	}
		//	GetComponent<CanvasGroup>().ignoreParentGroups = _activated;
		//	_firstFrame = false;
		//}

		//public override void Activate () {
		//	base.Activate();
		//	_volume = Settings.MasterVolume;
		//	_leftTimer = 0.0f;
		//	_rightTimer = 0.0f;
		//}

		//public void SliderSetting () {
		//	_volume = sliderRect.GetComponent<Slider>().value;
		//}
	}
}