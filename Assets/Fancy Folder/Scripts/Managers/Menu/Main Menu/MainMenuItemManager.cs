using Menu.Managers;
using Menu.Managers.Items;
using UnityEngine;

public class MainMenuItemManager : MenuItemManager {
	[SerializeField]
	MenuManager _nextMenu;

	// Update is called once per frame
	void Update () {
		if (Base.InputManager.ConfirmDown) {
			ChangeMenu();
		}
	}

	public override void Enable () {
		base.Enable();
		Animator.SetTrigger(HighLightedTrigger);
	}

	public override void Disable () {
		base.Disable();
		Animator.SetTrigger(NormalTrigger);
	}

	public void ChangeMenu () {
		if (_nextMenu != null) {
			_nextMenu.Enable();
			Parent.Disable();
		}
	}
}