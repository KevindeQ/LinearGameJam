using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour
{
	public Transform block;

	private Matrix matrix;

    private bool modified;
    public bool IsModified
    {
        get { return modified; }
        private set { modified = value; }
    }

    void Start()
    {
		matrix = new Matrix(new int[, ]
        {
			{ 2, 2, 4, 3 },
			{ 2, 2, 3, 1 },
            { 1, 1, 5, 3 },
            { 1, 1, 5, 3 },
        });

        GenerateMatrixVisualization();
        modified = false;
    }

	void Update()
    {
        if (!modified)
            return;

        for (int i = 0; i < transform.childCount; i++)
            Destroy(transform.GetChild(i).gameObject);

        GenerateMatrixVisualization();
        modified = false;
    }

    void GenerateMatrixVisualization()
    {
        int rows = matrix.GetRowCount();
        int columns = matrix.GetColumnCount();

        for (int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                GameObject tower = new GameObject();
                tower.transform.parent = transform;
                tower.transform.localPosition = new Vector3(x - columns / 2.0f, 0, -1 * (z - rows / 2.0f));
                tower.name = string.Format("Tower ({0}, {1})", x, z);

                for (int i = 0; i < matrix[z, x]; i++)
                {
                    Transform blockInst = (Transform)Instantiate(block);
                    blockInst.name = string.Format("Block {0}", i + 1);
                    blockInst.parent = tower.transform;
                    blockInst.localPosition = new Vector3(0, i, 0);
                }
            }
        }
    }

    public void ModifyMatrix(Matrix NewMatrix)
    {
        matrix = NewMatrix;
        modified = true;
    }

    public Matrix GetMatrix() { return matrix; }
}