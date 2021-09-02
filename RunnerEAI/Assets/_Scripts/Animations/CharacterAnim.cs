using Managers;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class CharacterAnim : MonoBehaviour
    {
        Animator anim;
        List<string> animList;
        int saveIndex;
        void Awake()
        {
            anim = GetComponent<Animator>();
            animList = new List<string>();
            animList.Add("IsIdle");
            animList.Add("IsRun");
            animList.Add("IsSuperRun");
            animList.Add("IsJump");
            animList.Add("IsDead");
            animList.Add("IsWin");
        }
        void OnEnable()
        {
            GameManager.OnJump += JumpAnim;
            GameManager.OnRunning += RunAnim;
            GameManager.OnWin += WinAnim;
            GameManager.OnDead += DeadAnim;
            GameManager.OnStart += IdleAnim;
            GameManager.OnSuperRunning += SuperRunAnim;
        }
        void OnDisable()
        {
            GameManager.OnJump -= JumpAnim;
            GameManager.OnRunning -= RunAnim;
            GameManager.OnWin -= WinAnim;
            GameManager.OnDead -= DeadAnim;
            GameManager.OnStart -= IdleAnim;
            GameManager.OnSuperRunning -= SuperRunAnim;
        }
        void IdleAnim()
        {
            SetAnim("IsIdle");
        }
        void RunAnim()
        {
            SetAnim("IsRun");
        }
        void SuperRunAnim()
        {
            SetAnim("IsSuperRun");
        }
        void JumpAnim()
        {
            SetAnim("IsJump");
        }
        void WinAnim()
        {
            SetAnim("IsWin");
        }
        void DeadAnim()
        {
            SetAnim("IsDead");
        }
        void SetAnim(string animName)
        {
            for(int i = 0; i < animList.Count; i++)
            {
                if (animName != animList[i])
                {
                    anim.ResetTrigger(animList[i]);
                }
                else 
                {
                    saveIndex = i; 
                }
            }
            anim.SetTrigger(animList[saveIndex]);
        }
    }
}

