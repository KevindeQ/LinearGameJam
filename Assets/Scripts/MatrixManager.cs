﻿using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour
{
	public Transform block;
    public Transform startBlock;

	Matrix matrix;
    Matrix storedMatrix;
    Vector3 startPosition;

    void Start()
    {
	}

    public void Init ()
    {
        int rows = matrix.GetRowCount();
        int columns = matrix.GetColumnCount();

        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                GameObject tower = new GameObject();
                tower.transform.parent = transform;
                tower.transform.localPosition = new Vector3(col - columns / 2.0f, 0, -1 * (row - rows / 2.0f));
                tower.name = string.Format("Tower ({0}, {1})", col, row);

                for (int i = 0; i < matrix[row, col]; i++)
                {
                    Transform blockInst;
                    if (col == 0 && row == 0)
                        blockInst = CreateBlock(string.Format("Block {0}", i + 1), tower.transform, true);
                    else
                        blockInst = CreateBlock(string.Format("Block {0}", i + 1), tower.transform);
                }
            }
        }
    }

    public void ModifyMatrix(Matrix NewMatrix)
    {
        Debug.Log(transform.parent.name);
        for (int col = 0; col < matrix.GetColumnCount(); col++)
        {
            for (int row = 0; row < matrix.GetRowCount(); row++)
            {
                int oldValue = matrix[row, col];
                int newValue = NewMatrix[row, col];
                int diff = oldValue - newValue;
                for (int i = 0; i < Mathf.Abs(diff); i++)
                {
                    if (diff < 0)
                    {
                        IncreaseHeight(col, row);
                    }
                    else if (diff > 0)
                    {
                        DecreaseHeight(col, row);
                    }
                }
            }
        }
    }

    Transform CreateBlock(string name, Transform parentTower, bool startBlock = false)
    {
        Transform blockInst = startBlock ? (Transform)Instantiate(this.startBlock) : (Transform)Instantiate(block);
        blockInst.name = name;
        blockInst.parent = parentTower.transform;
        blockInst.localPosition = new Vector3(0, parentTower.childCount - 1, 0);

        if (startBlock)
        {
            startPosition = blockInst.position;
            matrix.StartLocation = new Vector2(0, 0);
        }
        return blockInst;
    }

    void RemoveBlock(Transform parentTower)
    {
        DestroyImmediate(parentTower.GetChild(parentTower.childCount - 1).gameObject);
    }

	public bool CanReach (Vector2 location, Direction dir)
    {
        int locationX = (int)location.x;
        int locationY = (int)location.y;

        switch (dir) {
            case Direction.North:
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY - 1, locationX]) <= 1;
            case Direction.South:
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY + 1, locationX]) <= 1;
            case Direction.West:
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX - 1]) <= 1;
            case Direction.East:
                return Mathf.Abs(matrix[locationY, locationX] - matrix[locationY, locationX + 1]) <= 1;
            default:
                return false;
        }
    }

    public bool IsInBound (Vector2 location, Direction dir)
    {
        int locationX = (int)location.x;
        int locationY = (int)location.y;

        switch (dir)
        {
            case Direction.North:
                return !(locationY - 1 == -1);
            case Direction.South:
                return !(locationY + 1 == matrix.GetRowCount());
            case Direction.West:
                return !(locationX - 1 == -1);
            case Direction.East:
                return !(locationX + 1 == matrix.GetColumnCount());
            default:
                return false;
        }
    }

    public Matrix GetMatrix ()
    {
        return matrix;
    }

    public void SetMatrix (Matrix newMatrix)
    {
        matrix = newMatrix;
    }

    public void PushMatrix()
    {
        storedMatrix = matrix.Clone();
    }

    public Matrix PopMatrix()
    {
        return storedMatrix;
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

    public Vector3 GetStartPosition ()
    {
        return startPosition;
    }
}