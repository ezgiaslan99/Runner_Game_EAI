using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public static event System.Action OnCamera;
        public static event System.Action OnResetGame;

        LevelManager _levelManager;

        [SerializeField] GameObject LoseMenu;
        [SerializeField] GameObject WinMenu;
        [SerializeField] GameObject TapToPlay_PANEL;
        [SerializeField] GameObject NextLevelButton;
        [SerializeField] Text DayText;
        void Awake()
        {
            _levelManager = FindObjectOfType<LevelManager>();    
        }
        void Start()
        {
            GameManager.OnDead += EnableLoseMenu;
            GameManager.OnWin += EnableWinMenu;
            LevelManager.OnNextLevel += DisableWinMenu;
            LevelManager.OnNextLevel += ResetGame;
            LevelManager.OnNextLevel += EnableTapToPlay;

            OnResetGame += DisableLoseMenu;
        }
        void EnableWinMenu()
        {
            WinMenu.SetActive(true);
            Invoke("EnableNextButton",1f);
        }
        void EnableLoseMenu()
        {
            LoseMenu.SetActive(true);
        }
        void DisableWinMenu()
        {
            WinMenu.SetActive(false);
            NextLevelButton.SetActive(false);
        }
        void DisableLoseMenu()
        {
            LoseMenu.SetActive(false);
        }
        void EnableNextButton()
        {
            NextLevelButton.SetActive(true);
        }
        void EnableTapToPlay()
        {
            int day = _levelManager.currentLevel + 1;
            DayText.text = "DAY:" + day;
            TapToPlay_PANEL.SetActive(true);
        }
        public void ResetGame()
        {
            GameManager.SetState("Start");
            OnResetGame?.Invoke();
        }
        public void TapToPlay()
        {
            OnCamera?.Invoke();
            TapToPlay_PANEL.SetActive(false);
        }
        
    }
}

