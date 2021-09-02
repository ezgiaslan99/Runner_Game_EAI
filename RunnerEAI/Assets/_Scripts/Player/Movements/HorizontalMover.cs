using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class HorizontalMover
    {
        PlayerController _playerController;
        float BoundX;
        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
        }
        public void Active(float inputHorValue,float horizontalSpeed,float moveBoundary)
        {
            if (inputHorValue == 0)
            {
                return;
            }
            _playerController.transform.Translate(Vector3.right * inputHorValue * horizontalSpeed * Time.deltaTime );
            BoundX = Mathf.Clamp(_playerController.transform.position.x, -moveBoundary, moveBoundary);
            _playerController.transform.position = new Vector3(BoundX, _playerController.transform.position.y, _playerController.transform.position.z);
        }
    }

}
