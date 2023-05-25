using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speedMovement;
    [SerializeField] private Transform _player;
    [SerializeField] private float RotationSmoothTime = 0.12f;
    
    private float _rotationVelocity;
    private float _verticalVelocity;
    
    void FixedUpdate()
    {
        float x = InputController.Instance.inputValueX;
        float y = InputController.Instance.inputValueY;
        if ( x != 0 || y != 0)
        {
            _player.transform.position += new Vector3(x, 0, y)*_speedMovement*Time.deltaTime;
        }

        Vector3 cursorPos = InputController.Instance.cursorPosition;
        
        cursorPos.y = _player.position.y;
        Vector3 oldAngles = _player.eulerAngles;
        _player.LookAt(cursorPos);
        float _targetRotation = _player.eulerAngles.y;
        _player.eulerAngles = oldAngles;
        float rotation = Mathf.SmoothDampAngle(_player.eulerAngles.y, _targetRotation, ref _rotationVelocity,
            RotationSmoothTime);
        _player.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
    }
}
