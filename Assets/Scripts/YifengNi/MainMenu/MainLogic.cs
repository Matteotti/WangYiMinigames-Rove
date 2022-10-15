using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainLogic : MonoBehaviour
{
    public GameObject radio_menu;
    public GameObject phone_menu;
    public GameObject SliderPanel;
    public Slider Slider;
    public Texture2D normalTexture;
    public Texture2D letterTexture;
    public Texture2D ClickTexture;
    public AudioSource soundeffect0;

    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 1.5f;


    
    private Vector2 initialScale;
    private bool inbutton;
    private string levelname;
    private float maxScale;

    private bool show_resmenu;
    private bool show_musicmenu;
    // Start is called before the first frame update
    void Start()
    {
        maxScale = 0.65f;
        show_musicmenu = false;
        show_resmenu = false;
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
            soundeffect0.Play();

            
            switch (levelname)
            {
                case "Letter":
                    StartCoroutine(LoadSceneAsync("Gameplay 1-1"));
                    SliderPanel.SetActive(true);
                    LoadSceneAsync("Gameplay 1-1");
                    break;

                case "Phone":
                    if (show_resmenu == false)
                    {
                        phone_menu.SetActive(true);
                        show_resmenu = true;
                    }
                    else 
                    { 
                        phone_menu.SetActive(false);
                        show_resmenu=false;
                    }
                   
                    break;

                case "Radio":
                    if (show_musicmenu == false)
                    {
                        radio_menu.SetActive(true);
                        show_musicmenu = true;
                    }
                    else
                    {
                        radio_menu.SetActive(false);
                        show_musicmenu = false;
                    }
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
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);
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
}
