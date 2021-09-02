using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Player
{
    public class PlayerCollisionController : MonoBehaviour
    {
        PlayerController _playerController;
        void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        void OnCollisionEnter(Collision collision)
        {
            switch (collision.collider.tag)
            {
                case "Floor":
                    
                    if (GameManager.currentState == GameManager.GetState("Jump"))
                    {
                        GameManager.SetState("Running");
                    }
                    break;

                case "_obstacle":
                    if (GameManager.currentState == GameManager.GetState("Dead"))
                    {
                        return;
                    }
                    GameManager.SetState("Dead");
                    SoundManager.Instance.ObstacleCrashMusic();
                    break;

                case "_finishLine":
                    if (GameManager.currentState == GameManager.GetState("Win")) 
                    {
                        return; 
                    }
                    GameManager.SetState("Win");
                    break;
            }
        }
    }
}

