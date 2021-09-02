using System.Collections;
using System.Collections.Generic;
using Help;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerController : PlayerData
    {
        PlayerController _playerController;
        HorizontalMover _horizontalMover;
        VerticalMover _verticalMover;
        PlayerInput _playerInput;
        Jump _jump;
        Rigidbody rb;
        float inputHorValue;
        void OnEnable()
        {
            GameManager.OnRunning += PlayerRunActive;
            GameManager.OnSuperRunning += PlayerSuperRunActive;
            LevelManager.OnNextLevel += PlayerReset;
            MenuManager.OnResetGame += PlayerReset;
            GameManager.OnDead += PlayerDead;
            GameManager.OnWin += PlayerDead;
        }
        void OnDisable()
        {
            GameManager.OnRunning -= PlayerRunActive;
            GameManager.OnSuperRunning -= PlayerSuperRunActive;
            LevelManager.OnNextLevel -= PlayerReset;
            MenuManager.OnResetGame -= PlayerReset;
            GameManager.OnDead -= PlayerDead;
            GameManager.OnWin -= PlayerDead;
        }
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _playerController = GetComponent<PlayerController>();
            _playerInput = GetComponent<PlayerInput>();

            _horizontalMover = new HorizontalMover(this);
            _verticalMover = new VerticalMover(this);
            _jump = new Jump(this);
        }
        void Start()
        {
            _playerController.SavePlayerValues(HorizontalSpeed, VerticalSpeed ,JumpPower);
        }
        void Update()
        {
            if (rb.velocity.y != 0)
            {
                IsHorizontal = false;
                return;
            }
            inputHorValue = _playerInput.GetMoveInput();
            IsHorizontal = true;
        }
        void FixedUpdate()
        {
            if (GameManager.currentState == GameManager.GetState("Jump"))
            {   
                _jump.Active(JumpPower);
            }
            if (IsHorizontal)
            {
                _horizontalMover.Active(inputHorValue, HorizontalSpeed, BoundX);
            }
        }
        void PlayerRunActive()
        {
            _verticalMover.Active(VerticalSpeed);
        }
        void PlayerSuperRunActive()
        {
            _verticalMover.Active(SuperRunSpeed);
        }
        void PlayerReset()
        {
            _playerController.ResetPlayerValues();
        }
        void PlayerDead()
        {
            rb.velocity = Vector3.zero;
            VerticalSpeed = 0;
            JumpPower = 0;
            HorizontalSpeed = 0;
        }
    }

}
