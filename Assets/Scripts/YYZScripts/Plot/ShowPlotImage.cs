using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlotImage : MonoBehaviour
{
    public List<Sprite> targetImage = new List<Sprite>();
    public float transparentSpeed, lastTime;
    void ShowInOrder()
    {
        //顺序播放image，按时的想法是多个invoke组合
    }
}
