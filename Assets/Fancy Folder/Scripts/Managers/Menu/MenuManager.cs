using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Menu.Managers {
	public abstract class MenuManager : Manager<MenuBase> {
		#region Editor menu

#if UNITY_EDITOR
		[MenuItem("Assets/Create/Prefab (Menu Manager)", false, 201)]
		static void CreateFighterManager () {
			var go = new GameObject();
			foreach (var selectedObj in Selection.objects) {
				go.name = selectedObj.name;
				go.AddComponent(((MonoScript)selectedObj).GetClass());
				string path = string.Format("Assets/Prefabs/Managers/Menu/{0}.prefab", selectedObj.name);
				PrefabUtility.CreatePrefab(path, go);
				DestroyImmediate(go.GetComponent(((MonoScript)selectedObj).GetClass()));
			}

			DestroyImmediate(go);
		}

		[MenuItem("Assets/Create/Prefab (Menu Manager)", true)]
		static bool ValidateFighterManager () {
			string managersFolder = "Assets/Prefabs/Managers/Menu";
			string[] folders = AssetDatabase.GetSubFolders(managersFolder);
			Array.Resize<string>(ref folders, folders.Length + 1);
			folders[folders.Length - 1] = managersFolder;

			foreach (var selectedObj in Selection.objects) {
				if (selectedObj.GetType() == typeof(MonoScript)) {
					if (!((MonoScript)selectedObj).GetClass().IsSubclassOf(typeof(MenuManager))) {
						return false;
					}

					string[] GUIDs = AssetDatabase.FindAssets(selectedObj.name, folders);
					foreach (string GUID in GUIDs) {
						if (AssetDatabase.GUIDToAssetPath(GUID).Contains("/" + selectedObj.name)) {
							return false;
						}
					}
				} else {
					return false;
				}
			}

			return true;
		}
#endif

        #endregion

        public static Matrix puzzleMatrix;

        int _enterTrigger;
		int _exitLeftTrigger;
		int _exitRightTrigger;

		protected virtual void Awake () {
			_enterTrigger = Animator.StringToHash("Enter");
			_exitLeftTrigger = Animator.StringToHash("Exit Left");
			_exitRightTrigger = Animator.StringToHash("Exit Right");
			Disable();
		}

		#region Properties

		public Animator Animator {
			get {
				return GetComponent<Animator>();
			}
		}

		public int EnterTrigger {
			get {
				return _enterTrigger;
			}
		}

		public int ExitLeft {
			get {
				return _exitLeftTrigger;
			}
		}

		public int ExitRight {
			get {
				return _exitRightTrigger;
			}
		}

		#endregion
	}
}