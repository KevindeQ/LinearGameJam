using UnityEngine;
using Menu.Managers;

public class PlayerManager : MonoBehaviour
{
    public Vector2 startPosition;

    MatrixManager matrixManager;
    Vector2 puzzleLocation;
    Vector3 puzzlePosition;

    public MatrixManager puzzleMatrixManager;
    public MatrixManager preMultiplyMatrixManager;
    public MatrixManager postMultiplyMatrixManager;
    public CameraTargetController ctc;

    private int lastSelected;

    void Start()
    {
        lastSelected = ctc.selected;
    }

    // Update is called once per frame
    void Update()
    {
        #region Teleport
        if (lastSelected != ctc.selected)
        {
            lastSelected = ctc.selected;

            if (ctc.selected != 1)
            {
                puzzleLocation = Location;
                puzzlePosition = transform.localPosition;

                puzzleMatrixManager.PushMatrix();
            }

            int diff = 0;
            switch (ctc.selected)
            {
                case 0:
                    matrixManager = preMultiplyMatrixManager;
                    transform.parent = matrixManager.transform.root;
                    Location = Vector2.zero;
                    transform.localPosition = new Vector3(0 - matrixManager.GetMatrix().GetColumnCount() / 2.0f, 0, -1 * (0 - matrixManager.GetMatrix().GetRowCount() / 2.0f));
                    diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                    transform.Translate(0, diff - 1, 0);
                    break;
                case 1:
                    matrixManager = puzzleMatrixManager;
                    transform.parent = matrixManager.transform.root;
                    Location = puzzleLocation;
                    transform.localPosition = puzzlePosition;
                    diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                    transform.Translate(0, diff - 1, 0);
                    break;
                case 2:
                    matrixManager = postMultiplyMatrixManager;
                    transform.parent = matrixManager.transform.root;
                    Location = Vector2.zero;
                    transform.localPosition = new Vector3(0 - matrixManager.GetMatrix().GetColumnCount() / 2.0f, 0, -1 * (0 - matrixManager.GetMatrix().GetRowCount() / 2.0f));
                    diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                    transform.Translate(0, diff - 1, 0);
                    break;
            }
        }
        #endregion
        #region Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (matrixManager.IsInBound(Location, Direction.North) && (matrixManager.CanReach(Location, Direction.North) || ctc.selected != 1))
            {
                Location = new Vector2(Location.x, Location.y - 1);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(0, diff - 1, 1);
            }

			//Only for the end position, defined at x = 0 and y = 0,
			else if(ctc.selected == 1) {
				if (Location.y == 0 && Location.x == 0) {
					var diff = Mathf.Abs(matrixManager.EndHeight - matrixManager.GetHeight(Location));
					if (diff <= MatrixManager.difference)
						transform.Translate(0, diff , 1);
				}
			}
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (matrixManager.IsInBound(Location, Direction.South) && (matrixManager.CanReach(Location, Direction.South) || ctc.selected != 1))
            {
                Location = new Vector2(Location.x, Location.y + 1);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(0, diff - 1, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (matrixManager.IsInBound(Location, Direction.West) && (matrixManager.CanReach(Location, Direction.West) || ctc.selected != 1))
            {
                Location = new Vector2(Location.x - 1, Location.y);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(-1, diff - 1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (matrixManager.IsInBound(Location, Direction.East) && (matrixManager.CanReach(Location, Direction.East) || ctc.selected != 1))
            {
                Location = new Vector2(Location.x + 1, Location.y);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(1, diff - 1, 0);
            }
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Q) && ctc.selected != 1)
        {
            matrixManager.IncreaseHeight(Location);
            transform.Translate(0, 1, 0);

            FakeApplyMatrix();
        }

        if (Input.GetKeyDown(KeyCode.Z) && ctc.selected != 1)
        {
            if (matrixManager.DecreaseHeight(Location))
                transform.Translate(0, -1, 0);

            FakeApplyMatrix();
        }

        if (ctc.selected != 1 && Input.GetKeyDown(KeyCode.Return))
        {
            int rows = preMultiplyMatrixManager.GetMatrix().GetRowCount();
            int cols = preMultiplyMatrixManager.GetMatrix().GetColumnCount();

            preMultiplyMatrixManager.ModifyMatrix(Matrix.DefaultMatrix(cols, rows));
            postMultiplyMatrixManager.ModifyMatrix(Matrix.DefaultMatrix(cols, rows));

            matrixManager = puzzleMatrixManager;
            transform.parent = matrixManager.transform.root;
            Location = puzzleLocation;
            transform.localPosition = puzzlePosition;
            var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
            transform.Translate(0, diff - 1, 0);

            ctc.selected = 1;
        }

        if (ctc.selected != 1 && Input.GetKeyDown(KeyCode.Escape))
        {
            int rows = preMultiplyMatrixManager.GetMatrix().GetRowCount();
            int cols = preMultiplyMatrixManager.GetMatrix().GetColumnCount();

            preMultiplyMatrixManager.ModifyMatrix(Matrix.DefaultMatrix(cols, rows));
            postMultiplyMatrixManager.ModifyMatrix(Matrix.DefaultMatrix(cols, rows));
            puzzleMatrixManager.ModifyMatrix(puzzleMatrixManager.PopMatrix());

            matrixManager = puzzleMatrixManager;
            transform.parent = matrixManager.transform.root;
            Location = puzzleLocation;
            transform.localPosition = puzzlePosition;

            ctc.selected = 1;
        }
    }

    public void FakeApplyMatrix()
    {
        Matrix NewMatrix = Matrix.Multiply(
                preMultiplyMatrixManager.GetMatrix(), puzzleMatrixManager.PopMatrix());
        NewMatrix = Matrix.Multiply(NewMatrix, postMultiplyMatrixManager.GetMatrix());

        puzzleMatrixManager.ModifyMatrix(NewMatrix);
    }

    public void Init()
    {
        matrixManager = puzzleMatrixManager;
        Location = MenuManager.puzzleMatrix.StartLocation;
        transform.parent = matrixManager.transform.root;
        transform.localPosition = matrixManager.GetStartPosition();
    }

    public Vector2 Location { get; set; }
}
