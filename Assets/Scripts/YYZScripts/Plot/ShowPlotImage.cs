using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlotImage : MonoBehaviour
{
    public List<Sprite> targetImage = new List<Sprite>();
    public Sprite nowImage;
    public Image image;
    public float transparentSpeed, lastTime, lastTimeCounter = 0;
    public bool allow, show;
    public int nowIndex;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if (allow)
        {
            if (image.color.a == 1)
            {
                if(lastTimeCounter <= lastTime)
                    lastTimeCounter += Time.deltaTime;
                else
                {
                    lastTimeCounter = 0;
                    show = false;
                }
            }
            else if (image.color.a == 0)
            {
                show = true;
                if(nowIndex < targetImage.Count - 1)
                {
                    nowImage = targetImage[++nowIndex];
                }
                else
                {
                    gameObject.SetActive(false);
                    //²¥·ÅÍê³É
                }
                image.sprite = nowImage;
            }
            if (show && image.color.a < 0.9f)
            {
                image.color += new Color (0, 0, 0, transparentSpeed * Time.deltaTime);
            }
            else if (show && image.color.a >= 0.9f)
            {
                image.color = new Color(1, 1, 1, 1);
            }
            else if (!show && image.color.a > 0.1f)
            {
                image.color -= new Color(0, 0, 0, transparentSpeed * Time.deltaTime);
            }
            else if (!show && image.color.a <= 0.1f)
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
    void ShowImageInOrder()
    {
        allow = true;
        nowIndex = -1;
    }
}
