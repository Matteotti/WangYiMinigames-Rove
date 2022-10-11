using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayToGetEulerangle : MonoBehaviour
{
    public Vector3 lookRotation;
    void Awake()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        lookRotation = -ray.direction;
    }
}
