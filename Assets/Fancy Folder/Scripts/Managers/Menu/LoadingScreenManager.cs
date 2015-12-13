using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Menu.Managers {
	public class LoadingScreenManager : MenuManager {
		public Slider loadSlider;

		public void LoadStage (string stage) {
			StartCoroutine(StageLoading(stage));
		}

		IEnumerator StageLoading (string stage) {
			AsyncOperation async = Application.LoadLevelAsync(stage);
			while (!async.isDone || Base.Animator.IsInTransition(0)) {
				loadSlider.value = async.progress;
				yield return null;
			}

			yield return new WaitForSeconds(10000.0f);

			Base.Animator.SetTrigger("Loaded");
		}
	}
}