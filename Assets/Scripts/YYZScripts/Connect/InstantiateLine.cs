using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLine : MonoBehaviour
{
    public GameObject line, currentLine;
    public Vector3 mousePosStart, mousePosCurrent;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosStart = MousePositionToGround() - Vector3.back * 0.1f;
        }
        else if (Input.GetMouseButton(0))
        {
            mousePosCurrent = MousePositionToGround() - Vector3.back * 0.1f;
            if (currentLine == null)
                currentLine = InstantiateLineFromTo(line, mousePosStart, mousePosCurrent);
            else
                currentLine = AdjustLinePos(currentLine, mousePosStart, mousePosCurrent);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //if (currentLine != null)
            //    Destroy(currentLine);
        }
    }
    Vector3 MousePositionToGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << 6))
            return hit.point;
        return Vector3.zero;
    }
    GameObject InstantiateLineFromTo(GameObject line, Vector3 from, Vector3 to)
    {
        float length = (from - to).magnitude;
        GameObject currentLine = Instantiate(line, (from + to) / 2, Quaternion.identity);
        currentLine.transform.rotation = Quaternion.LookRotation(Vector3.forward, (from - to).normalized);
        currentLine.transform.localScale = new Vector3(1, length, 1);
        return currentLine;
    }
    GameObject AdjustLinePos(GameObject currentLine, Vector3 from, Vector3 to)
    {
        float length = (from - to).magnitude;
        currentLine.transform.SetPositionAndRotation((from + to) / 2, Quaternion.LookRotation(Vector3.forward, (from - to).normalized));
        currentLine.transform.localScale = new Vector3(1, length, 1);
        return currentLine;
    }
}