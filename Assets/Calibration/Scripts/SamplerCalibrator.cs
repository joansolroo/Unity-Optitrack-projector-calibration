using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplerCalibrator : MonoBehaviour {

    public List<Vector3> xyz = new List<Vector3>();
    public List<Vector2> uv = new List<Vector2>();
    public string status;
    public Camera _projector;

    [SerializeField]
    Transform target;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 uv1 = (_projector.ScreenToViewportPoint(Input.mousePosition));
            Vector3 xyz1 = target.position;

            uv.Add(uv1);
            xyz.Add(xyz1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ComputeCalibration();
        }

    }

    void ComputeCalibration()
    {
        Calibration.CameraCalibrationResult result = Calibration.ComputeCameraCalibration(
            xyz.ToArray(),
            uv.ToArray(),
            new System.Drawing.Size(_projector.pixelWidth, _projector.pixelHeight),
            new Emgu.CV.Matrix<double>(3, 3),
            out status);

        result.extrinsics.ApplyToTransform(_projector.transform);
        _projector.projectionMatrix = result.intrinsics.ProjectionMatrix(_projector.nearClipPlane, _projector.farClipPlane);

    }
}
