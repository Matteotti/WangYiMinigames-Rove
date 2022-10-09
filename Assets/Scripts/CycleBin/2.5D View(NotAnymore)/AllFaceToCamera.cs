using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFaceToCamera : MonoBehaviour
{
    public CameraRayToGetEulerangle mainCamera;
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(mainCamera.lookRotation, Camera.main.transform.up);
    }
}
