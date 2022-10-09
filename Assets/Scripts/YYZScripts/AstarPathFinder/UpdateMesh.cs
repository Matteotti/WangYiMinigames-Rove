using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMesh : MonoBehaviour
{
    public int updateSingleFrameCount;
    private void Update()
    {
        if(Time.frameCount % 10 == 0)
        {
            Bounds bounds = GetComponent<BoxCollider2D>().bounds;
            AstarPath.active.UpdateGraphs(bounds);
        }
    }
}
