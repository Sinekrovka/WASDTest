using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController Instance;

    public Vector3 cursorPosition;
    public float inputValueX;
    public float inputValueY;

    private Camera _mainCamera;

    private void Awake()
    {
        Instance = this;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursorPosition = hit.point;
        }
        inputValueX = Input.GetAxis("Horizontal");
        inputValueY = Input.GetAxis("Vertical");
        Debug.LogError("MouseScrollUp" + Input.mouseScrollDelta);
    }
}
