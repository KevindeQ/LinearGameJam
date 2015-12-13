using Menu.Managers;
using Menu.Managers.Items;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ChangeLevel (string levelName)
    {
        switch (levelName)
        {
            case "L1":
                MenuManager.puzzleMatrix = LevelsMenuManager.level1matrix;
                break;
            case "L2":
                MenuManager.puzzleMatrix = LevelsMenuManager.level2matrix;
                break;
            case "L3":
                MenuManager.puzzleMatrix = LevelsMenuManager.level3matrix;
                break;
        }

        SceneManager.LoadScene(levelName);
    }
}