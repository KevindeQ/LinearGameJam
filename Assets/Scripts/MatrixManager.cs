using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour
{
	public Transform block;
    public Vector2 startTower;

    public PlayerManager playerManager;

	int[, ] matrix;

	// Use this for initialization
	void Start () {
		matrix = new int[, ]
        {
			{ 1, 2, 3, 4 },
			{ 2, 3, 4, 5 },
            { 3, 4, 5, 7 },
        };
        
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        Vector3 startPosition = Vector3.zero;

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
                    Transform blockInst = (Transform)Instantiate(block);
                    blockInst.name = string.Format("Block {0}", i + 1);
                    blockInst.parent = tower.transform;
                    blockInst.localPosition = new Vector3(0, i, 0);

                    if (row == startTower.x && col == startTower.y)
                    {
                        startPosition = blockInst.position;
                    }
                }
            }
		}

        playerManager.transform.position = startPosition;
        playerManager.Location = startTower;
	}

	public bool CanReach (Direction dir)
    {
        int locationX = (int)playerManager.Location.x;
        int locationY = (int)playerManager.Location.y;

        switch (dir) {
            case Direction.North:
                if (locationY - 1 == -1) return false;
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY - 1, locationX]) <= 1;
            case Direction.South:
                if (locationY + 1 == matrix.GetLength(0)) return false;
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY + 1, locationX]) <= 1;
            case Direction.West:
                if (locationX - 1 == -1) return false;
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX - 1]) <= 1;
            case Direction.East:
                if (locationX + 1 == matrix.GetLength(1)) return false;
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX + 1]) <= 1;
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
}