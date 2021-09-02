using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Help
{
    public static class PlayerHelp
    {
        static float _horSpeed,_verSpeed, _jumpPower;
        public static void SavePlayerValues(this PlayerController player,float horspeed,float verspeed,float jumppower)
        {
            _horSpeed = horspeed;
            _verSpeed = verspeed;
            _jumpPower = jumppower;
        }
        public static void ResetPlayerValues(this PlayerController player)
        {
            player.HorizontalSpeed = _horSpeed;
            player.VerticalSpeed = _verSpeed;
            player.JumpPower = _jumpPower;

            player.transform.position = Vector3.zero;
        }

    }
}

