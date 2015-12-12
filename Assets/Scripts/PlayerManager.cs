using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    public MatrixManager matrixManager;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.W))
        {
            if (matrixManager.CanReach(Direction.North))
            {
                Location = new Vector2(Location.x, Location.y - 1);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(0, diff - 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (matrixManager.CanReach(Direction.South))
            {
                Location = new Vector2(Location.x, Location.y + 1);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(0, diff - 1, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (matrixManager.CanReach(Direction.West))
            {
                Location = new Vector2(Location.x - 1, Location.y);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(-1, diff - 1, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (matrixManager.CanReach(Direction.East))
            {
                Location = new Vector2(Location.x + 1, Location.y);
                var diff = matrixManager.GetHeight(Location) - (int)transform.localPosition.y;
                transform.Translate(1, diff - 1, 0);
            }
        }
    }

    public Vector2 Location { get; set;  }
}
