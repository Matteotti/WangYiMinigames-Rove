using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject GameUI;
    public GameObject BlackFilter;


    public Texture2D enterTexture;
    public Texture2D exitTexture;
    public Texture2D ClickTexture;
    public AudioSource soundeffect0;
     

    public float timer = 0f;
    public float maxSize = 1.5f;



    private Vector2 initialScale;
    private bool inbutton;
    private float maxScale;
    private bool show_menu;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        anim = menu.GetComponent<Animator>();
        transform.localScale = initialScale;
        show_menu = false;
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void entermouse() 
    {
        Cursor.SetCursor(enterTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void exitmouse()
    {
        Cursor.SetCursor(exitTexture, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Back()
       
    {
        BlackFilter.SetActive(false);
        menu.SetActive(false);
        GameUI.SetActive(false);
        show_menu = false;
        Time.timeScale = 1.0f;
    }

    public void Exit()

    {
        Time.timeScale = 1.0f;
        anim.Play("paperplane");
        StartCoroutine(Delay(4.1f));
        


    }

    IEnumerator Delay(float seconds)
    {
        print(Time.time);
        
        yield return new WaitForSeconds(seconds);
        //SceneManager.LoadScene("MainMenu");
        
        Application.Quit();

        print(Time.time);
    }

}
