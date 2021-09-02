using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class VerticalMover
    {
        Rigidbody rb;
        public VerticalMover(PlayerController playerController)
        {
            rb = playerController.GetComponent<Rigidbody>();
        }
        public void Active(float verticalSpeed)
        {
            if (verticalSpeed == 0)
            {
                return;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, verticalSpeed);
        }
    }
}

