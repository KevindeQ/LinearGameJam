using Menu.Managers;
using Menu.Managers.Items;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuItemManager : MenuItemManager {
	[SerializeField]
	MenuManager _nextMenu;

    protected override void Awake ()
    {
        base.Awake();
        GetComponentInChildren<Text>().text = name;
    }

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

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeLevel (string levelName)
    {
        int index = int.Parse(levelName.Substring(1));
        MenuManager.puzzleMatrix = LevelsMenuManager.levelMatrices[index - 1];

        SceneManager.LoadScene(levelName);
    }
}