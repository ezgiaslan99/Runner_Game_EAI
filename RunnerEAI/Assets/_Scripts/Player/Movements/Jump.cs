using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Jump : MonoBehaviour
    {
        Rigidbody rb;
        public Jump( PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody>();
        }
        public void Active(float jumpPower)
        {
            if (rb.velocity.y != 0)
            {
                return;
            }
            rb.AddForce(Vector3.up * Time.deltaTime * jumpPower * 1000);
        }
    }

}
