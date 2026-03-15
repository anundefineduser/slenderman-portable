using UnityEngine;
using System.Collections;

public class SlenderCameraController : MonoBehaviour
{
    [SerializeField] private new Transform camera;
    [SerializeField] private new Transform transform;

    public bool canLook = true;
    public bool inverted;
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 xClamp;
    private float xRotation;

    void Update()
    {
        if (!canLook) return;
        transform.Rotate(0f, Input.GetAxis("Mouse X") * sensitivity.x, 0f);

        xRotation -= Input.GetAxis("Mouse Y") * sensitivity.y * (inverted ? -1f : 1f);
        xRotation = Mathf.Clamp(xRotation, xClamp.x, xClamp.y);
        var diff = xRotation - camera.localEulerAngles.x;
        camera.Rotate(diff, 0f, 0f, Space.Self);
        Debug.Log(diff);
    }
}
