using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLine : MonoBehaviour
{
    public GameObject linePrefab, currentLine, currentLeft, currentRight, currentSquare, currentCollider, currentLineItself, plotBuiltByTime;
    public bool NPCDetected, allowInstantiateLine, isPlotFinished;
    public Vector3 mousePosStart, mousePosCurrent;
    void Update()
    {
        if (isPlotFinished)
        {
            if (Input.GetMouseButtonDown(1) && NPCDetected)
            {
                mousePosStart = MousePositionToGround() - Vector3.back * 0.1f;
                allowInstantiateLine = true;
            }
            else if (Input.GetMouseButton(1) && allowInstantiateLine)
            {
                mousePosCurrent = MousePositionToGround() - Vector3.back * 0.1f;
                if (currentLine == null)
                    currentLine = Instantiate(linePrefab, mousePosStart, Quaternion.identity);
                currentLine = AdjustLinePos(currentLine, mousePosStart, mousePosCurrent);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                if (NPCDetected)
                {
                    currentCollider.GetComponent<LineDetectNPC>().Determine();
                    plotBuiltByTime.GetComponent<PlotBuiltByTime>().isConnected = true;
                }
                else
                {
                    if (currentLine != null)
                        Destroy(currentLine);
                }
                allowInstantiateLine = false;
            }
        }
    }
    Vector3 MousePositionToGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << 6))
            return hit.point;
        return Vector3.zero;
    }
    //GameObject InstantiateLineFromTo(GameObject line, Vector3 from, Vector3 to)
    //{
    //    float length = (from - to).magnitude;
    //    GameObject currentLine = Instantiate(line, (from + to) / 2, Quaternion.identity);
    //    currentLine.transform.rotation = Quaternion.LookRotation(Vector3.forward, (from - to).normalized);
    //    currentLine.transform.localScale = new Vector3(1, length, 1);
    //    return currentLine;
    //}
    GameObject AdjustLinePos(GameObject currentLine, Vector3 from, Vector3 to)
    {
        if (currentLineItself == null)
            currentLineItself = currentLine.transform.GetChild(0).gameObject;
        if (currentSquare == null)
            currentSquare = currentLine.transform.GetChild(1).gameObject;
        if (currentLeft == null)
            currentLeft = currentLine.transform.GetChild(2).gameObject;
        if (currentRight == null)
            currentRight = currentLine.transform.GetChild(3).gameObject;
        if (currentCollider == null)
            currentCollider = currentLine.transform.GetChild(4).gameObject;
        currentLineItself.transform.SetPositionAndRotation(from + 20 * (to - from).normalized, Quaternion.LookRotation(Vector3.forward, new Vector3((to - from).normalized.y, -(to - from).normalized.x)));
        currentSquare.transform.SetPositionAndRotation((from + to) / 2, Quaternion.LookRotation(Vector3.forward, new Vector3((to - from).normalized.y, -(to - from).normalized.x)));
        currentSquare.transform.localScale = new Vector3(((from - to).magnitude - 1) > 0 ? ((from - to).magnitude - 1) : 0, 1, 1);
        currentLeft.transform.SetPositionAndRotation(to - 0.25f * (to - from).normalized, Quaternion.LookRotation(Vector3.forward, new Vector3((to - from).normalized.y, -(to - from).normalized.x)));
        currentRight.transform.SetPositionAndRotation(from + 0.25f * (to - from).normalized, Quaternion.LookRotation(Vector3.forward, new Vector3((to - from).normalized.y, -(to - from).normalized.x)));
        currentCollider.transform.SetPositionAndRotation((from + to)/2, Quaternion.LookRotation(Vector3.forward, new Vector3((to - from).normalized.y, -(to - from).normalized.x)));
        currentCollider.transform.localScale = new Vector3((from - to).magnitude, 1, 1);
        if ((currentLeft.transform.position - currentRight.transform.position).magnitude < 0.5)
        {
            currentLeft.transform.position = currentRight.transform.position + 0.5f * (to - from).normalized * (from - to).magnitude;
            currentLeft.transform.localScale = new Vector3((from - to).magnitude, (from - to).magnitude, 1);
            currentRight.transform.localScale = new Vector3((from - to).magnitude, (from - to).magnitude, 1);
        }
        else
        {
            currentLeft.transform.localScale = new Vector3(1, 1, 1);
            currentRight.transform.localScale = new Vector3(1, 1, 1);
        }
        return currentLine;
    }
}