using UnityEngine;
using System.Collections;

public class Snap : MonoBehaviour {

    void Awake() {
        transform.position = SnapToGrid(transform.position);
    }

    public Vector3 SnapToGrid(Vector3 Position)
	{
		GameObject grid = GameObject.Find ("gridsize");
		if (! grid)
			return Position;

		//	get position on the quad from -0.5...0.5 (regardless of scale)
		Vector3 gridPosition = grid.transform.InverseTransformPoint( Position );

        //	scale up to a number on the grid, round the number to a whole number, then put back to local size
        gridPosition.x = Mathf.Round(gridPosition.x);
		gridPosition.y = Mathf.Round( gridPosition.y);

        Position = grid.transform.TransformPoint( gridPosition );

        return Position;
	}
}



