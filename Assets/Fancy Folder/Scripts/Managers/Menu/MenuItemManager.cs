using UnityEngine;

namespace Menu.Managers.Items {
	public abstract class MenuItemManager : Manager<MenuBase> {
		//protected bool _firstFrame;
		//protected bool _activated;

		int _normalTrigger;
		int _highlightedTrigger;
		int _pressedTrigger;
		int _disabledTrigger;

		protected virtual void Awake () {
			_normalTrigger = Animator.StringToHash("Normal");;
			_highlightedTrigger = Animator.StringToHash("Highlighted");;
			_pressedTrigger = Animator.StringToHash("Pressed");;
			_disabledTrigger = Animator.StringToHash("Disabled");;
			//Deactivate();
		}

		//public virtual void Activate () {
		//	_activated = true;
		//	_firstFrame = true;
		//}

		//public virtual void Deactivate () {
		//	_activated = false;
		//}

		//public virtual bool IsActivated() {
		//    return _activated;
		//}

		#region Properties

		public MenuManager Parent {
			get
            {
                return GetComponentInParent<MenuManager>();
            }
		}

		public Animator Animator {
			get {
				return GetComponent<Animator>();
			}
		}

		public int NormalTrigger {
			get {
				return _normalTrigger;
			}
		}

		public int HighLightedTrigger {
			get {
				return _highlightedTrigger;
			}
		}

		public int PressedTrigger {
			get {
				return _pressedTrigger;
			}
		}

		public int DisabledTrigger {
			get {
				return _disabledTrigger;
			}
		}

		#endregion
	}
}