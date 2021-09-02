using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraData : MonoBehaviour
{
    [SerializeField] protected Transform targetPlayer;
    [Header("CameraIdle")]
    [SerializeField] protected Vector3 firstPos;
    [SerializeField] protected Vector3 firstRot;
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected Vector3 targetRot;
    [Header("CameraInGame")]
    [SerializeField] protected Vector3 distance;
}
