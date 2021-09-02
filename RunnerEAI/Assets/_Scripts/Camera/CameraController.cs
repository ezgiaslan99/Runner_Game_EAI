using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : CameraData
{
    CameraProcess _cameraProcess;
    public CameraStates state;
    public enum CameraStates
    {
        Start,
        Idle,
        InGame,
        End
    }
    void OnEnable()
    {
        LevelManager.OnNextLevel += SetStateStart;
        MenuManager.OnCamera += SetStateIdle;
    }
    void Awake()
    {
        _cameraProcess = new CameraProcess(this);
    }
    void Start()
    {
        SetStateStart();
    }
    void Update()
    {
        if (transform.position == targetPos)
        {   
            distance = targetPlayer.transform.position - transform.position;
            SetStateRunning();
        }
    }
    void LateUpdate()
    {
        switch (state)
        {
            case CameraStates.Start:
                _cameraProcess.StartMOD(firstPos,firstRot);
            break;
            
            case CameraStates.Idle:
                _cameraProcess.IdleMOD(targetPos, targetRot);
            break;

            case CameraStates.InGame:
                _cameraProcess.InGameMOD(distance,targetPlayer.transform.position);
            break;

            case CameraStates.End:
                _cameraProcess.EndMOD();
            break;
        }
    }
    void SetStateStart()
    {
        state = CameraStates.Start;
    }
    void SetStateIdle()
    {
        state = CameraStates.Idle;
    }
    void SetStateRunning()
    {
        state = CameraStates.InGame;
        GameManager.SetState("Running");
    }
}
