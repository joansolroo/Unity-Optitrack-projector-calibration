using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyChessboardTracking : MonoBehaviour {

    [SerializeField]
    Texture2D snapshot;

    [SerializeField]
    Vector2[,] corners;
    // Use this for initialization
    void Start () {
        Vector2[,] corners;
        Debug.Log("board?: "+Calibration.FindBoard(snapshot,out corners));
        this.corners = corners;
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnDrawGizmos()
    {
        if (corners != null)
        {
            foreach (Vector2 c in corners)
                Gizmos.DrawSphere(transform.TransformPoint(new Vector3(c.x - 0.5f, c.y - 0.5f, 0)), 0.1f);
        }
    }
}
