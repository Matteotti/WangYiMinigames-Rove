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
    private bool inbutton;
    private string levelname;
    // Start is called before the first frame update
    void Start()
    {
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
                case "Bottle":
                    StartCoroutine(LoadSceneAsync("Gameplay 1-1"));
                    SliderPanel.SetActive(true);
                    LoadSceneAsync("Gameplay 1-1");
                    break;
                case "Letter":
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
        Cursor.SetCursor(letterTexture, Vector2.zero, CursorMode.ForceSoftware);
        levelname = gameObject.name;
        Debug.Log(levelname);
        inbutton = true;
        
    }


    private void OnMouseExit()
    {
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
}
