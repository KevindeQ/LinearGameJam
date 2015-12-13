namespace Menu.Managers {
	public class InputManager : MenuManager {

		protected override void Awake () {}

		void Update () {
			//Confirm = XCI.GetButton(XboxButton.A) || Input.GetButton("Confirm");
			//ConfirmDown = XCI.GetButtonDown(XboxButton.A) || Input.GetButtonDown("Confirm");
			//ConfirmUp = XCI.GetButtonUp(XboxButton.A) || Input.GetButtonUp("Confirm");

			//Delete = XCI.GetButton(XboxButton.B) || Input.GetButton("Delete");
			//DeleteDown = XCI.GetButtonDown(XboxButton.B) || Input.GetButtonDown("Delete");
			//DeleteUp = XCI.GetButtonUp(XboxButton.B) || Input.GetButtonUp("Delete");

			//Cancel = XCI.GetButton(XboxButton.B) || Input.GetButton("Cancel");
			//CancelDown = XCI.GetButtonDown(XboxButton.B) || Input.GetButtonDown("Cancel");
			//CancelUp = XCI.GetButtonUp(XboxButton.B) || Input.GetButtonUp("Cancel");

			//Start =  XCI.GetButton(XboxButton.Start) || Input.GetButton("Start");
			//StartDown = XCI.GetButtonDown(XboxButton.Start) || Input.GetButtonDown("Start");
			//StartUp = XCI.GetButtonUp(XboxButton.Start) || Input.GetButtonUp("Start");

			//Left = XCI.GetDPad(XboxDPad.Left) || Input.GetButton("Left");
			//LeftDown = XCI.GetDPadDown(XboxDPad.Left) || Input.GetButtonDown("Left");
			//LeftUp = XCI.GetDPadUp(XboxDPad.Left) || Input.GetButtonUp("Left");

			//Down = XCI.GetDPad(XboxDPad.Down) || Input.GetButton("Down");
			//DownDown = XCI.GetDPadDown(XboxDPad.Down) || Input.GetButtonDown("Down");
			//DownUp = XCI.GetDPadUp(XboxDPad.Down) || Input.GetButtonUp("Down");

			//Up = XCI.GetDPad(XboxDPad.Up) || Input.GetButton("Up");
			//UpDown = XCI.GetDPadDown(XboxDPad.Up) || Input.GetButtonDown("Up");
			//UpUp = XCI.GetDPadUp(XboxDPad.Up) || Input.GetButtonUp("Up");

			//Right = XCI.GetDPad(XboxDPad.Right) || Input.GetButton("Right");
			//RightDown = XCI.GetDPadDown(XboxDPad.Right) || Input.GetButtonDown("Right");
			//RightUp = XCI.GetDPadUp(XboxDPad.Right) || Input.GetButtonUp("Right");
		}

		#region Properties

		public bool Confirm {
			get; private set;
		}

		public bool ConfirmDown {
			get; private set;
		}

		public bool ConfirmUp {
			get; private set;
		}

		public bool Delete {
			get; private set;
		}

		public bool DeleteDown {
			get; private set;
		}

		public bool DeleteUp {
			get; private set;
		}

		public bool Cancel {
			get; private set;
		}

		public bool CancelDown {
			get; private set;
		}

		public bool CancelUp {
			get; private set;
		}

		public bool Start {
			get; private set;
		}

		public bool StartDown {
			get; private set;
		}

		public bool StartUp {
			get; private set;
		}

		public bool Left {
			get; private set;
		}

		public bool LeftDown {
			get; private set;
		}

		public bool LeftUp {
			get; private set;
		}

		public bool Down {
			get; private set;
		}

		public bool DownDown {
			get; private set;
		}

		public bool DownUp {
			get; private set;
		}

		public bool Up {
			get; private set;
		}

		public bool UpDown {
			get; private set;
		}

		public bool UpUp {
			get; private set;
		}

		public bool Right {
			get; private set;
		}

		public bool RightDown {
			get; private set;
		}

		public bool RightUp {
			get; private set;
		}

		#endregion
	}
}