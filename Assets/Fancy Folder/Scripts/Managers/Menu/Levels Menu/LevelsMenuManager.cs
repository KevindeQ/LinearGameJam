using UnityEngine;
using Menu.Managers.SubMenus;
using Menu.Managers.Items;

namespace Menu.Managers {
	public class LevelsMenuManager : MainMenuManager {
        
        void OnDisable()
        {
            Animator.SetTrigger(ExitRight);
        }
    }
}