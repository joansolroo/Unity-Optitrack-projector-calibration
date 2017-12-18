using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCalibrator : MonoBehaviour
{

    public Vector3[] xyz;
    public Vector2[] uv;
    public string status;
    public Camera _projector;
    // Use this for initialization
    void Start()
    {
        Calibration.CameraCalibrationResult result = Calibration.ComputeCameraCalibration(
            xyz,
            uv,
            new System.Drawing.Size(_projector.pixelWidth, _projector.pixelHeight),
            new Emgu.CV.Matrix<double>(3, 3),
            out status);

        result.extrinsics.ApplyToTransform(_projector.transform);
        _projector.projectionMatrix = result.intrinsics.ProjectionMatrix(_projector.nearClipPlane, _projector.farClipPlane);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
