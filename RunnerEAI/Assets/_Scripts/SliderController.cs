using Managers;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace slide
{
    public class SliderController : MonoBehaviour
    {
        public Image coffee;
        public Image completionFill;
        [SerializeField]
        Transform playerTransform;
        PlayerData _playerData;
        Rigidbody playerRb;
        [SerializeField]
        float stamina;
        float maxStamina;
        float startZ;
        float finishZ;
     
        void OnEnable()
        {
            MenuManager.OnResetGame += ResetSlider;
            LevelManager.OnNextLevel += ResetSlider;
        }
        void Start()
        {
            _playerData = FindObjectOfType<PlayerData>();
            playerRb = FindObjectOfType<PlayerController>().GetComponent<Rigidbody>();
            stamina = 0;
            maxStamina = 100;
            finishZ = 155f;
        }

        void Update()
        {
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
            coffee.fillAmount = stamina / maxStamina;// fraction needed because fillAmount is 0 to 1 in value

            startZ = playerTransform.position.z;
            completionFill.fillAmount = startZ / finishZ;
        }
        public void Stamina(int integer)
        {
            if (integer == 1)
            {
                stamina += 25;
            }
            else if (integer == -1 && stamina == maxStamina)
            {
                if (GameManager.currentState != GameManager.GetState("Dead") && playerRb.velocity.y == 0)
                {
                    stamina -= 100;
                    StartCoroutine("StartSuperRunning");
                    GameManager.SetState("SuperRunning");
                }
            }
        }
        IEnumerator StartSuperRunning()
        {

            yield return new WaitForSeconds(_playerData.SuperRunLifeTime);

            if (GameManager.currentState != GameManager.GetState("Dead") && GameManager.currentState != GameManager.GetState("Start"))
            {
                GameManager.SetState("Running");
            }
        }

        void ResetSlider()
        {
            stamina = 0;
        }
      
    }

}