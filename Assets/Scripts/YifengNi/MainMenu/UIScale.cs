using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScale : MonoBehaviour
{
    public float timer = 0f;
    public float growTime = 1f;
    public float maxSize = 1f;

    private bool isMaxSize = false;
    private Vector2 initialScale;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        ///鼠标进入更换鼠标纹理
        if (isMaxSize == false) 
        {
            StartCoroutine(Grow());
        }
       
    }


    private void OnMouseExit()
    {
        
        StartCoroutine(Shrink());
        
    }

    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer/growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = true;
    }

    private IEnumerator Shrink()
    {
        Vector2 startScale = transform.localScale;
        

        do
        {
            transform.localScale = Vector3.Lerp(startScale, initialScale, timer / growTime);
            timer += Time.deltaTime;
            yield return null;
        }
        while (timer < growTime);

        isMaxSize = false;
    }
}
