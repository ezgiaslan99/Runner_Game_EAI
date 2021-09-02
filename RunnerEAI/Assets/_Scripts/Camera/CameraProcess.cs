using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Player;
public class CameraProcess : MonoBehaviour
{
    CameraController _cameraController;
    Vector3 velocity;
    public CameraProcess(CameraController cameraController)
    {
        _cameraController = cameraController;
        velocity = Vector3.zero;
    }
    public void StartMOD(Vector3 firstPos, Vector3 firstRot)
    {
        _cameraController.transform.position = firstPos;
        _cameraController.transform.eulerAngles = firstRot;
    }
    public void IdleMOD(Vector3 targetPos, Vector3 targetRot)
    {
        _cameraController.transform.position = Vector3.SmoothDamp(_cameraController.transform.position, targetPos, ref velocity, 0.3f);
        _cameraController.transform.rotation = Quaternion.Lerp(_cameraController.transform.rotation, Quaternion.Euler(targetRot), 10 * Time.deltaTime);
    }
    public void InGameMOD(Vector3 distance,Vector3 targetPosition)
    {
        _cameraController.transform.position = new Vector3(0, targetPosition.y - distance.y, targetPosition.z-9f);
    }
    public void EndMOD()
    {

    }
}
