namespace Menu.Managers.SubMenus {
	public abstract class SubMenuManager : MenuManager {
		protected const float _INTERVAL = 0.15f;

		protected bool _firstFrame;
		protected bool _entered;

		protected override void Awake () {
			base.Awake();
			Leave();
		}

		public virtual void Enter () {
			_entered = true;
			_firstFrame = true;
		}

		public virtual void Leave () {
			_entered = false;
		}
	}
}