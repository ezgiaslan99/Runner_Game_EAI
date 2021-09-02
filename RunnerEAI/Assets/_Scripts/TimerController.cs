using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] Text currentTimeText, bestTimeText, timeTextInGame;
        public bool IsTimer { get; private set; }

        PlayerData _playerData;

        int bestTime = 100;
        int currentTime;
        float backTime;
        bool startTimer;
        void OnEnable()
        {
            GameManager.OnStart += StartTime;
        }
        void Start()
        {
            _playerData = FindObjectOfType<PlayerData>();
        }
        void Update()
        {
            //1 kere çalýþýyor.Reset için.
            if (startTimer && GameManager.currentState == GameManager.GetState("Running"))
            {
                backTime = Time.time;
                startTimer = false;
                IsTimer = true;
            }
            //Zamaný hesaplýyor
            if (IsTimer)
            {
                currentTime = (int)(Time.time - backTime);
                timeTextInGame.text = currentTime.ToString();
            }
            if (_playerData.VerticalSpeed == 0)
            {
                if (GameManager.currentState == GameManager.GetState("Win"))
                {
                    //Daha iyi bir süreyse
                    if (currentTime < bestTime)
                    {
                        bestTime = currentTime;
                    }
                    bestTimeText.text = bestTime.ToString();
                    currentTimeText.text = currentTime.ToString();
                }
                IsTimer = false;
            }
        }
        void StartTime()
        {
            startTimer = true;
        }
    }

}


