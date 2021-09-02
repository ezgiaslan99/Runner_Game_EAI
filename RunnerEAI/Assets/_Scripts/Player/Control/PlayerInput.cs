using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player 
{
    public class PlayerInput: MonoBehaviour
    {
        //TAP to PLAY first screen input
        
        private Vector2 startPos;
        private Vector2 direction;
        private int inputInt;
        private int tapCount;
        private float firstClick;
        private PlayerController _playerController;
        Rigidbody rb;
        public int GetMoveInput()
        {
            if (Input.touchCount > 0)
            {
                Touch _touch = Input.GetTouch(0);

                switch (_touch.phase)
                {
                    case TouchPhase.Began:
                        startPos = _touch.position;
                        break;
                    case TouchPhase.Moved:
                        direction = _touch.position - startPos;
                        if (direction.x > 0)
                        {
                            inputInt = 1;
                            // vector3 eklemesi yap ve playerın x pozisyonunu bir **SAĞ**lane e geçecek kadar değiştir
                        }
                        else
                        {
                            inputInt = -1;
                            // vector3 eklemesi yap ve playerın x pozisyonunu bir **SOL** lane e geçecek kadar değiştir
                        }
                        break;
                    case TouchPhase.Ended:
                        inputInt = 0;
                        break;
                }
                
            }

            return inputInt;
        }

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
            rb = _playerController.GetComponent<Rigidbody>();
        }
        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                tapCount += 1;
                StartCoroutine(Countdown());    
            }
       
            if (tapCount == 2)
            {    
                tapCount = 0;
                StopCoroutine(Countdown());

                if (rb.velocity.y == 0 && GameManager.currentState!=GameManager.GetState("Start") && GameManager.currentState != GameManager.GetState("Dead"))
                {
                    GameManager.SetState("Jump");
                }

            }
        }
        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(0.2f);
            tapCount = 0;
        }
    }
}
