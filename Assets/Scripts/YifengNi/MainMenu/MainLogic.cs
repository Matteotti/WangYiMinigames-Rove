using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainLogic : MonoBehaviour
{
    public GameObject SliderPanel;
    public Slider Slider;
    public Texture2D normalTexture;
    public Texture2D letterTexture;
    public Texture2D ClickTexture;
    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 1.5f;

    private bool isMaxSize = false;
    private Vector2 initialScale;
    private bool inbutton;
    private string levelname;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
        inbutton = false;
        Cursor.SetCursor(normalTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inbutton==true)
        {
            Cursor.SetCursor(ClickTexture, Vector2.zero, CursorMode.ForceSoftware);

            
            switch (levelname)
            {
                case "Letter":
                    StartCoroutine(LoadSceneAsync("Gameplay 1-1"));
                    SliderPanel.SetActive(true);
                    LoadSceneAsync("Gameplay 1-1");
                    break;
                case "Phone":
                    StartCoroutine(LoadSceneAsync("Gameplay 2-1"));
                    SliderPanel.SetActive(true);
                    LoadSceneAsync("Gameplay 2-1");
                    break;
                default:
                    
                    break;
            }
        }

        if (Input.GetMouseButtonUp(0) && inbutton == true)
        {
            Cursor.SetCursor(letterTexture, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    

    private void OnMouseEnter()
    {
        ///鼠标进入更换鼠标纹理
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        ///鼠标进入更换鼠标纹理
        Cursor.SetCursor(letterTexture, Vector2.zero, CursorMode.ForceSoftware);
        levelname = gameObject.name;
        Debug.Log(levelname);
        inbutton = true;
        
    }


    private void OnMouseExit()
    {
        transform.localScale = initialScale;
        Cursor.SetCursor(normalTexture, Vector2.zero, CursorMode.ForceSoftware);
        ///鼠标移除后将鼠标的 Texture 文本
        inbutton = false;
    }


    IEnumerator LoadSceneAsync(string Levelname)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Levelname);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            Slider.value = progress;
            yield return null;
        }
    }

    private IEnumerator Grow()
    {
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(maxSize, maxSize);

        do
        {
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
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
