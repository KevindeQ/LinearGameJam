using Menu.Managers;
using UnityEngine;

namespace Menu {
	/// <summary>
	/// Menu base containing all the managers of the different menu screens
	/// </summary>
	public class MenuBase : Base {
		[SerializeField]
		MainMenuManager _mainMenu;
		[SerializeField]
		LevelsMenuManager _levelsMenu;
		[SerializeField]
		InputManager _inputManager;

		public MenuManager initMenu;

		/// <summary>
		/// Make this instance the base of all the managers before anything else
		/// </summary>
		void Start () {
			//MainMenu.Base = this;
			//SelectionMenu.Base = this;
			//SettingsMenu.Base = this;
			//MappingMenu.Base = this;
			//LoadingScreen.Base = this;
			initMenu.Enable();
		}

		#region Properties

		/// <summary>
		/// Animator controller of the menu
		/// </summary>
		public Animator Animator {
			get {
				return GetComponent<Animator>();
			}
		}

		/// <summary>
		/// Main menu manager
		/// </summary>
		public MainMenuManager MainMenu {
			get {
				return _mainMenu;
			}
		}

        public MainMenuManager LevelsMenu
        {
            get
            {
                return _levelsMenu;
            }
        }

        /// <summary>
        /// Input manager
        /// </summary>
        public InputManager InputManager {
			get {
				return _inputManager;
			}
		}

		#endregion
	}
}