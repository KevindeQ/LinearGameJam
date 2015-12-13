using UnityEngine;
using Menu.Managers;

public class PlayerManager : MonoBehaviour
{
    MatrixManager matrixManager;
    Vector2 puzzleLocation;
    Vector3 puzzlePosition;

    public MatrixManager puzzleMatrixManager;
    public MatrixManager preMultiplyMatrixManager;
    public MatrixManager postMultiplyMatrixManager;
    public CameraTargetController ctc;

    private int lastSelected;

    Vector3 targetPosition;
    bool canMove;
    Transform minion;
    float speed;

    void Start()
    {
        lastSelected = ctc.selected;
        canMove = true;
        minion = transform.GetChild(0);
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
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (matrixManager.IsInBound(Location, Direction.North)) {
                    if (ctc.selected != 1)
                    {
                        Location = new Vector2(Location.x, Location.y - 1);
                        minion.eulerAngles = Vector3.up * 0;
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        transform.Translate(0, diff - 1, 1);
                    } else if (matrixManager.CanReach(Location, Direction.North))
                    {
                        Location = new Vector2(Location.x, Location.y - 1);
                        minion.eulerAngles = Vector3.up * 0;
                        transform.Translate(0, 0, 1);
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        targetPosition = new Vector3(transform.position.x, transform.position.y + (diff - 1), transform.position.z);
                        canMove = false;
                        minion.GetComponent<Animator>().SetBool("Jump", true);
                        speed = Mathf.Abs(Vector3.Distance(transform.position, targetPosition));
                    }
                }

                //Only for the end position, defined at x = 0 and y = 0,
                else if (ctc.selected == 1)
                {
                    if (Location.y == 0 && Location.x == 0)
                    {
                        var diff = Mathf.Abs(matrixManager.EndHeight - matrixManager.GetHeight(Location));
                        if (diff <= MatrixManager.difference)
                        {
                            minion.eulerAngles = Vector3.up * 0;
                            transform.Translate(0, 0, 1);
                            targetPosition = new Vector3(transform.position.x, transform.position.y + diff, transform.position.z);
                            canMove = false;
                            minion.GetComponent<Animator>().SetBool("Jump", true);
                            speed = Mathf.Abs(Vector3.Distance(transform.position, targetPosition));
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (matrixManager.IsInBound(Location, Direction.South))
                {
                    if (ctc.selected != 1)
                    {
                        Location = new Vector2(Location.x, Location.y + 1);
                        minion.eulerAngles = Vector3.up * 180;
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        transform.Translate(0, diff - 1, -1);
                    }
                    else if (matrixManager.CanReach(Location, Direction.South))
                    {
                        Location = new Vector2(Location.x, Location.y + 1);
                        minion.eulerAngles = Vector3.up * 180;
                        transform.Translate(0, 0, -1);
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        targetPosition = new Vector3(transform.position.x, transform.position.y + (diff - 1), transform.position.z);
                        canMove = false;
                        minion.GetComponent<Animator>().SetBool("Jump", true);
                        speed = Mathf.Abs(Vector3.Distance(transform.position, targetPosition));
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (matrixManager.IsInBound(Location, Direction.West))
                {
                    if (ctc.selected != 1)
                    {
                        Location = new Vector2(Location.x - 1, Location.y);
                        minion.eulerAngles = Vector3.up * 270;
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        transform.Translate(-1, diff - 1, 0);
                    }
                    else if (matrixManager.CanReach(Location, Direction.West))
                    {
                        Location = new Vector2(Location.x - 1, Location.y);
                        minion.eulerAngles = Vector3.up * 270;
                        transform.Translate(-1, 0, 0);
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        targetPosition = new Vector3(transform.position.x, transform.position.y + (diff - 1), transform.position.z);
                        canMove = false;
                        minion.GetComponent<Animator>().SetBool("Jump", true);
                        speed = Mathf.Abs(Vector3.Distance(transform.position, targetPosition));
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (matrixManager.IsInBound(Location, Direction.East))
                {
                    if (ctc.selected != 1)
                    {
                        Location = new Vector2(Location.x + 1, Location.y);
                        minion.eulerAngles = Vector3.up * 90;
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        transform.Translate(1, diff - 1, 0);
                    }
                    else if (matrixManager.CanReach(Location, Direction.East))
                    {
                        Location = new Vector2(Location.x + 1, Location.y);
                        minion.eulerAngles = Vector3.up * 90;
                        transform.Translate(1, 0, 0);
                        var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                        targetPosition = new Vector3(transform.position.x, transform.position.y + (diff - 1), transform.position.z);
                        canMove = false;
                        minion.GetComponent<Animator>().SetBool("Jump", true);
                        speed = Mathf.Abs(Vector3.Distance(transform.position, targetPosition));
                    }
                }
            }
        } else
        {
            minion.GetComponent<Animator>().SetBool("Jump", false);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (minion.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
            {
                canMove = true;
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
