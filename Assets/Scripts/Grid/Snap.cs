using UnityEngine;

public class Snap : MonoBehaviour {

    void Awake() {
        transform.position = SnapToGrid(transform.position);
    }

    public Vector3 SnapToGrid(Vector3 Position)
	{
		GameObject grid = GameObject.Find ("gridposition");
		if (! grid)
			return Position;

		Vector3 gridPosition = grid.transform.InverseTransformPoint( Position );

        // round the positions
        gridPosition.x = Mathf.Round( gridPosition.x);
		gridPosition.y = Mathf.Round( gridPosition.y);

        //put back to local size
        Position = grid.transform.TransformPoint( gridPosition );

        return Position;
	}
}



