using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSetter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, float.MaxValue, 1 << 6))
            {
                transform.position = hit.point;
            }
        }
    }
}
