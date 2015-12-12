using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour
{
	public Transform block;
    public Vector2 startTower;
	public Vector2 drop;
	public PlayerManager playerManager;
	public DropManager dropManager;

	public static int difference = 1;
	int[, ] matrix;

	// Use this for initialization
	void Start () {
		matrix = new int[, ]
        {
			{ 1, 2, 3, 4 },
			{ 2, 4, 4, 5 },
            { 3, 4, 5, 8 },
        };
        
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

		Vector3 startPosition = Vector3.zero;
		Vector3 dropPosition = Vector3.zero;

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                GameObject tower = new GameObject();
                tower.transform.position = new Vector3(col - columns / 2.0f, 0, -1 * (row - rows / 2.0f));
                tower.name = string.Format("Tower ({0}, {1})", col, row);
                tower.transform.parent = transform;

                for (int i = 0; i < matrix[row, col]; i++)
                {
                    var blockInst = CreateBlock(string.Format("Block {0}", i + 1), tower.transform);

                    if (row == startTower.x && col == startTower.y)
                    {
                        startPosition = blockInst.position;
					} 
					if (row == drop.x && col == drop.y)
					{
						dropPosition = blockInst.position;
					}
                }
            }
		}

        playerManager.transform.position = startPosition;
        playerManager.Location = startTower;

		dropManager.transform.position = dropPosition;
	}

    Transform CreateBlock(string name, Transform parentTower)
    {
        Transform blockInst = (Transform)Instantiate(block);
        blockInst.name = name;
        blockInst.parent = parentTower.transform;
        blockInst.localPosition = new Vector3(0, parentTower.childCount - 1, 0);

        return blockInst;
    }

    void RemoveBlock(Transform parentTower)
    {
        Destroy(parentTower.GetChild(parentTower.childCount - 1).gameObject);
    }

	public bool CanReach (Direction dir)
    {
        int locationX = (int)playerManager.Location.x;
        int locationY = (int)playerManager.Location.y;

        switch (dir) {
            case Direction.North:
                if (locationY - 1 == -1) return false;
				return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY - 1, locationX]) <= difference;
            case Direction.South:
                if (locationY + 1 == matrix.GetLength(0)) return false;
				return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY + 1, locationX]) <= difference;
            case Direction.West:
                if (locationX - 1 == -1) return false;
				return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX - 1]) <= difference;
            case Direction.East:
                if (locationX + 1 == matrix.GetLength(1)) return false;
				return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX + 1]) <= difference;
            default:
                return false;
        }
    }

    public int GetHeight(Vector2 location)
    {
        return GetHeight((int)location.x, (int)location.y);
    }

    public int GetHeight (int x, int y)
    {
        return matrix[y, x];
    }

    public void SetHeight(Vector2 location, int value)
    {
        SetHeight((int)location.x, (int)location.y, value);
    }

    public void SetHeight (int x, int y, int value)
    {
        matrix[y, x] = value;
        Transform tower = transform.FindChild(string.Format("Tower ({0}, {1})", x, y));
        if (value > tower.childCount)
        {
            for (int i = 0; i < value - tower.childCount; i++)
            {
                CreateBlock(string.Format("Block {0}", i + tower.childCount), tower);
            }
        } else if (value < tower.childCount)
        {
            for (int i = 0; i < tower.childCount - value; i++)
            {
                RemoveBlock(tower);
            }
        }
    }

    public void IncreaseHeight(Vector2 location)
    {
        IncreaseHeight((int)location.x, (int)location.y);
    }

    public void IncreaseHeight(int x, int y)
    {
        SetHeight(x, y, GetHeight(x, y) + 1);
    }

    public bool DecreaseHeight(Vector2 location)
    {
        return DecreaseHeight((int)location.x, (int)location.y);
    }

    public bool DecreaseHeight(int x, int y)
    {
        if (GetHeight(x, y) == 0) return false;

        SetHeight(x, y, GetHeight(x, y) - 1);
        return true;
    }
}