using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameLogic : MonoBehaviour
{
    public GameObject menu;
    public GameObject GameUI;
    public GameObject BlackFilter;
    public Slider Slider;


    public Texture2D normalTexture;
    public Texture2D letterTexture;
    public Texture2D ClickTexture;
    public AudioSource soundeffect0;

    public float timer = 0f;
    public float maxSize = 1.5f;



    private Vector2 initialScale;
    private bool inbutton;
    private float maxScale;
    private bool show_menu;
    
    // Start is called before the first frame update
    void Start()
    {
        maxScale = 1.65f;
        show_menu = false;
        initialScale = transform.localScale;
        inbutton = false;
        Cursor.SetCursor(normalTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inbutton == true)
        {
            Cursor.SetCursor(ClickTexture, Vector2.zero, CursorMode.ForceSoftware);
            soundeffect0.Play();     
            if (show_menu == false)
            {
                BlackFilter.SetActive(true);
                menu.SetActive(true);
                GameUI.SetActive(true);
                show_menu = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                BlackFilter.SetActive(false);
                menu.SetActive(false);
                GameUI.SetActive(false);
                show_menu = false;
                Time.timeScale = 1.0f;
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
        //levelname = gameObject.name;
        //Debug.Log(levelname);
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
