using UnityEngine;
using UnityEngine.UI;

namespace Menu.Managers {
	public class MainMenuManager : MenuManager {
		int _subMenuIndex;

		public RectTransform menuBar;

		void OnEnable () {
			Animator.SetTrigger(EnterTrigger);
		}

		// Use this for initialization
		void Start () {
			var spacing = menuBar.GetComponent<VerticalLayoutGroup>().spacing;
			var height = (150 + spacing) * menuBar.childCount - spacing;
			var width = menuBar.sizeDelta.x;
			menuBar.sizeDelta = new Vector2(width, height);

			_subMenuIndex = 0;
			menuBar.GetChild(_subMenuIndex).GetComponent<MainMenuItemManager>().Enable();
		}

		// Update is called once per frame
		void Update () {
			int nextIndex = _subMenuIndex;
			if (Base.InputManager.DownDown) {
				nextIndex++;
			}

			if (Base.InputManager.UpDown) {
				nextIndex--;
			}

			nextIndex = Mathf.Clamp(nextIndex, 0, menuBar.childCount - 1);
			ChangeItem(_subMenuIndex, nextIndex);
		}

		void OnDisable () {
			Animator.SetTrigger(ExitLeft);
		}

		public void OnEnterItem (MainMenuItemManager item) {
			int siblingIndex = item.transform.GetSiblingIndex();
			ChangeItem(_subMenuIndex, siblingIndex);
		}

		void ChangeItem (int prevIndex, int nextIndex) {
			if (nextIndex != prevIndex) {
				menuBar.GetChild(prevIndex).GetComponent<MainMenuItemManager>().Disable();
				menuBar.GetChild(nextIndex).GetComponent<MainMenuItemManager>().Enable();
				_subMenuIndex = nextIndex;
			}
		}
	}
}