using UnityEngine;
using Menu.Managers.SubMenus;
using Menu.Managers.Items;

namespace Menu.Managers {
	public class MappingMenuManager : MenuManager {
		//int _subIndex;

		//public RectTransform subMenus;

		//void OnEnable () {
		//	subMenus.GetChild(subMenus.childCount - 1 - _subIndex).GetComponent<MappingSubMenuManager>().Enter();

		//	for (int i = 0; i < subMenus.childCount; i++) {
		//		subMenus.GetChild(i).GetComponent<MappingSubMenuManager>().Enable();
		//	}
		//}

		//void Start () {
		//	_subIndex = 0;

		//	for (int i = 0; i < subMenus.childCount; i++) {
		//		subMenus.GetChild(i).GetComponent<MappingSubMenuManager>().Parent = this;
		//	}
		//}

		//// Update is called once per frame
		//void Update () {
		//	Base.Animator.SetInteger("SubMapping", _subIndex);
		//}

		//void OnDisable () {
		//	for (int i = 0; i < subMenus.childCount; i++) {
		//		subMenus.GetChild(i).GetComponent<MappingSubMenuManager>().Disable();
		//	}
		//}

		//public void Exit () {
		//	Base.SettingsMenu.Enable();
		//	Base.Animator.SetBool("ToMapping", false);

		//	Disable();
		//}

		//public void NavigateLeft () {
		//	_subIndex = Mathf.Min(_subIndex + 1, subMenus.childCount - 1);
		//	subMenus.GetChild(subMenus.childCount - 1 - _subIndex).GetComponent<MappingSubMenuManager>().Enter();
		//}

		//public void NavigateRight () {
		//	_subIndex = Mathf.Max(_subIndex - 1, 0);
		//	subMenus.GetChild(subMenus.childCount - 1 - _subIndex).GetComponent<MappingSubMenuManager>().Enter();
		//}

		//      /// <summary>
		//      /// Navigate to the given sub menu
		//      /// </summary>
		//      /// <param name="subMenu">The sub menu to navigate to</param>
		//      public void NavigateTo(MappingSubMenuManager subMenu) {
		//          int siblingIndex = subMenu.transform.GetSiblingIndex();
		//          _subIndex = subMenus.childCount - 1 - siblingIndex;
		//          subMenus.GetChild(siblingIndex).GetComponent<MappingSubMenuManager>().Enter();
		//      }

		//      #region Properties

		//      public Profile Profile {
		//	get; set;
		//}

		//#endregion
	}
}