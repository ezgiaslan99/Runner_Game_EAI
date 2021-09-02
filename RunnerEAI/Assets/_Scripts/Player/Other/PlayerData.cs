using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class PlayerData : MonoBehaviour
    {
        [field:Header("PlayerOzellikler")]
        [field:SerializeField]
        public float HorizontalSpeed { get; set; }
        
        [field: SerializeField] 
        public float VerticalSpeed { get; set; }

        [field: SerializeField]
        public float JumpPower { get; set; }

        [field: Header("Diger")]

        [SerializeField] protected float BoundX;
        public bool IsHorizontal { get; protected set; }
   
        [field: Header("SuperRunSkill")]
        [field: SerializeField]
        public float SuperRunSpeed { get; set; }
        [field: SerializeField]
        public float SuperRunLifeTime { get; set; }

    }
}